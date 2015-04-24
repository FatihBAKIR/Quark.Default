using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quark;
using UnityEngine;

namespace Assets.QuarkDefault.Spells
{
    class MecanimEffect : Effect
    {
        private enum MecanimType
        {
            Trigger,
            Float
        };
        private string _id;
        private MecanimType _type;

        private float _valueFloat;

        public MecanimEffect(string id, float value)
        {
            _type = MecanimType.Float;
            _id = id;
            _valueFloat = value;
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
                case MecanimType.Float:
                    animator.SetFloat(_id, _valueFloat);
                    break;
                case MecanimType.Trigger:
                    animator.SetTrigger(_id);
                    break; ;
            }
            base.Apply(target);
        }
    }
}
