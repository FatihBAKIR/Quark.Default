using Assets.QuarkDefault.Effects;
using Quark;
using Quark.Buffs;

namespace Assets.QuarkDefault.Buffs
{
    class StatBuff : Buff
    {
        private string _tag;
        private Interaction _interaction;

        public StatBuff(string tag, float constant)
            : this(tag, new Interaction { { null, constant } })
        {

        }

        public StatBuff(string tag, Interaction interaction)
        {
            _tag = tag;
            _interaction = interaction;
        }

        void Calculate()
        {
            _amount = _interaction.Calculate(Possessor);
        }

        private float _amount;

        protected override EffectCollection PossessEffects
        {
            get
            {
                Calculate();
                return new EffectCollection
                {
                    new StatEffect(_tag, _amount)
                };
            }
        }

        protected override EffectCollection DoneEffects
        {
            get
            {
                return new EffectCollection
                {
                    new StatEffect(_tag, -_amount)
                };
            }
        }
    }
}
