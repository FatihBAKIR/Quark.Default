using System;
using Quark;
using UnityEngine;

public class ConditionalEffect : Effect
{
    Condition _condition;
    Effect _effect;

    public ConditionalEffect(Condition condition, Effect effect)
    {
        _condition = condition;
        _effect = effect;
    }

    public override void Apply()
	{
        _condition.SetContext (_context);
        _effect.SetContext(_context);

 		if (_condition.Check())
            _effect.Apply();
    }

    public override void Apply(Vector3 point)
	{
        _condition.SetContext (_context);
        _effect.SetContext(_context);

        if (_condition.Check(point))
            _effect.Apply(point);
    }

    public override void Apply(Targetable target)
	{
        _condition.SetContext (_context);
        _effect.SetContext(_context);

        if (_condition.Check(target))
            _effect.Apply(target);
    }

    public override void Apply(Character target)
    {
        _condition.SetContext (_context);
        _effect.SetContext(_context);

        if (_condition.Check(target))
            _effect.Apply(target);
    }
}