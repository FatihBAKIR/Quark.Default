using Quark;
using Quark.Contexts;
using Quark.Expressions;
using Quark.Projectiles;
using UnityEngine;

namespace Assets.QuarkDefault.ProjectileControllers
{
    class LinearProjectile : ProjectileController
    {
        private float _speed;
        private float _range;

        private readonly IExpression<IProjectileContext> _speedExp;
        private readonly IExpression<IProjectileContext> _rangeExp;

        public Vector3 Direction
        {
            get { return (TargetPoint - Projectile.transform.position).normalized; }
        }

        public LinearProjectile(float speed, float range)
        {
            _speed = speed;
            _range = range;
            Type = ControlType.Movement;
        }

        public LinearProjectile(IExpression<IProjectileContext> speed, IExpression<IProjectileContext> range)
        {
            _speedExp = speed;
            _rangeExp = range;
            Type = ControlType.Movement;
        }

        public override void SetContext(IProjectileContext context)
        {
            base.SetContext(context);

            _speedExp.SetContext(context);
            _rangeExp.SetContext(context);

            _speed = _speedExp.Calculate();
            _range = _rangeExp.Calculate();
        }

        protected override Vector3 CalculateMovement
        {
            get { return Direction * _speed * Time.deltaTime; }
        }

        public override bool Finished
        {
            get { return TravelDistance >= _range; }
        }

        public override void ChangeTarget(TargetUnion newTarget)
        {
            base.ChangeTarget(newTarget);
            Initialize();
        }
    }
}
