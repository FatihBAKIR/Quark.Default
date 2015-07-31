using Assets.QuarkDefault.Conditions;
using Assets.QuarkDefault.Effects;
using Quark;
using Quark.Buffs;
using Quark.Contexts;
using Quark.Effects;
using UnityEngine;

namespace Assets.QuarkDefault.Buffs
{
    class MoveToBuff: Buff<IContext>
    {
        protected Vector3 Destination;
        protected float Speed;

        public MoveToBuff()
        {
            Duration = 1;
        }

        public MoveToBuff(Vector3 towards, float speed)
        {
            Duration = 1;
            Destination = towards;
            Speed = speed;
        }

        Vector3 Movement
        {
            get { return (Destination - Possessor.transform.position + new Vector3(0,0.25f,0)); }
        }

        protected override EffectCollection<IContext> TickEffects
        {
            get
            {
                return new EffectCollection<IContext>
                {
                    new TranslateEffect(Movement * Time.deltaTime * Speed)
                };
            }
        }

        protected override ConditionCollection<IContext> DoneConditions
        {
            get 
            {
                return new ConditionCollection<IContext>
                {
                    new DistanceCondition(0.5f, Destination)
                };
            }
        }
    }
}
