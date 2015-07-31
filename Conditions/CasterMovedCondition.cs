using Quark;
using Quark.Conditions;
using Quark.Contexts;
using Quark.Projectiles;
using UnityEngine;

namespace Assets.QuarkDefault.Conditions
{
    /// <summary>
    /// This condition checks whether the Caster Character of a Cast context has moved Missile.NearEnough units away from the initial position it began the casting.
    /// Useful for interruption checking
    /// </summary>
    public class CasterMovedCondition : Condition<ICastContext>
    {
        public override bool Check ()
        {
            return Vector3.Distance (Context.CastBeginPosition, Context.Source.transform.position) >= Projectile.NearEnough;
        }
    }
}