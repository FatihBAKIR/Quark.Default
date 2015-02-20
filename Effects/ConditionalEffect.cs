using System;
using Quark;
using UnityEngine;

/// <summary>
/// This effect lets you apply an effect conditionally on Apply time.
/// </summary>
public class ConditionalEffect : Effect
{
	Condition _condition;
	Effect _onTrue;
	Effect _onFalse;

	public ConditionalEffect (Condition condition, Effect ontrue, Effect onfalse = null)
	{
		_condition = condition;
		_onTrue = ontrue;
		_onFalse = onfalse;
	}

	public override void Apply ()
	{
		_condition.SetContext (Context);
		_onTrue.SetContext (Context);

		if (_condition.Check ())
			_onTrue.Apply ();
		else if (_onFalse != null)
			_onFalse.Apply ();
	}

	public override void Apply (Vector3 point)
	{
		_condition.SetContext (Context);
		_onTrue.SetContext (Context);

		if (_condition.Check (point))
			_onTrue.Apply (point);
		else if (_onFalse != null)
			_onFalse.Apply (point);
	}

	public override void Apply (Targetable target)
	{
		_condition.SetContext (Context);
		_onTrue.SetContext (Context);

		if (_condition.Check (target))
			_onTrue.Apply (target);
		else if (_onFalse != null)
			_onFalse.Apply (target);
	}

	public override void Apply (Character target)
	{
		_condition.SetContext (Context);
		_onTrue.SetContext (Context);
       
		if (_condition.Check (target))
			_onTrue.Apply (target);
		else if (_onFalse != null)
			_onFalse.Apply (target);
	}
}