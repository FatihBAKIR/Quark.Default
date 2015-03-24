using Quark;
using UnityEngine;

class CasterEffect : Effect
{
    private readonly Effect _effect;

    public CasterEffect(Effect effect)
    {
        _effect = effect;
    }

    public override void Apply()
    {
        Apply((Character)null);
    }

    public override void Apply(Targetable target)
    {
        Apply((Character)null);
    }

    public override void Apply(Vector3 point)
    {
        Apply((Character)null);
    }

    public override void Apply(Character target)
    {
        _effect.SetContext(Context);
        _effect.Apply(Context.Caster);
    }
}