using Quark;
using Quark.Spell;

public class InterruptEffect : Effect
{
	public InterruptEffect ()
	{
	}

	public override void Apply (Character target)
	{
		foreach (Cast cast in target.Casts)
			cast.Interrupt ();
	}
}