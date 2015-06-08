using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.QuarkDefault.Conditions;
using Quark;
using Quark.Targeting;

namespace Assets.QuarkDefault.TargetMacros
{
    class InFrontFilteredCharacter: TargetMacro
    {
        private float _range;
        private float _angle;

        private TargetMacro _selector;
        private Condition _filter;

        public InFrontFilteredCharacter(float range, float angle, Condition filter)
        {
            _range = range;
            _angle = angle;
            _filter = filter;
        }

        public override void Run()
        {
            _selector = new NearestFilteredTarget(_range, _filter);
            _selector.SetContext(Context, true);
            _selector.TargetingSuccess += delegate(TargetCollection targets)
            {
                LookingAtCondition isLooking = new LookingAtCondition(_angle);
                isLooking.SetContext(Context);
                if (isLooking.Check(targets.FirstCharacter))
                {
                    OnTargetSelected(targets.FirstCharacter);
                    OnTargetingSuccess();
                }
                else
                    OnTargetingFail(TargetingError.NotFound);
            };

            _selector.TargetingFailed += OnTargetingFail;
            _selector.Run();
        }
    }
}
