using Quark;
using Quark.Buff;
using UnityEngine; //For Vector3

public class PullBuff : Buff
{
	Vector3 _pullTo;
	Vector3 _movement;
	bool _setToCaster;
	float _speed;

	public PullBuff (float speed = 1)
	{
		Continious = true;
		Duration = -1;
		_setToCaster = true;
		_speed = speed;
	}

	public PullBuff (Vector3 position, float speed = 1)
	{
		Continious = true;
		Duration = -1;
		_pullTo = position;
		_movement = CalculateMovement ();
		_speed = speed;
	}

	public override void OnPossess (Character possessor)
	{
		base.OnPossess (possessor);
		if (_setToCaster) {
			_pullTo = Context.CastBeginPoint + Context.Caster.transform.forward;
			_movement = CalculateMovement ();
		}
	}

	Vector3 CalculateMovement ()
	{
		return (_pullTo - Possessor.transform.position).normalized;
	}

	protected override EffectCollection TickEffects {
		get {
			return new EffectCollection {
				new TranslateEffect (_movement * Time.deltaTime * _speed)
			};
		}
	}
}