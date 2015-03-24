using UnityEngine;
using Quark;
using Quark.Buffs;

/*
 * #### WARNING ####
 * THIS ASSET IS VERY VERY EXPERIMENTAL
 * AND DEFINITELY GOING TO CHANGE IN THE NEAR FUTURE
 * DO NOT RELY ON IT
 * ####
 * 
 * This is a complete ripoff of the example CharacterController.Move code from Unity scripting reference:
 * http://docs.unity3d.com/ScriptReference/CharacterController.Move.html
 */

public class PlayerController : Buff
{
	public PlayerController ()
	{
		Duration = -1;
		Hidden = true;
		Continuous = true;
	}

	float _speed = 4, _jumpSpeed = 6, _gravity = 12;
	CharacterController _controller;

	public override void OnPossess ()
	{
		_controller = Possessor.GetComponent<CharacterController> ();
	}

	Vector3 _moveDirection = Vector3.zero;
	Vector3 Movement
	{
		get {
			return _moveDirection;
		}
	}

    void Calculate()
    {
        if (_controller.isGrounded)
        {
            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveDirection = Possessor.transform.TransformDirection(_moveDirection);
            _moveDirection *= _speed;
            if (Input.GetButton("Jump"))
                _moveDirection.y = _jumpSpeed;
        }
        _moveDirection.y -= _gravity * Time.deltaTime;
    }

    bool IsMoving
    {
        get { return (Movement.x != 0 || Movement.z != 0); }
    }

    private bool _wasMoving;
    protected override void OnTick()
    {
        Calculate();

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
        MoveEffects.Run(Possessor, Context);
    }

    void OnStop()
    {
        StopEffects.Run(Possessor, Context);
    }

    private EffectCollection MoveEffects
    {
        get
        {
            return new EffectCollection();
        }
    }

    private EffectCollection StopEffects
    {
        get
        {
            return new EffectCollection
            {
                new AnimateEffect("idle")
            };
        }
    }

    protected override EffectCollection TickEffects {
        get
        {
            //Debug.Log(Movement + " -> " + IsMoving);
			return new EffectCollection {
				new ControllerMoveEffect (Movement * Time.deltaTime),
                IsMoving ? new AnimateEffect("run") : new Effect()
			};
		}
	}
}
