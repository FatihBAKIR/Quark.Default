using Quark;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This effect relays the target Characters position to the given effect.
/// </summary>
public class OnCharacterPositionEffect : Effect
{
    readonly Effect _effect;

	public OnCharacterPositionEffect (Effect effect)
	{
		_effect = effect;
	}

	public override void Apply (Character target)
	{
		_effect.Apply (target.gameObject.transform.position);
	}
}