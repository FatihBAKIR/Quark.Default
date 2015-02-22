using Quark;
using UnityEngine;

public class TranslateEffect : Effect
{
    readonly Vector3 _movement;
	public TranslateEffect (Vector3 movement)
	{
		_movement = movement;
	}

	public override void Apply (Targetable target)
	{
		target.transform.Translate (_movement);
	}

	public override void Apply (Character target)
	{
		Apply ((Targetable)target);
	}
}
