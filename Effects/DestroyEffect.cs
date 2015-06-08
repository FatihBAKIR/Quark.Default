using Quark;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    class DestroyEffect : Effect
    {
        public override void Apply(Character target)
        {
            Apply((Targetable) target);
        }

        public override void Apply(Targetable target)
        {
            Object.Destroy(target.gameObject);
        }
    }
}
