using Assets.QuarkDefault.Buffs;
using Assets.QuarkDefault.Effects;
using Quark;

namespace Assets.QuarkDefault.Items
{
    class Boots : Item
    {
        protected override EffectCollection GrabEffects
        {
            get { return new EffectCollection
            {
                new BuffEffect(new StatBuff("ms", 2, 10))
            }; }
        }
    }
}
