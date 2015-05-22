using Quark.Projectiles;
using UnityEngine;

namespace Assets.QuarkDefault.ProjectileControllers
{
    public class HomingProjectile : ProjectileController {
        public override MovementType Type
        {
            get { return MovementType.ReturnsMovement; }
        }

        public override Vector3 Movement
        {
            get { return (Target - Obj.transform.position).normalized * Time.deltaTime * 5; }
        }
    }
}