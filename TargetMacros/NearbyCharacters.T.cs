using System.Collections.Generic;
using Quark;
using UnityEngine;

namespace Assets.QuarkDefault.TargetMacros
{
    public class NearbyCharacters<T> : NearbyCharacters where T : MonoBehaviour
    {
        public NearbyCharacters(Vector3 point, float range)
            : base(point, range)
        {
        }

        protected override Character[] ClosestCharacters()
        {
            Collider[] closeObjects = Physics.OverlapSphere(_point, _range);

            List<Character> chars = new List<Character>();

            foreach (Collider obj in closeObjects)
            {
                if (obj.GetComponent<Character>() == null)
                    continue;
                if (obj.GetComponent<T>() == null)
                    continue;
                if (!obj.GetComponent<Character>().IsTargetable)
                    continue;
                if (obj.GetComponent<Character>().IsSuspended)
                    continue;
                chars.Add(obj.GetComponent<Character>());
            }

            return chars.ToArray();
        }
    }
}