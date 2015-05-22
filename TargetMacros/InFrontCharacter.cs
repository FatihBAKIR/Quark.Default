using Assets.QuarkDefault.Conditions;
using Quark;
using Quark.Targeting;

namespace Assets.QuarkDefault.TargetMacros
{
    class InFrontCharacter : TargetMacro
    {
        private float _range;
        private float _angle;

        private NearestCharacter _selector;

        public InFrontCharacter(float range, float angle)
        {
            _range = range;
            _angle = angle;
        }

        public override void Run()
        {
            _selector = new NearestCharacter(_range);
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
