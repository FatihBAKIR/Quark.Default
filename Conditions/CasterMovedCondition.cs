using System;
using Quark;
using UnityEngine;

/// <summary>
/// This condition checks whether the Caster Character of a Cast context has moved Missile.NearEnough units away from the initial position it began the casting.
/// Useful for interruption checking
/// </summary>
public class CasterMovedCondition : Condition
{
	public CasterMovedCondition ()
	{
	}

	public override bool Check ()
	{
		return Vector3.Distance (Context.CastBeginPoint, Context.Caster.transform.position) >= Quark.Missile.Missile.NearEnough;
	}
}