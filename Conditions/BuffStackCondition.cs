using Quark;
using Quark.Buffs;

namespace Assets.QuarkDefault.Conditions
{
    class BuffStackCondition : Condition
    {
        private readonly Buff _buff;
        private readonly int _stack;

        public BuffStackCondition(Buff buff, int stack)
        {
            _buff = buff;
            _stack = stack;
        }

        public override bool Check(Character character)
        {
            _buff.SetContext(Context);
            Buff fromChar = character.GetBuff(_buff);
            return fromChar != null && fromChar.CurrentStacks >= _stack;
        }
    }
}