using UnityEngine;
using System.Collections;
using Quark;
using Quark.Buff;

public class DoTBuff : Buff {
	public DoTBuff()
	{
		Interval = 1;
		Duration = 3;
		Behaviour = StackBehavior.ResetBeginning | StackBehavior.IncreaseStacks;
		MaxStacks = 10;
	}

	protected override EffectCollection TickEffects {
		get {
			return new EffectCollection {
				new DamageEffect (10)
			};
		}
	}
}
