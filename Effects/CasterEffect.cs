using Quark;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{   
    /// <summary>
    /// This effect applies the given effect on the Caster of its context for once no matter how it is originally applied
    /// </summary>
    class CasterEffect : Effect
    {
        private byte _applyCount;
        private readonly Effect _effect;

        public CasterEffect(Effect effect)
        {
            _effect = effect;
        }

        public override void Apply()
        {
            Apply((Character)null);
        }

        public override void Apply(Targetable target)
        {
            Apply((Character)null);
        }

        public override void Apply(Vector3 point)
        {
            Apply((Character)null);
        }

        public override void Apply(Character target)
        {
            if (_applyCount > 0)
                return;
            _applyCount++;
            _effect.SetContext(Context);
            _effect.Apply(Context.Caster);
        }
    }
}