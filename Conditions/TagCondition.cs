using UnityEngine;
using System.Collections;
using Quark;

public class TagCondition : Condition
{
    private readonly string _tag;

    public TagCondition(string tag)
    {
        _tag = tag;
    }

    public override bool Check(Character character)
    {
        return Check((Targetable)character);
    }

    public override bool Check(Targetable targetable)
    {
        return targetable.IsTagged(_tag);
    }
}
