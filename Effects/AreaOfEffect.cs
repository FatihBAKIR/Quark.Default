using Quark;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This effect relays the characters in a range of the target point to the given effect 
/// </summary>
public class AreaOfEffect : Effect
{
    readonly Effect _effect;
    readonly float _range;
	public AreaOfEffect (Effect effect, float range)
	{
		_effect = effect;
		_range = range;
	}

	public override void Apply (Vector3 point)
	{
		NearbyCharacters chars = new NearbyCharacters (point, _range);
		chars.CharacterSelected += HandleCharacterSelected;
		chars.Run ();
		foreach (Character target in _targets) {
			_effect.SetContext(Context);
			_effect.Apply (target);
		}
		base.Apply (point);
	}

    readonly List<Character> _targets = new List<Character>();

	void HandleCharacterSelected (Character target)
	{
		_targets.Add (target);
	}
}
