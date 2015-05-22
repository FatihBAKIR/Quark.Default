using Quark;
using Quark.Utilities;
using UnityEngine;

namespace Assets.QuarkDefault.Conditions
{
    class LookingAtCondition : Condition
    {
        private float _angle;

        public LookingAtCondition(float angle)
        {
            _angle = angle;
        }

        public override bool Check(Targetable target)
        {
            return Check(target.transform.position);
        }

        public override bool Check(Character character)
        {
            return Check(character.transform.position);
        }

        public override bool Check(Vector3 point)
        {
            Vector3 casterPosition = Context.Caster.transform.position;
            Vector3 casterForward = Context.Caster.transform.forward;
            Vector3 fromToVector = point - casterPosition;

            fromToVector.Normalize();
            casterForward.Normalize();

            float angle = Utils.Angle2(casterForward, fromToVector);

            return angle < _angle && angle > -_angle;
        }
    }
}