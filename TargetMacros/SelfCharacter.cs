using Quark.Targeting;

namespace Assets.QuarkDefault.TargetMacros
{
    /// <summary>
    /// This macro selects Context.Caster Character
    /// </summary>
    public class SelfCharacter : TargetMacro
    {
        public override void Run ()
        {
            OnTargetSelected (Context.Source);
            OnTargetingSuccess ();
        }
    }
}
	
