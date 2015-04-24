using Assets.QuarkDefault.Effects;
using Assets.QuarkDefault.Spells;
using UnityEngine;
using Quark;
using Quark.Buffs;

/*
 * #### WARNING ####
 * THIS ASSET IS VERY VERY EXPERIMENTAL
 * AND DEFINITELY GOING TO CHANGE IN THE NEAR FUTURE
 * DO NOT RELY ON IT
 * ####
 */

public class PlayerController : Buff
{
    private const float JumpSpeed = 6;
    private const float Gravity = 12;
    private const float RotateSpeed = 3;

    public PlayerController()
    {
        Duration = -1;
        Hidden = true;
        Continuous = true;
        _gravity = new Vector3(0, Gravity, 0);
    }

    CharacterController _controller;

    float MoveSpeed
    {
        get { return Possessor.GetStat("ms").Value; }
    }

    public override void OnPossess()
    {
        _controller = Possessor.GetComponent<CharacterController>();
    }

    bool IsMoving
    {
        get { return Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f; }
    }

    Vector3 _move = Vector3.zero;
    Vector3 _rotate = Vector3.zero;
    readonly Vector3 _gravity;

    void Calc()
    {
        if (_controller.isGrounded)
        {
            _rotate = new Vector3(0, Input.GetAxis("Horizontal") * RotateSpeed, 0);
            _move = Possessor.transform.forward * Input.GetAxis("Vertical") * MoveSpeed;

            if (Input.GetButton("Jump"))
                _move.y = JumpSpeed;
        }
        else
            _rotate = Vector3.zero;

        _move -= _gravity * Time.deltaTime;
    }

    private bool _wasMoving;
    protected override void OnTick()
    {
        Calc();

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

    void OnMove()
    {
        TargetMoveSpeed = MoveSpeed / 3.5f;
        MoveEffects.Run(Possessor, Context);
    }

    void OnStop()
    {
        TargetMoveSpeed = 0;
        StopEffects.Run(Possessor, Context);
    }

    private EffectCollection MoveEffects
    {
        get
        {
            return new EffectCollection
            {
            };
        }
    }

    private EffectCollection StopEffects
    {
        get
        {
            return new EffectCollection
            {
            };
        }
    }

    float TargetMoveSpeed { get; set; }
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

    protected override EffectCollection TickEffects
    {
        get
        {
            return new EffectCollection {
                new RotateEffect(Possessor.transform.rotation.eulerAngles + _rotate),
				new ControllerMoveEffect ((_move) * Time.deltaTime),
                new MecanimEffect("Speed Input", CurrentMoveSpeed) 
			};
        }
    }
}
    