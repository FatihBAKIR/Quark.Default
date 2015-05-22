using Quark;
using Quark.Spells;

namespace Assets.QuarkDefault.Conditions
{
    public class NegateCondition : Condition
    {
        Condition _cond;

        public NegateCondition (Condition toNegate)
        {
            _cond = toNegate;
        }

        public override bool Check ()
        {
            return !_cond.Check ();
        }

        public override bool Check (Character character)
        {
            return !_cond.Check (character);
        }

        public override bool Check (Targetable target)
        {
            return !_cond.Check (target);
        }

        public override bool Check (UnityEngine.Vector3 point)
        {
            return !_cond.Check (point);
        }

        public override void SetContext (Cast context)
        {
            base.SetContext (context);
            _cond.SetContext (context);
        }
    }
}
