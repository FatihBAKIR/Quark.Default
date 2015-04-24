using Assets.QuarkDefault.Conditions;
using Quark;
using Quark.Buffs;
using UnityEngine;

namespace Assets.QuarkDefault.ControllerBuffs
{
    class AIController : Buff
    {
        public AIController()
        {
            _gravity = new Vector3(0, 12, 0);
        }

        CharacterController _controller;

        float MoveSpeed
        {
            get { return Possessor.GetStat("ms").Value; }
        }

        public override void OnPossess()
        {
            _controller = Possessor.GetComponent<CharacterController>();
        }

        Vector3 _move = Vector3.zero;
        readonly Vector3 _gravity;

        void Calc()
        {
            _move = Possessor.transform.forward * 0.4f * MoveSpeed;

            _move -= _gravity;
        }


        protected override EffectCollection TickEffects
        {
            get
            {
                Calc();
                return new EffectCollection
                {
				    new ConditionalEffect(new ObstacleCondition(Possessor.transform.forward, 1.25f), new Effect(), new ControllerMoveEffect ((_move) * Time.deltaTime))
                };
            }
        }
    }
}
