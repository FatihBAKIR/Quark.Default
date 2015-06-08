using Quark;
using Quark.Buffs;

namespace Assets.QuarkDefault.Effects
{
    class BuffTerminateEffect : Effect
    {
        private readonly Buff _toTerminate;

        public BuffTerminateEffect(Buff buff)
        {
            _toTerminate = buff;
        }

        public override void Apply(Character target)
        {
            target.GetBuff(_toTerminate).Terminate();
        }
    }
}
