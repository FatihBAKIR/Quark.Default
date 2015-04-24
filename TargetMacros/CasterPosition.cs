using Quark.Targeting;

/// <summary>
/// This macro selects Context.Caster Character
/// </summary>
public class CasterPosition : TargetMacro
{
    public override void Run()
    {
        OnTargetSelected(Context.Caster.transform.position);
        OnTargetingSuccess();
    }
}

