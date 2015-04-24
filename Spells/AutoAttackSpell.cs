using Assets.QuarkDefault.Spells;
using Quark;
using Quark.Projectiles;
using Quark.Spells;
using Quark.Targeting;
using UnityEngine;

class AutoAttackSpell : Spell
{

    public override TargetMacro TargetMacro
    {
        get { return new NearestCharacter(5); }
    }
    
    protected override GameObject ProjectileObject
    {
        get { return Resources.Load<GameObject>("Projectiles/AA"); }
    }

    protected override ProjectileController Controller
    {
        get { return new HomingProjectile(); }
    }

    public override float CastDuration
    {
        get { return 0.25f; }
    }

    protected override EffectCollection TargetingDoneEffects
    {
        get
        {
            return base.TargetingDoneEffects + new EffectCollection
                {
                    new CasterEffect(new MecanimEffect("Attack"))
                };
        }
    }

    protected override EffectCollection HitEffects
    {
        get
        {
            return new EffectCollection
                {
                    new DamageEffect(-3)
                };
        }
    }
}