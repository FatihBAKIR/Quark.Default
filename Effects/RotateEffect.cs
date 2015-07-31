using Quark;
using Quark.Contexts;
using Quark.Effects;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    class RotateEffect : Effect<IContext>
    {
        private readonly Vector3 _rotation;

        public RotateEffect(Vector3 rotation)
        {
            _rotation = rotation;
        }

        public override void Apply(Character target)
        {
            Apply((Targetable)target);
        }

        public override void Apply(Targetable target)
        {
            target.transform.rotation = Quaternion.Euler(_rotation);
            base.Apply(target);
        }
    }
}
