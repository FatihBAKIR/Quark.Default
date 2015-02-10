using System;
using Quark.Buff;
using Quark;

public class BuffEffect : Effect
{
    Buff[] buffs;

    public BuffEffect(Buff[] buffsToApply)
    {
        buffs = new Buff[buffsToApply.Length];
        buffsToApply.CopyTo(buffs, 0);
    }

    public override void Apply(Character target)
    {
        foreach (Buff buff in buffs)
        {
			buff.SetContext(_context);
            target.AttachBuff(buff);
        }
        base.Apply(target);
    }
}

