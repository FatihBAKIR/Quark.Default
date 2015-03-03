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

	float _speed = 6, _jumpSpeed = 8, _gravity = 20;
	CharacterController _controller;

	public override void OnPossess ()
	{
		_controller = Possessor.GetComponent<CharacterController> ();
	}

	Vector3 _moveDirection = Vector3.zero;
	Vector3 Movement
	{
		get {
			if (_controller.isGrounded) {
				_moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
				_moveDirection = Possessor.transform.TransformDirection (_moveDirection);
				_moveDirection *= _speed;
				if (Input.GetButton ("Jump"))
					_moveDirection.y = _jumpSpeed;
			}
			_moveDirection.y -= _gravity * Time.deltaTime;
			return _moveDirection;
		}
	}

	protected override EffectCollection TickEffects {
		get {
			return new EffectCollection {
				new ControllerMoveEffect (Movement * Time.deltaTime)
			};
		}
	}
}
