using Quark;
using Quark.Contexts;
using Quark.Effects;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    class DestroyEffect : Effect<IContext>
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
