using System;
using Quark;

public class DamageEffect : StatEffect
{
	public DamageEffect(Interaction casterInteractions, Interaction targetInteractions, float constant = 0) : base("hp", casterInteractions, targetInteractions, constant)
	{
	}

	public DamageEffect(float constant) : base ("hp", constant)
	{
	}

    protected override float CalculateValue(Character of)
    {
        return -base.CalculateValue(of);
    }
}
