using Quark.Projectiles;
using UnityEngine;

namespace Assets.QuarkDefault.ProjectileControllers
{
    public class HomingProjectile : ProjectileController
    {
        protected override ControlType Type
        {
            get { return ControlType.Movement; }
        }

        public override Vector3 Movement
        {
            get { return (Target.AsPoint() - Projectile.transform.position).normalized * Time.deltaTime * 5; }
        }
    }
}