using Quark;
using Quark.Attributes;
using Quark.Contexts;
using Quark.Effects;

namespace Assets.QuarkDefault.Characters
{
    public class DyingCharacter : Character
    {
        protected override void Configure()
        {
            base.Configure();
            StatManipulated += Zombie_StatManipulated;
        }

        private void Zombie_StatManipulated(Character source, Stat stat, float change)
        {
            if (stat.Tag == QuarkDefault.Tags.Attributes.Health && stat.Rate == 0)
                OnDeath();
        }

        protected virtual void OnDeath()
        {
            Character self = this;
            DyingEffects.Run((Character)self, null);
        }

        protected virtual EffectCollection<IContext> DyingEffects
        {
            get { return new EffectCollection<IContext>(); }
        }
    }
}
