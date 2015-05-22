using Assets.QuarkDefault.Conditions;
using Assets.QuarkDefault.Effects;
using Quark;
using Quark.Buffs;
using UnityEngine;

namespace Assets.QuarkDefault.Buffs
{
    class MoveToBuff: Buff
    {
        protected Vector3 Destination;
        protected float Speed;

        public MoveToBuff()
        {
            
        }

        public MoveToBuff(Vector3 towards, float speed)
        {
            Destination = towards;
            Speed = speed;
        }

        Vector3 Movement
        {
            get { return (Destination - Possessor.transform.position + new Vector3(0,1,0)).normalized; }
        }

        protected override EffectCollection TickEffects
        {
            get
            {
                return new EffectCollection
                {
                    new TranslateEffect(Movement * Time.deltaTime * Speed)
                };
            }
        }

        protected override ConditionCollection DoneConditions
        {
            get
            {
                return new ConditionCollection
                {
                    new DistanceCondition(0.3f, Destination)
                };
            }
        }
    }
}
