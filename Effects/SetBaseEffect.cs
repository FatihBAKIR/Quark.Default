﻿using Quark;
namespace Assets.QuarkDefault.Effects
{
    class SetBaseEffect : Effect
    {
        private readonly string _tag;
        private readonly float _amount;
        public SetBaseEffect(string tag, float amount)
        {
            _tag = tag;
            _amount = amount;
        }

        public override void Apply(Character target)
        {
            target.GetStat(_tag).SetBase(_amount);
        }
    }
}
