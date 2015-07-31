using Quark;
using Quark.Contexts;
using Quark.Effects;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    public class TranslateEffect : Effect<IContext>
    {
        readonly Vector3 _movement;
        public TranslateEffect (Vector3 movement)
        {
            _movement = movement;
        }

        public override void Apply (Targetable target)
        {
            target.transform.position += _movement;
        }

        public override void Apply (Character target)
        {
            Apply ((Targetable)target);
        }
    }
}
