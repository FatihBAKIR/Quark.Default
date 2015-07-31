using Quark.Targeting;

namespace Assets.QuarkDefault.TargetMacros
{
    /// <summary>
    /// This macro selects Context.Caster Character
    /// </summary>
    public class CasterPosition : TargetMacro
    {
        public override void Run()
        {
            OnTargetSelected(Context.Source.transform.position);
            OnTargetingSuccess();
        }
    }
}

