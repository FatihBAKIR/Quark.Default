using Quark;
using Quark.Buffs;
using Quark.Contexts;
using Quark.Effects;

namespace Assets.QuarkDefault.Effects
{
    public class BuffTerminateEffect
    {
        public static IEffect<T> Create<T>(IBuff<T> buff) where T : class, IContext
        {
            return new _BuffTerminateEffect<T>(buff);
        }

        private class _BuffTerminateEffect<T> : Effect<T> where T : class, IContext
        {
            private readonly IBuff<T> _toTerminate;

            public _BuffTerminateEffect(IBuff<T> buff)
            {
                _toTerminate = buff;
            }

            public override void Apply(Character target)
            {
                _toTerminate.SetContext(Context);
                IBuff buff = target.GetBuff(_toTerminate);
                if (buff != null)
                    buff.Terminate();
            }
        }
    }
}
