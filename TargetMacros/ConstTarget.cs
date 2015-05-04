using Quark;
using Quark.Targeting;
using UnityEngine;

namespace Assets.Quark.TargetMacros
{
    class ConstTarget : TargetMacro
    {
        private readonly TargetUnion _target;

        public ConstTarget(Character target)
        {
            _target = new TargetUnion(target);
        }

        public ConstTarget(Targetable target)
        {
            _target = new TargetUnion(target);
        }

        public ConstTarget(Vector3 target)
        {
            _target = new TargetUnion(target);
        }

        public override void Run()
        {
            switch (_target.Type)
            {
                case TargetType.Point:
                    OnTargetSelected(_target.Point);
                    break;
                case TargetType.Character:
                    OnTargetSelected(_target.Character);
                    break;
                case TargetType.Targetable:
                    OnTargetSelected(_target.Targetable);
                    break;
            }
            OnTargetingSuccess();
            base.Run();
        }
    }
}
