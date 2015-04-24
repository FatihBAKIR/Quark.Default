using UnityEngine;
using Quark.Projectiles;

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