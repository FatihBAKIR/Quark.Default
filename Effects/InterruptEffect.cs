using Quark;
using Quark.Spells;

public class InterruptEffect : Effect
{
	public override void Apply (Character target)
	{
		foreach (Cast cast in target.Casts)
			cast.Interrupt ();
	}
}