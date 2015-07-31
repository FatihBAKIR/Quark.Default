using Assets.QuarkDefault.Buffs;
using Quark;
using Quark.Buffs;
using Quark.Contexts;
using Quark.Effects;
using Quark.Utilities;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    public class PushEffect : Effect<IHitContext>
    {
        readonly Vector3 _point;
        readonly bool _noPoint;
        readonly float _speed;

        public PushEffect(float speed = 1)
        {
            _speed = speed;
        }

        public PushEffect(Vector3 position, float speed = 1)
        {
            _speed = speed;
            _point = position;
        }

        public override void Apply(Character target)
        {

            Vector3 hitPos = Context.HitPosition;
            Vector3 targetPos = target.transform.position;
            hitPos.y = targetPos.y = 0;
            Vector3 hitDirection = (targetPos - hitPos).normalized;
            Vector3 hitOrientation = Context.HitOrientation.normalized;
            hitOrientation.y = 0;          
            Vector3 pushVector = hitDirection + hitOrientation;
            pushVector.y = 0;

            IBuff<IContext> pusher = new PushBuff(_speed, _speed / 2, target.transform.position - pushVector);

            IEffect<IContext> buffEffect = BuffEffect.Create(pusher);

            buffEffect.SetContext(Context);

            buffEffect.Apply(target);
        }
    }
}