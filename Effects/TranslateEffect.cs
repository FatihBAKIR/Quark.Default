using Quark;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    public class TranslateEffect : Effect
    {
        readonly Vector3 _movement;
        public TranslateEffect (Vector3 movement)
        {
            _movement = movement;
        }

        public override void Apply (Targetable target)
        {
            //Debug.DrawLine(target.transform.position, target.transform.position + _movement.normalized);
            target.transform.position += _movement;
            //target.transform.Translate (_movement);
        }

        public override void Apply (Character target)
        {
            Apply ((Targetable)target);
        }
    }
}
