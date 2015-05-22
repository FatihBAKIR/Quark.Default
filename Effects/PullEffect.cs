using Assets.QuarkDefault.Buffs;
using Quark;
using Quark.Buffs;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    public class PullEffect : Effect
    {
        readonly Vector3 _point;
        readonly bool _noPoint;
        readonly float _speed;

        public PullEffect (float speed = 1)
        {
            _speed = speed;
            _noPoint = true;
        }

        public PullEffect (Vector3 position, float speed = 1)
        {
            _speed = speed;
            _point = position;
        }

        public override void Apply (Character target)
        {
            Buff puller = _noPoint ? new PullBuff (_speed) : new PullBuff (_point, _speed);

            Effect buffEffect = new BuffEffect(puller);

            buffEffect.SetContext (Context);

            buffEffect.Apply (target);
        }
    }
}