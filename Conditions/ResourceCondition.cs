using System;
using Quark;
using Quark.Attributes;
using UnityEngine;
using Attribute = Quark.Attributes.Attribute;

namespace Assets.QuarkDefault.Conditions
{
    internal class ResourceCondition : Condition
    {
        public delegate bool AttributeChecker(Attribute attr);
        private string _tag;
        private float _amount;

        private AttributeChecker _checker;

        /// <summary>
        /// Initializes a resource condition that checks whether the target Characters given Attribute is greater than the given amount
        /// </summary>
        /// <param name="tag">Tag of the attribute</param>
        /// <param name="amount">Amount to check with</param>
        public ResourceCondition(string tag, float amount)
        {
            _tag = tag;
            _amount = amount;
            _checker = Default;
        }

        /// <summary>
        /// Initializes a resource condition that checks whether the target Characters given Attribute is greater than zero 
        /// </summary>
        /// <param name="tag">Tag of the attribute</param>
        public ResourceCondition(string tag)
            : this(tag, 0)
        {
        }

        /// <summary>
        /// Initializes a resource condition that checks whether the target Characters given Stats ratio (value/maximum) is greater than the given rate
        /// </summary>
        /// <param name="tag">Tag of the stat</param>
        /// <param name="percentage">Flag that indicates we should check percentage</param>
        /// <param name="rate">Rate to check with</param>
        public ResourceCondition(string tag, bool percentage, float rate)
            : this(tag, rate)
        {
            _checker = Percentage;
        }

        /// <summary>
        /// Initialize a resource condition with a custom control method
        /// </summary>
        /// <param name="tag">Tag of the stat or the attribute</param>
        /// <param name="custom">The method to be called when checking</param>
        public ResourceCondition(string tag, AttributeChecker custom)
            : this(tag, 0)
        {
            _checker = custom;
        }

        bool Percentage(Attribute attr)
        {
            Stat stat = (Stat)attr;
            if (stat == null)
                throw new Exception("Given Attribute is not a Stat");

            return stat.Rate > _amount;
        }

        bool Default(Attribute attr)
        {
            return attr.Value >= _amount;
        }

        public override bool Check(Character character)
        {
            Attribute attr = character.GetAttribute(_tag);
            return _checker(attr);
        }
    }
}
