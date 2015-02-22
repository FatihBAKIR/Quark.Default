using UnityEngine;
using Quark;
using Quark.Buff;

public class PlayerController : Buff
{
	public PlayerController ()
	{
		Duration = -1;
		Hidden = true;
		Continuous = true;
	}

	float speed = 6, jumpSpeed = 8, gravity = 20;
	CharacterController controller;

	public override void OnPossess (Character possessor)
	{
		base.OnPossess (possessor);
		controller = Possessor.GetComponent<CharacterController> ();
	}

	Vector3 moveDirection = Vector3.zero;
	Vector3 Movement
	{
		get {
			if (controller.isGrounded) {
				moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
				moveDirection = Possessor.transform.TransformDirection (moveDirection);
				moveDirection *= speed;
				if (Input.GetButton ("Jump"))
					moveDirection.y = jumpSpeed;
			}
			moveDirection.y -= gravity * Time.deltaTime;
			return moveDirection;
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
