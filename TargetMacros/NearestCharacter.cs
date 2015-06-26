using Quark;
using Quark.Targeting;
using Quark.Utilities;
using UnityEngine;

namespace Assets.QuarkDefault.TargetMacros
{
    /// <summary>
    /// This macro seleccts the nearest targetable Character within a given radius around a point or the Caster
    /// </summary>
    public class NearestCharacter : TargetMacro
    {
        protected Vector3 _point;
        protected float _range;
        protected bool _nearCaster;

        public NearestCharacter (float range)
        {
            _range = range;
            _nearCaster = true;
        }

        public NearestCharacter (Vector3 point, float range)
        {
            _point = point;
            _range = range;
        }

        protected virtual Character ClosestCharacter ()
        {
            Collider[] closeObjects = Physics.OverlapSphere (_point, _range);

            float nearestDistance = _range * 10;
            Character nearest = null;
            foreach (Collider obj in closeObjects)
            {
                Character tmp = obj.GetComponent<Character>();
                if (tmp == null || tmp.Identifier == Caster.Identifier || !tmp.IsTargetable || tmp.IsSuspended)
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
            {
                Logger.Assert(Context != null);
                _point = Caster.transform.position;
            }

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

