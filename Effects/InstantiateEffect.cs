using Quark;
using Quark.Contexts;
using Quark.Effects;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    public class InstantiateEffect : Effect<IContext>
    {
        readonly GameObject _object;
        readonly Vector3 _offset;

        public float DestroyAfter { get; set; }

        public InstantiateEffect(GameObject obj, Vector3 offset = new Vector3())
        {
            _object = obj;
            _offset = offset;
        }

        public override void Apply(Vector3 point)
        {
            Object o = Object.Instantiate(_object, point + _offset, Quaternion.identity);
            if (DestroyAfter > 0)
                Object.Destroy(o, DestroyAfter);
        }

        public override void Apply(Character target)
        {
            GameObject o = Object.Instantiate(_object, target.transform.position + _offset, Quaternion.identity) as GameObject;
            o.transform.parent = target.transform;
            if (DestroyAfter > 0)
                Object.Destroy(o, DestroyAfter);
        }
    }
}