using Quark.Targeting;
using UnityEngine;

namespace Assets.QuarkDefault.TargetMacros
{
    class CasterForward : TargetMacro
    {
        private float _range;

        public CasterForward(float range)
        {
            _range = range;
        }

        public override void Run()
        {
            Vector3 forward = Caster.transform.forward * _range + Caster.transform.position;

            forward.y = 0;

            OnTargetSelected(forward);
            OnTargetingSuccess();
        }
    }
}
