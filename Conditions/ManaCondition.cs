namespace Assets.QuarkDefault.Conditions
{
    class ManaCondition : ResourceCondition
    {
        public ManaCondition(float amount) : base("mana", amount) { }
        public ManaCondition(float rate, bool withRate) : base("mana", true, rate) { }
        public ManaCondition(AttributeChecker custom) : base("mana", custom) { }
    }
}
