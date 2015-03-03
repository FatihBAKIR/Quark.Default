﻿using Quark.Targeting;

/// <summary>
/// This macro selects Context.Caster Character
/// </summary>
public class SelfCharacter : TargetMacro
{
	public override void Run ()
	{
		OnTargetSelected (Context.Caster);
		OnTargetingSuccess ();
	}
}
	