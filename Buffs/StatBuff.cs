using Assets.QuarkDefault.Effects;
using Quark;
using Quark.Buffs;
using Quark.Contexts;
using Quark.Effects;

namespace Assets.QuarkDefault.Buffs
{
    class StatBuff : Buff<IContext>
    {
        private string _tag;
        private Interaction _interaction;
        private float _amount;

        public StatBuff(string tag, float constant, float duration)
            : this(tag, new Interaction { { null, constant } }, duration)
        {
        }

        public StatBuff(string tag, Interaction interaction, float duration)
        {
            _tag = tag;
            _interaction = interaction;
            Duration = duration;
            Interval = 100000;
        }

        void Calculate()
        {
            _amount = _interaction.Calculate(Possessor);
        }

        protected override EffectCollection<IContext> PossessEffects
        {
            get
            {
                Calculate();
                return new EffectCollection<IContext>
                {
                    new StatEffect(_tag, _amount)
                };
            }
        }

        protected override EffectCollection<IContext> DoneEffects
        {
            get
            {
                return new EffectCollection<IContext>
                {
                    new StatEffect(_tag, -_amount)
                };
            }
        }
    }
}
