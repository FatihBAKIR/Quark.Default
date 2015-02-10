using System;
using Quark;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffect : Effect
{
	Effect _effect;
	float _range;
	public AreaOfEffect (Effect effect, float range)
	{
		_effect = effect;
		_range = range;
	}

	public override void Apply (UnityEngine.Vector3 point)
	{
		NearbyCharacters chars = new NearbyCharacters (point, _range);
		chars.CharacterSelected += HandleCharacterSelected;
		chars.Run ();
		foreach (Character target in targets) {
			_effect.SetContext(_context);
			_effect.Apply (target);
		}
		base.Apply (point);
	}

	List<Character> targets = new List<Character>();
	void HandleCharacterSelected (Character target)
	{
		targets.Add (target);
	}
}
