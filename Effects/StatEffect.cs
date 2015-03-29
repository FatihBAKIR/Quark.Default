using UnityEngine;
using System.Collections;
using Quark;

/// <summary>
/// Stat effect.
/// This effect manipulates one of the given target Characters stat on Apply time
/// </summary>
public class StatEffect : Effect
{
	readonly string _tag;
	readonly Interaction _casterInteractions;
	readonly Interaction _targetInteractions;
	readonly float _constant;

	public StatEffect (string statTag, float constant) : this(statTag, null, null, constant)
	{
	}

	public StatEffect (string statTag, Interaction casterInteractions, Interaction targetInteractions, float constant = 0)
	{
		_tag = statTag;
		_casterInteractions = casterInteractions;
		_targetInteractions = targetInteractions;
		_constant = constant;
	}

	protected virtual float CalculateValue (Character of)
	{
		float casterVal = _casterInteractions == null ? 0 : _casterInteractions.Calculate (Context.Caster);
		float targetVal = _targetInteractions == null ? 0 : _targetInteractions.Calculate (of);

		return casterVal + targetVal;
	}

	public override void Apply (Character target)
	{
		float change = 0;
		change += _constant;
		change += CalculateValue (target);

		target.GetStat (_tag).Manipulate (change);
		new EffectArgs (this, target).Broadcast ();
	}
}

