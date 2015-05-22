using Quark;
using Quark.Targeting;
using UnityEngine;

namespace Assets.QuarkDefault.TargetMacros
{
    class NearestFilteredTarget : TargetMacro
    {
        protected Vector3 _point;
        protected float _range;
        protected bool _nearCaster;
        private readonly Condition _filter;
        
        public NearestFilteredTarget (float range, Condition filter)
        {
            _filter = filter;
            _range = range;
            _nearCaster = true;
        }

        public NearestFilteredTarget(Vector3 point, float range, Condition filter)
        {
            _filter = filter;
            _point = point;
            _range = range;
        }

        protected virtual Character ClosestCharacter ()
        {
            Collider[] closeObjects = Physics.OverlapSphere (_point, _range);

            float nearestDistance = _range * 10;
            Character nearest = null;
            _filter.SetContext(Context);

            foreach (Collider obj in closeObjects)
            {
                Character tmp = obj.GetComponent<Character>();
                if (tmp == null || tmp.Identifier == Caster.Identifier || !tmp.IsTargetable || tmp.IsSuspended)
                    continue;
                if (!_filter.Check(tmp)) 
                    continue;

                float dist = Vector3.Distance (obj.gameObject.transform.position, _point);
                if (dist < nearestDistance) {
                    nearest = tmp;
                    nearestDistance = dist;
                }
            }

            return nearest;
        }

        public override void Run ()
        {
            if (_nearCaster)
                _point = Caster.transform.position;

            Character closest = ClosestCharacter ();
            if (closest != null) {
                OnTargetSelected (closest);
                OnTargetingSuccess ();
            } else {
                OnTargetingFail (TargetingError.NotFound);
            }
        }
    }
}
