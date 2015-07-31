using Quark;
using Quark.Conditions;
using Quark.Contexts;
using UnityEngine;

namespace Assets.QuarkDefault.Conditions
{
    public class FalseCondition : Condition<IContext>
    {
        public override bool Check()
        {
            return false;
        }

        public override bool Check(Character character)
        {
            return false;
        }

        public override bool Check(Vector3 point)
        {
            return false;
        }

        public override bool Check(Targetable target)
        {
            return false;
        }
    }
}
