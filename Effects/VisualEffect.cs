using Quark;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    class VisualEffect : Effect
    {
        private GameObject _obj;
        private Vector3 _offset;

        public VisualEffect(string resourcePath, Vector3 offset)
        {
            _obj = Resources.Load<GameObject>(resourcePath);
            _offset = offset;
        }

        public override void Apply(Vector3 point)
        {
            GameObject go = ((GameObject) Object.Instantiate(_obj, point + _offset, Quaternion.Euler(0, 270, 0)));
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
