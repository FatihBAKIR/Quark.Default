using Quark;
using Quark.Buffs;
using Quark.Conditions;
using Quark.Contexts;

namespace Assets.QuarkDefault.Conditions
{
    public class BuffCondition
    {
        public static ICondition<T> Create<T>(IBuff<T> buff) where T : class, IContext
        {
            return new _BuffCondition<T>(buff);
        }

        private class _BuffCondition<T> : Condition<T> where T : class, IContext
        {
            private IBuff<T> _buff;

            public _BuffCondition(IBuff<T> buff)
            {
                _buff = buff;
            }

            public override bool Check(Character character)
            {
                _buff.SetContext(Context);
                IBuff fromChar = character.GetBuff(_buff);
                return fromChar != null;
            }
        }
    }
}
