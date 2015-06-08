using Quark;

namespace Assets.QuarkDefault.Conditions
{
    class CooldownCondition : Condition
    {
        public override bool Check(Character character)
        {
            string tag = Context.Spell.Identifier + ".Cooldown";
            Condition check = new NegateCondition(new TagCondition(tag));
            return check.Check(character);
        }
    }
}
