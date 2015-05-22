using System;
using Assets.QuarkDefault.Conditions;
using Assets.QuarkDefault.Spells;
using Assets.QuarkDefault.TargetMacros;
using Quark;
using Quark.Spells;
using Quark.Targeting;
using Quark.Utilities;
using UnityEngine;

namespace Assets.QuarkDefault.ControllerBuffs
{
    class AIController : QuarkController
    {
        enum AIState
        {
            Patrol,
            MovingTo,
            Aggressive
        }

        private AIState _state;

        private readonly float _rotateSpeed;

        public AIController(float rotateSpeed = 1.05f, bool hasAnimator = false)
        {
            HasAnimator = hasAnimator;
            _rotateSpeed = rotateSpeed;
        }

        protected override float RotateSpeed
        {
            get { return _rotateSpeed; }
        }

        bool CanMove
        {
            get { return !Possessor.HasCast; }
        }

        private Vector3 _move;
        protected override Vector3 Movement
        {
            get
            {
                if (IsGrounded)
                {
                    _move = Possessor.transform.forward*0.4f*MoveSpeed;
                    base.TargetMoveSpeed = MoveSpeed;
                }

                _move -= Gravity * Time.deltaTime;

                if (!CanMove)
                    _move = new Vector3(0, _move.y, 0);

                return _move;
            }
        }

        private float _lastRotate;

        private float TimeSinceRotation
        {
            get { return Time.timeSinceLevelLoad - _lastRotate; }
        }

        protected override Vector3 Rotation
        {
            get
            {
                if (!CanMove)
                    return Vector3.zero;

                switch (_state)
                {
                    case AIState.Patrol:
                        if (TimeSinceRotation > 2.5f)
                        {
                            _lastRotate = Time.timeSinceLevelLoad;
                            return Vector3.zero;
                        }
                        if (TimeSinceRotation > 1)
                            return new Vector3(0, _rotateSpeed / 2, 0);
                        break;
                    case AIState.MovingTo:
                        Vector3 current = Possessor.transform.forward;
                        Vector3 shouldBe = _movingTo - Possessor.transform.position;
                        current.Normalize();
                        shouldBe.Normalize();

                        float angle = Quaternion.FromToRotation(current, shouldBe).eulerAngles.y;
                        if (angle > 180)
                            angle -= 360;

                        return new Vector3(0, 3 * angle / 50, 0);
                }

                return Vector3.zero;
            }
        }


        private Vector3 _movingTo;
        void GoTowards(Vector3 point)
        {
            _state = AIState.MovingTo;
            _movingTo = point;
        }

        void Patrol()
        {
            if (_state == AIState.Patrol)
                return;

            _state = AIState.Patrol;
            _lastRotate = 0;
        }

        void Aggressive()
        {
            if (_state == AIState.Aggressive)
                return;

            _state= AIState.Aggressive;
            
        }

        protected override void OnTick()
        {
            _searcher.Run();
            base.OnTick();
        }

        private NearestCharacter _searcher;
        public override void OnPossess()
        {
            base.OnPossess();
            _searcher = new NearestCharacter(6);
            _searcher.SetContext(Cast.PrepareCast(Possessor, new Spell()), true);
            _searcher.TargetingSuccess += CharacterOnTargetingSuccess;
            _searcher.TargetingFailed += SearcherOnTargetingFailed;
        }

        private void SearcherOnTargetingFailed(TargetingError error)
        {
            Patrol();
        }

        private void CharacterOnTargetingSuccess(TargetCollection targets)
        {
            Character target = targets.FirstCharacter;

            if (new TagCondition("Faction.Zombies").Check(target))
            {
                Patrol();
                return;
            }

            float distance = Utils.Distance2(target.transform.position, Possessor.transform.position);

            if (distance <= 1.5f)
            {
                Cast.PrepareCast(Possessor, new ZombieAaSpell());
                return;
            }

            GoTowards(target.transform.position);
        }
    }
}
