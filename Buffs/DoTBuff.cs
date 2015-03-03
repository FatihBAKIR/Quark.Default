using Quark;

public class DoTBuff : EoTBuff {

	public DoTBuff(Interaction casterInteractions, Interaction targetInteractions, float interval, float duration, float constant = 0) 
		: base(new DamageEffect (casterInteractions, targetInteractions, constant), interval, duration)
	{
	}

	public DoTBuff (float interval, float duration, float constant = 0)
		: base(new DamageEffect (constant), interval, duration)
	{
	}

	public DoTBuff(DamageEffect effect, float interval, float duration) 
		: base(effect, interval, duration)
	{
	}
}
