using Quark;
using Quark.Buffs;

namespace Assets.QuarkDefault.Conditions
{
    class BuffCondition : Condition
    {
        private Buff _buff;

        public BuffCondition(Buff buff)
        {
            _buff = buff;
        }

        public override bool Check(Character character)
        {
            _buff.SetContext(Context);
            Buff fromChar = character.GetBuff(_buff);
            return fromChar != null;
        }
    }
}
