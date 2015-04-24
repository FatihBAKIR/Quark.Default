using AssemblyCSharpvs;
using Quark.Spells;
using Quark.Targeting;
using Quark;

namespace Assets.QuarkDefault.Spells
{
    class Meditate : Spell
    {
        public Meditate()
        {
            CastingInterval = 1;
        }

        public override TargetMacro TargetMacro
        {
            get
            {
                return new SelfCharacter();
            }
        }

        public override float CastDuration
        {
            get
            {
                return 5;
            }
        }

        protected override EffectCollection CastingEffects
        {
            get
            {
                return new EffectCollection
                    {
                        new CasterEffect(new HealEffect(10))
                    };
            }
        }
    }
}
