﻿using Quark;
using Quark.Buffs;

/// <summary>
/// This effect attaches the given Buff objects to the target Character
/// </summary>
public class BuffEffect : Effect
{
    readonly Buff[] _buffs;

	/// <summary>
	/// Initializes a new instance of the <see cref="BuffEffect"/> class.
	/// </summary>
	/// <param name="buffsToApply">Buffs to attach on Apply time.</param>
	public BuffEffect (Buff[] buffsToApply)
	{
		_buffs = new Buff[buffsToApply.Length];
		buffsToApply.CopyTo (_buffs, 0);
	}

	public BuffEffect (Buff buff)
	{
		_buffs = new[] { buff };
	}

	public override void Apply (Character target)
	{
		foreach (Buff buff in _buffs) {
			buff.SetContext (Context);
			target.AttachBuff (buff);
		}
		new EffectArgs (this, target).Broadcast ();
	}
}

