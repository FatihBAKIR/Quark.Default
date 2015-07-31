using Quark;
using Quark.Contexts;
using Quark.Effects;
using Quark.Targeting;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    /// <summary>
    /// This effect applies the given Effect to the targets acquired from the given TargetMacro.
    /// 
    /// Notice that the given TargetMacro must implement an implicit targeting logic.
    /// 
    /// Targets acquired by this effect don't become a part of the context of this effect.
    /// 
    /// This is a one time effect.
    /// </summary>
    class TargetRelayEffect
    {
        public static IEffect<T> Create<T>(TargetMacro macro, IEffect<T> effect) where T : class, IContext
        {
            return new _TargetRelayEffect<T>(macro, effect);
        }

        class _TargetRelayEffect<T> : Effect<IContext> where T : class, IContext
        {
            private TargetMacro _macro;
            private IEffect<T> _effect;

            public _TargetRelayEffect(TargetMacro macro, IEffect<T> effect)
            {
                _effect = effect;
                _macro = macro;
            }

            void RunMacro()
            {
                _macro.SetContext(Context);
                _macro.TargetingSuccess += _macro_TargetingSuccess;
                _macro.Run();

                _macro.TargetingSuccess -= _macro_TargetingSuccess;
                _macro.SetContext(null);
            }

            void _macro_TargetingSuccess(TargetCollection targets)
            {
                new EffectCollection<T>
            {
                _effect
            }
                .Run(targets);
            }

            private bool _hasApplied;
            public override void Apply()
            {
                if (_hasApplied)
                    return;

                _hasApplied = true;
                RunMacro();
            }

            public override void Apply(Character target)
            {
                Apply();
            }

            public override void Apply(Targetable target)
            {
                Apply();
            }

            public override void Apply(Vector3 point)
            {
                Apply();
            }
        }
    }
}
