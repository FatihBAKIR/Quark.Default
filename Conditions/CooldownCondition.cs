using Quark;
using Quark.Conditions;
using Quark.Contexts;

namespace Assets.QuarkDefault.Conditions
{
    class CooldownCondition : Condition<ICastContext>
    {
        private bool _fromContext;
        private string _cooldownTag;

        public CooldownCondition()
        {
            _fromContext = true;
            _cooldownTag = "";
        }

        public CooldownCondition(string tag)
        {
            _fromContext = false;
            _cooldownTag = tag;
        }

        public override bool Check(Character character)
        {
            var tag = (_fromContext ? Context.Spell.Identifier : _cooldownTag) + ".Cooldown";
            var check = NegateCondition.Create(new TagCondition(tag));
            return check.Check(character);
        }
    }
}
