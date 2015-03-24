using Quark;
using Quark.Spells;
using Quark.Targeting;

public class GrabSpell : Spell
{
    public override TargetMacro TargetMacro
    {
        get { return new SelfCharacter(); }
    }

    protected override EffectCollection InvokeEffects
    {
        get
        {
            return new EffectCollection
            {
                new CasterEffect(new GrabEffect(new LogItem()))
            };
        }
    }
}
