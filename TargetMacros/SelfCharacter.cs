using Quark;
using Quark.Targeting;

public class SelfCharacter : TargetMacro
{
	public SelfCharacter ()
	{
	}

	public override void Run ()
	{
		OnTargetSelected (Context.Caster);
		OnTargetingSuccess ();
	}
}
	
