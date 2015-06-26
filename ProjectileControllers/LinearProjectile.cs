using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quark.Projectiles;
using Quark.Targeting;
using UnityEngine;

namespace Assets.QuarkDefault.ProjectileControllers
{
    class LinearProjectile : ProjectileController
    {
        private float _speed;
        private float _range;

        private Vector3 _direction;

        public LinearProjectile(float speed, float range)
        {
            _speed = speed;
            _range = range;
            Type = ControlType.Movement;
        }

        public override void Initialize()
        {
            _direction = TargetPoint - Projectile.InitialPosition;
            _direction.Normalize();
            base.Initialize();
        }

        protected override Vector3 CalculateMovement
        {
            get { return _direction * _speed; }
        }

        public override bool Finished
        {
            get { return TravelDistance >= _range; }
        }
    }
}
