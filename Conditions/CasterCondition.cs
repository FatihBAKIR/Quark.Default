using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quark;
using UnityEngine;

namespace Assets.QuarkDefault.Conditions
{
    class CasterCondition : Condition
    {
        private readonly Condition _condition;

        public CasterCondition(Condition condition)
        {
            _condition = condition;
        }

        public override bool Check()
        {
            _condition.SetContext(Context);
            return _condition.Check(Context.Caster);
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
