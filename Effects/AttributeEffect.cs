﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quark;

namespace Assets.QuarkDefault.Effects
{
    class AttributeEffect : Effect
    {
        private string _tag;
        private Interaction _casterInteraction, _targetInteraction;

        public AttributeEffect(string tag, Interaction caster, Interaction target)
        {
            _tag = tag;
            _casterInteraction = caster;
            _targetInteraction = target;
        }

        public AttributeEffect(string tag, float constant)
            : this(tag, new Interaction { {null, constant} }, new Interaction())
        {
            
        }

        protected virtual float CalculateValue(Character of)
        {
            float casterVal = _casterInteraction == null ? 0 : _casterInteraction.Calculate(Context.Caster);
            float targetVal = _targetInteraction == null ? 0 : _targetInteraction.Calculate(of);
            
            return casterVal + targetVal;
        }

        public override void Apply(Character target)
        {
            throw new NotImplementedException();
            float change = 0;
            change += CalculateValue(target);

            target.GetAttribute(_tag).SetBase(change);
            new EffectArgs(this, target).Broadcast();
        }
    }
}