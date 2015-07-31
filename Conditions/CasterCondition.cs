using Quark;
using Quark.Conditions;
using Quark.Contexts;
using UnityEngine;

namespace Assets.QuarkDefault.Conditions
{
    public class CasterCondition
    {
        public static ICondition<T> Create<T>(ICondition<T> condition) where T : class, IContext
        {
            return new _CasterCondition<T>(condition);
        }

        private class _CasterCondition<T> : Condition<T> where T : class, IContext
        {
            private readonly ICondition<T> _condition;

            public _CasterCondition(ICondition<T> condition)
            {
                _condition = condition;
            }

            public override bool Check()
            {
                _condition.SetContext(Context);
                return _condition.Check(Context.Source);
            }

            public override bool Check(Character character)
            {
                return Check();
            }

            public override bool Check(Targetable target)
            {
                return Check();
            }

            public override bool Check(Vector3 point)
            {
                return Check();
            }
        }
    }
}
