using Quark;
using Quark.Missiles;
using Quark.Spells;
using Quark.Targeting;
using UnityEngine;

class AutoAttackSpell : Spell
{
    public override TargetMacro TargetMacro
    {
        get { return new NearestCharacter(5); }
    }
    
    protected override GameObject MissileObject
    {
        get { return Resources.Load<GameObject>("Projectiles/AutoAttack"); }
    }

    protected override MissileController Controller
    {
        get { return new HomingProjectile(); }
    }

    public override float CastDuration
    {
        get { return 0.25f; }
    }

    protected override EffectCollection InvokeEffects
    {
        get
        {
            return new EffectCollection
                {
                    new CasterEffect(new AnimateEffect("attack1", true))
                };
        }
    }

    protected override EffectCollection HitEffects
    {
        get
        {
            return new EffectCollection
                {
                    new DamageEffect(3)
                };
        }
    }
}