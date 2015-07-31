using Quark;
using Quark.Conditions;
using Quark.Contexts;
using Quark.Targeting;
using UnityEngine;

namespace Assets.QuarkDefault.TargetMacros
{
    class TargetFilter : TargetMacro
    {
        private readonly TargetMacro _macro;
        private readonly ICondition<IContext> _filter;

        public TargetFilter(TargetMacro macro, ICondition<IContext> filter)
        {
            _macro = macro;
            _filter = filter;
        }

        public override void Run()
        {
            _filter.SetContext(Context);

            _macro.SetContext(Context);
            _macro.TargetSelected += MacroOnTargetSelected;
            _macro.PointSelected += MacroOnPointSelected;
            _macro.CharacterSelected += MacroOnCharacterSelected;
            _macro.TargetingFailed += MacroOnTargetingFailed;
            _macro.TargetingSuccess += MacroOnTargetingSuccess;
            _macro.Run();
        }

        private bool _succeeded;

        private void MacroOnTargetingSuccess(TargetCollection targets)
        {
            if (_succeeded)
                OnTargetingSuccess();
            else
                OnTargetingFail(TargetingError.NotFound);

            _macro.TargetSelected -= MacroOnTargetSelected;
            _macro.PointSelected -= MacroOnPointSelected;
            _macro.CharacterSelected -= MacroOnCharacterSelected;
            _macro.TargetingFailed -= MacroOnTargetingFailed;
            _macro.TargetingSuccess -= MacroOnTargetingSuccess;
        }

        private void MacroOnTargetingFailed(TargetingError error)
        {
            OnTargetingFail(error);

            _macro.TargetSelected -= MacroOnTargetSelected;
            _macro.PointSelected -= MacroOnPointSelected;
            _macro.CharacterSelected -= MacroOnCharacterSelected;
            _macro.TargetingFailed -= MacroOnTargetingFailed;
            _macro.TargetingSuccess -= MacroOnTargetingSuccess;
        }

        private void MacroOnCharacterSelected(Character target)
        {
            if (!_filter.Check(target)) return;

            OnTargetSelected(target);
            _succeeded = true;
        }

        private void MacroOnPointSelected(Vector3 target)
        {
            if (!_filter.Check(target)) return;

            OnTargetSelected(target);
            _succeeded = true;
        }

        private void MacroOnTargetSelected(Targetable target)
        {
            if (!_filter.Check(target)) return;

            OnTargetSelected(target);
            _succeeded = true;
        }
    }
}
