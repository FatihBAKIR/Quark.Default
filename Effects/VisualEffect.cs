using Quark;
using Quark.Contexts;
using Quark.Effects;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    class VisualEffect : Effect<IContext>
    {
        private readonly GameObject _obj;
        private readonly Vector3 _offset;
        private readonly Quaternion _quaternion;

        public VisualEffect(string resourcePath)
        {
            _obj = Resources.Load<GameObject>(resourcePath);
            _offset = Vector3.zero;
            _quaternion = Quaternion.identity;
        }

        public VisualEffect(string resourcePath, Vector3 offset)
        {
            _obj = Resources.Load<GameObject>(resourcePath);
            _offset = offset;
            _quaternion = Quaternion.identity;
        }

        public VisualEffect(string resourcePath, Vector3 offset, Quaternion rotation)
        {
            _obj = Resources.Load<GameObject>(resourcePath);
            _offset = offset;
            _quaternion = rotation;
        }

        public override void Apply(Vector3 point)
        {
            GameObject go = ((GameObject) Object.Instantiate(_obj, point + _offset, _quaternion));
            base.Apply(point);
        }

        public override void Apply(Targetable target)
        {
            Apply(target.transform.position);
            base.Apply(target);
        }

        public override void Apply(Character target)
        {
            Apply(target.transform.position);
            base.Apply(target);
        }
    }
}
