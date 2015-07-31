using Quark;
using Quark.Buffs;
using Quark.Contexts;
using Quark.Effects;

namespace Assets.QuarkDefault.Effects
{
    public class BuffEffect
    {
        public static IEffect<T> Create<T>(IBuff<T> buff) where T : class, IContext
        {
            return new _BuffEffect<T>(buff);
        }

        public static IEffect<T> Create<T>(IBuff<T>[] buffs) where T : class, IContext
        {
            return new _BuffEffect<T>(buffs);
        }

        /// <summary>
        /// This effect attaches the given Buff objects to the target Character
        /// </summary>
        class _BuffEffect<T> : Effect<T> where T : class, IContext
        {
            readonly IBuff<T>[] _buffs;

            /// <summary>
            /// Initializes a new instance of the <see cref="BuffEffect"/> class.
            /// </summary>
            /// <param name="buffsToApply">Buffs to attach on Apply time.</param>
            public _BuffEffect(IBuff<T>[] buffsToApply)
            {
                _buffs = new IBuff<T>[buffsToApply.Length];
                buffsToApply.CopyTo(_buffs, 0);
            }

            public _BuffEffect(IBuff<T> buff)
            {
                _buffs = new[] { buff };
            }

            public override void Apply(Character target)
            {
                foreach (IBuff<T> buff in _buffs)
                {
                    buff.SetContext(Context);
                    target.AttachBuff(buff);
                }
            }
        }
    }
}