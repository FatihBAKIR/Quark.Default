using Quark;

namespace Assets.QuarkDefault.Conditions
{
    public class FalseCondition : NegateCondition
    {
        public FalseCondition () : base (new Condition ())
        {
        }
    }
}
