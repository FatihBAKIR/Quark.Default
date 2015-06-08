using Assets.QuarkDefault.Buffs;
using Quark;
using Quark.Buffs;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    public class PushEffect : Effect
    {
        readonly Vector3 _point;
        readonly bool _noPoint;
        readonly float _speed;

        public PushEffect (float speed = 1)
        {
            _speed = speed;
        }

        public PushEffect (Vector3 position, float speed = 1)
        {
            _speed = speed;
            _point = position;
        }

        public override void Apply (Character target)
        {
            Buff pusher = new PushBuff(_speed, 3);

            Effect buffEffect = new BuffEffect(pusher);

            buffEffect.SetContext (Context);

            buffEffect.Apply (target);
        }
    }
}