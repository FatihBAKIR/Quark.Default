using UnityEngine;
using System.Collections;
using Quark;

/// <summary>
/// Stat effect.
/// This effect manipulates one of the given target Characters stat
/// </summary>
public class StatEffect : Effect
{
    string _tag;
    Interaction _casterInteractions;
    Interaction _targetInteractions;

    public StatEffect(string StatTag)
    {
        _tag = StatTag;
    }

    public StatEffect(string StatTag, Interaction casterInteractions, Interaction targetInteractions)
    {
        _tag = StatTag;
        _casterInteractions = casterInteractions;
        _targetInteractions = targetInteractions;
    }

    protected override string Name
    {
        get
        {
            return "Stat Effect";
        }
    }

    protected virtual float CalculateValue(Character of)
    {
        float casterVal = _casterInteractions.Calculate(_context.Caster);
		float targetVal = _targetInteractions.Calculate(of);

        return casterVal + targetVal;
    }

    public override void Apply(Character target)
    {
        float change = 0;
        change += CalculateValue(target);

        target.GetStat(_tag).Manipulate(change);
    }
}
