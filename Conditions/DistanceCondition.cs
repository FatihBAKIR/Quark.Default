using Quark;
using Quark.Conditions;
using Quark.Contexts;
using Quark.Utilities;
using UnityEngine;

namespace Assets.QuarkDefault.Conditions
{
    /// <summary>
    /// This condition checks whether the target point, targetable or character is within a given range of the given point or caster
    /// </summary>
    class DistanceCondition : Condition<IContext>
    {
        private readonly float _range;
        private readonly Vector3 _point;

        private readonly bool _fromCaster;

        Vector3 Point
        {
            get { return _fromCaster ? Context.Source.transform.position : _point; }
        }

        public DistanceCondition(float range)
        {
            _fromCaster = true;
            _range = range;
        }

        public DistanceCondition(float range, Vector3 point)
        {
            _range = range;
            _point = point;
            _fromCaster = false;
        }

        public override bool Check(Character character)
        {
            return Check((Targetable) character);
        }

        public override bool Check(Targetable target)
        {
            return Check(target.transform.position);
        }

        public override bool Check(Vector3 point)
        {
            float dist = Utils.Distance2(point, Point);
            return dist <= _range;
        }
    }
}
