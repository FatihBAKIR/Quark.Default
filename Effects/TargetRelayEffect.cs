using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quark;
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
    class TargetRelayEffect : Effect
    {
        private TargetMacro _macro;
        private Effect _effect;

        public TargetRelayEffect(TargetMacro macro, Effect effect)
        {
            _effect = effect;
            _macro = macro;
        }

        void RunMacro()
        {
            _macro.SetContext(Context, true);
            _macro.TargetingSuccess += _macro_TargetingSuccess;
            _macro.Run();

            _macro.TargetingSuccess -= _macro_TargetingSuccess;
            _macro.SetContext(null, true);
        }

        void _macro_TargetingSuccess(TargetCollection targets)
        {
            new EffectCollection
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
