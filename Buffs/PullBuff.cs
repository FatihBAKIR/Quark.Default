using Assets.QuarkDefault.Conditions;
using Assets.QuarkDefault.Effects;
using Quark;
using Quark.Buffs;
using Quark.Contexts;
using Quark.Effects;
using UnityEngine;

namespace Assets.QuarkDefault.Buffs
{
    public class PullBuff : Buff<ICastContext>
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
                _pullTo = Context.CastBeginPosition + Context.Source.transform.forward / 2;
                _movement = CalculateMovement();
            }
        }

        Vector3 CalculateMovement()
        {
            return (_pullTo - Possessor.transform.position).normalized;
        }

        protected override EffectCollection<ICastContext> PossessEffects
        {
            get
            {
                return new EffectCollection<ICastContext>
                {
                    new TagEffect(QuarkDefault.Tags.Immobile)
                };
            }
        }

        protected override EffectCollection<ICastContext> TickEffects
        {
            get
            {
                return new EffectCollection<ICastContext> {
                   new TranslateEffect (_movement * Time.deltaTime * _speed)
                };
            }
        }

        protected override EffectCollection<ICastContext> DoneEffects
        {
            get
            {
                return new EffectCollection<ICastContext>
                {
                    new UntagEffect(QuarkDefault.Tags.Immobile)
                };
            }
        }

        protected override EffectCollection<ICastContext> TerminateEffects
        {
            get
            {
                return DoneEffects;
            }
        }

        protected override ConditionCollection<ICastContext> DoneConditions
        {
            get
            {
                return new ConditionCollection<ICastContext>
                {
                    new DistanceCondition(0.5f, _pullTo)
                };
            }
        }
    }
}