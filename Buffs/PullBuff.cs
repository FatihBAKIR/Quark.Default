using Assets.QuarkDefault.Conditions;
using Assets.QuarkDefault.Effects;
using Quark;
using Quark.Buffs;
using UnityEngine;

namespace Assets.QuarkDefault.Buffs
{
    public class PullBuff : Buff
    {
        Vector3 _pullTo;
        Vector3 _movement;
        readonly bool _setToCaster;
        readonly float _speed;

        public PullBuff(float speed = 1)
        {
            Continuous = true;
            Duration = -1;
            _setToCaster = true;
            _speed = speed;
        }

        public PullBuff(Vector3 position, float speed = 1)
        {
            Continuous = true;
            Duration = -1;
            _pullTo = position;
            _movement = CalculateMovement();
            _speed = speed;
        }

        public override void OnPossess()
        {
            if (_setToCaster)
            {
                _pullTo = Context.CastBeginPoint + Context.Caster.transform.forward / 2;
                _movement = CalculateMovement();
            }
        }

        Vector3 CalculateMovement()
        {
            return (_pullTo - Possessor.transform.position).normalized;
        }

        protected override EffectCollection PossessEffects
        {
            get { return new EffectCollection { new TagEffect(QuarkDefault.Tags.Immobile) }; }
        }

        protected override EffectCollection TickEffects
        {
            get
            {
                return new EffectCollection {
                   new TranslateEffect (_movement * Time.deltaTime * _speed)
                };
            }
        }

        protected override EffectCollection DoneEffects
        {
            get { return new EffectCollection { new UntagEffect(QuarkDefault.Tags.Immobile) }; }
        }

        protected override EffectCollection TerminateEffects
        {
            get { return DoneEffects; }
        }

        protected override ConditionCollection DoneConditions
        {
            get
            {
                return new ConditionCollection
                {
                    new DistanceCondition(0.5f, _pullTo)
                };
            }
        }
    }
}