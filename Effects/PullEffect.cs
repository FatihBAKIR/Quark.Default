using Assets.QuarkDefault.Buffs;
using Quark;
using Quark.Buffs;
using Quark.Contexts;
using Quark.Effects;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    public class PullEffect : Effect<ICastContext>
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
            IBuff<ICastContext> puller = _noPoint ? new PullBuff(_speed) : new PullBuff(_point, _speed);

            IEffect<ICastContext> buffEffect = BuffEffect.Create(puller);

            buffEffect.SetContext (Context);

            buffEffect.Apply (target);
        }
    }
}