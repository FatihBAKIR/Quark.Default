using Quark;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    class PolymorphEffect : Effect
    {
        private Sprite _sprite;

        /// <summary>
        /// Initializes a polymorph effect to change the sprite of the given Targetable.
        /// Notice that the target needs to have a UnityEngine.SpriteRenderer for this overload
        /// </summary>
        /// <param name="sprite">The sprite to set on the target</param>
        public PolymorphEffect(Sprite sprite)
        {
            _sprite = sprite;
        }

        public override void Apply(Targetable target)
        {
            if (_sprite != null)
            {
                SpriteRenderer renderer = target.GetComponent<SpriteRenderer>();
                renderer.sprite = _sprite;
            }
            base.Apply(target);
        }

        public override void Apply(Character target)
        {
            Apply((Targetable) target);
            base.Apply(target);
        }
    }
}
