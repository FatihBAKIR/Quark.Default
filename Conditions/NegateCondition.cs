using Quark;
using Quark.Conditions;
using Quark.Contexts;
using Quark.Spells;

namespace Assets.QuarkDefault.Conditions
{
    public class NegateCondition
    {
        public static ICondition<T> Create<T>(ICondition<T> condition) where T : class, IContext
        {
            return new _NegateCondition<T>(condition);
        }

        class _NegateCondition<T> : Condition<T> where T : class, IContext
        {
            private ICondition<T> _cond;

            public _NegateCondition(ICondition<T> toNegate)
            {
                _cond = toNegate;
            }

            public override bool Check()
            {
                return !_cond.Check();
            }

            public override bool Check(Character character)
            {
                return !_cond.Check(character);
            }

            public override bool Check(Targetable target)
            {
                return !_cond.Check(target);
            }

            public override bool Check(UnityEngine.Vector3 point)
            {
                return !_cond.Check(point);
            }

            public override void SetContext(IContext context)
            {
                base.SetContext(context);
                _cond.SetContext(context);
            }
        }
    }
}
