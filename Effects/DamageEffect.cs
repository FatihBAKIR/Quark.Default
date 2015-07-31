using Quark;

namespace Assets.QuarkDefault.Effects
{
    public class DamageEffect : StatEffect
    {
        public DamageEffect(Interaction casterInteractions, Interaction targetInteractions, float constant = 0) : base(QuarkDefault.Tags.Attributes.Health, casterInteractions, targetInteractions, constant)
        {
        }

        public DamageEffect(float constant) : base (QuarkDefault.Tags.Attributes.Health, constant)
        {
        }

        protected override float CalculateValue(Character of)
        {
            return -base.CalculateValue(of);
        }

        public override void Apply(Character target)
        {
            if (target.IsTagged(QuarkDefault.Tags.Invulnerable))
                return;

            base.Apply(target);
        }
    }
}
