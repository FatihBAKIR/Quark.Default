using Assets.QuarkDefault.Effects;
using Assets.QuarkDefault.Spells;
using Quark;
using Quark.Spells;
using Quark.Targeting;
using UnityEngine;

public class BoomSpell : Spell
{
    public BoomSpell()
    {
        Tags = new StaticTags { "damage" };
    }

    public override float CastDuration
    {
        get { return 1.2f; }
    }

    public override TargetMacro TargetMacro
    {
        get
        {
            return new CasterPosition();
        }
    }

    protected override EffectCollection TargetingDoneEffects 
    {
        get
        {
            return new EffectCollection
            {
                    new CasterEffect(new MecanimEffect("Ultimate"))
            };
        }
    }

    protected override EffectCollection CastDoneEffects
    {
        get
        {
            return new EffectCollection {
                new CasterEffect(new VisualEffect("VFX/BOOM", new Vector3(0,1,0))),
				new AreaOfEffect(new DamageEffect (-10), 5)
			};
        }
    }
}