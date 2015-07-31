using Quark;
using Quark.Contexts;
using Quark.Effects;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    class MecanimEffect : Effect<IContext>
    {
        private enum MecanimType
        {
            Trigger,
            Float,
            Bool,
            Integer
        };
        private string _id;
        private MecanimType _type;

        private float _valueFloat;
        private bool _valueBool;
        private int _valueInt;

        public MecanimEffect(string id, float value)
        {
            _type = MecanimType.Float;
            _id = id;
            _valueFloat = value;
        }


        public MecanimEffect(string id, int value)
        {
            _type = MecanimType.Integer;
            _id = id;
            _valueInt = value;
        }

        public MecanimEffect(string id, bool value)
        {
            _type = MecanimType.Bool;
            _id = id;
            _valueBool = value;
        }

        public MecanimEffect(string id)
        {
            _type = MecanimType.Trigger;
            _id = id;
        }

        public override void Apply(Character target)
        {
            Animator animator = target.GetComponent<Animator>();
            switch (_type)
            {
                case MecanimType.Integer:
                    animator.SetInteger(_id, _valueInt);
                    break;
                case MecanimType.Float:
                    animator.SetFloat(_id, _valueFloat);
                    break;
                case MecanimType.Trigger:
                    animator.SetTrigger(_id);
                    break;
                case MecanimType.Bool:
                    animator.SetBool(_id, _valueBool);
                    break;
            }
            base.Apply(target);
        }
    }
}
