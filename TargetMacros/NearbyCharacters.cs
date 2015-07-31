using System.Collections.Generic;
using Quark;
using Quark.Targeting;
using UnityEngine;

namespace Assets.QuarkDefault.TargetMacros
{
    /// <summary>
    /// This macro selects every targetable Character within a given radius around a point or the Caster
    /// </summary>
    public class NearbyCharacters : TargetMacro
    {
        protected Vector3 _point;
        protected float _range;
        protected bool _nearCaster;

        public NearbyCharacters(float range) : base()
        {
            _range = range;
            _nearCaster = true;
        }

        public NearbyCharacters (Vector3 point, float range)
        {
            _point = point;
            _range = range;
        }

        protected virtual Character[] ClosestCharacters ()
        {
            Collider[] closeObjects = Physics.OverlapSphere (_point, _range);

            List<Character> chars = new List<Character> ();

            foreach (Collider obj in closeObjects) {
                if (obj.GetComponent<Character> () == null)
                    continue;
                if (chars.Contains(obj.GetComponent<Character>()))
                    continue;
                if (obj.gameObject.Equals(Caster.gameObject))
                    continue;
                
                chars.Add (obj.GetComponent<Character> ());
            }

            return chars.ToArray ();
        }

        public override void Run ()
        {
            if (_nearCaster)
                _point = Context.Source.transform.position;
            foreach (Character target in ClosestCharacters())
                OnTargetSelected (target);
            OnTargetingSuccess ();
        }
    }
}
