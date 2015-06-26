using Quark;
using Quark.Projectiles;
using UnityEngine;

namespace Assets.QuarkDefault.ProjectileControllers
{
    public class HomingProjectile : ProjectileController
    {
        private float Speed;

        public HomingProjectile(float speed = 5)
        {
            Type = ControlType.Movement;
            Speed = speed;
        }

        protected override Vector3 CalculateMovement 
        {
            get
            {
                Debug.DrawLine(TargetPoint, Projectile.transform.position);
                return (TargetPoint - Projectile.transform.position).normalized * Time.deltaTime * Speed;
            }
        }
    }
}