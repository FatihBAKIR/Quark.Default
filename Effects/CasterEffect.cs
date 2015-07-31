using Quark;
using Quark.Contexts;
using Quark.Effects;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{   
    /// <summary>
    /// This effect applies the given effect on the Caster of its context for once no matter how it is originally applied
    /// </summary>
    class CasterEffect
    {
        public static IEffect<T> Create<T>(IEffect<T> effect) where T : class, IContext
        {
            return new _CasterEffect<T>(effect);
        }

        class _CasterEffect<T> : Effect<T> where T : class, IContext
        {
            private byte _applyCount;
            private readonly IEffect<T> _effect;

            public _CasterEffect(IEffect<T> effect)
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
                _effect.Apply(Context.Source);
            }
        }
    }
}