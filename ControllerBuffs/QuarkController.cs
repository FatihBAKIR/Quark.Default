using Assets.QuarkDefault.Effects;
using Quark.Buffs;
using Quark.Contexts;
using Quark.Effects;
using UnityEngine;

/*
 * #### WARNING ####
 * THIS ASSET IS VERY VERY EXPERIMENTAL
 * AND DEFINITELY GOING TO CHANGE IN THE NEAR FUTURE
 * DO NOT RELY ON IT
 * ####
 */

namespace Assets.QuarkDefault.ControllerBuffs
{
    public class QuarkController : Buff<IContext>
    {
        protected readonly Vector3 Gravity;
        private const float G = 12;

        public QuarkController()
        {
            Duration = -1;
            Hidden = true;
            Continuous = true;
            Gravity = new Vector3(0, G, 0);
        }

        CharacterController _controller;

        protected virtual float MoveSpeed
        {
            get { return Possessor.GetStat("ms").Value; }
        }

        protected virtual float RotateSpeed
        {
            get { return 1.5f; }
        }

        protected virtual float JumpSpeed
        {
            get { return 6; }
        }

        protected bool HasAnimator = true;

        public override void OnPossess()
        {
            base.OnPossess();
            _controller = Possessor.GetComponent<CharacterController>();
            HasAnimator = Possessor.GetComponent<Animator>() != null;
        }

        protected virtual bool IsMoving
        {
            get { return false; }
        }

        protected bool IsGrounded
        {
            get { return _controller.isGrounded; }
        }

        protected virtual Vector3 Movement
        {
            get { return Vector3.zero - Gravity; }
        }

        protected virtual Vector3 Rotation
        {
            get { return Vector3.zero; }
        }

        private bool _wasMoving;

        public override void OnTick()
        {
            if (IsMoving && !_wasMoving)
            {
                OnMove();
                _wasMoving = true;
            }

            if (!IsMoving && _wasMoving)
            {
                OnStop();
                _wasMoving = false;
            }
            base.OnTick();
        }

        protected virtual void OnMove()
        {
            TargetMoveSpeed = MoveSpeed / 3.5f;
            MoveEffects.Run(Possessor, Context);
        }

        protected virtual void OnStop()
        {
            TargetMoveSpeed = 0;
            StopEffects.Run(Possessor, Context);
        }

        protected virtual EffectCollection<IContext> MoveEffects
        {
            get
            {
                return new EffectCollection<IContext>();
            }
        }

        protected virtual EffectCollection<IContext> StopEffects
        {
            get
            {
                return new EffectCollection<IContext>();
            }
        }

        protected float TargetMoveSpeed { get; set; }
        private float _moveVelocity;
        private float _currentms;

        float CurrentMoveSpeed
        {
            get
            {
                _currentms = Mathf.SmoothDamp(_currentms, TargetMoveSpeed, ref _moveVelocity, 0.2f);
                return _currentms;
            }
        }

        protected override EffectCollection<IContext> TickEffects
        {
            get
            {
                return new EffectCollection<IContext> {
                    new RotateEffect(Possessor.transform.rotation.eulerAngles + Rotation),
                    new ControllerMoveEffect (Movement * Time.deltaTime),
                    ConditionalEffect.Create(HasAnimator, new MecanimEffect("Speed Input", CurrentMoveSpeed))
                };
            }
        }


    }
}
