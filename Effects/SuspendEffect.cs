using Quark;

namespace Assets.QuarkDefault.Effects
{
    class SuspendEffect : Effect
    {
        public override void Apply(Character target)
        {
            target.Suspend();
        }
    }
}
