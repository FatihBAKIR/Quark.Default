using System;
using Quark;

public class DamageEffect : StatEffect
{
    public DamageEffect(Interaction casterInteractions, Interaction targetInteractions) : base("hp", casterInteractions, targetInteractions)
    {
    }

    protected override float CalculateValue(Character of)
    {
        return -base.CalculateValue(of);
    }
}
