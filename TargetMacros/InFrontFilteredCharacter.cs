using Assets.QuarkDefault.Conditions;
using Quark;
using Quark.Conditions;
using Quark.Contexts;
using Quark.Targeting;

namespace Assets.QuarkDefault.TargetMacros
{
    class InFrontFilteredCharacter<T>: TargetMacro where T : Condition<IContext>
    {
        private float _range;
        private float _angle;

        private TargetMacro _selector;
        private T _filter;

        public InFrontFilteredCharacter(float range, float angle, T filter)
        {
            _range = range;
            _angle = angle;
            _filter = filter;
        }

        public override void Run()
        {
            _selector = new NearestFilteredTarget<T>(_range, _filter);
            _selector.SetContext(Context);
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
