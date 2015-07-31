using Quark;
using Quark.Buffs;
using Quark.Conditions;
using Quark.Contexts;

namespace Assets.QuarkDefault.Conditions
{
    public class BuffStackCondition
    {
        public static ICondition<T> Create<T>(IBuff<T> buff, int stacks) where T : class, IContext
        {
            return new _BuffStackCondition<T>(buff, stacks);
        }

        private class _BuffStackCondition<T> : Condition<T> where T : class, IContext
        {
            private readonly IBuff<T> _buff;
            private readonly int _stack;

            public _BuffStackCondition(IBuff<T> buff, int stack)
            {
                _buff = buff;
                _stack = stack;
            }

            public override bool Check(Character character)
            {
                _buff.SetContext(Context);
                IBuff fromChar = character.GetBuff(_buff);
                return fromChar != null && fromChar.CurrentStacks >= _stack;
            }
        }
    }
}