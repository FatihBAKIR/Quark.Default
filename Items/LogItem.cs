using Quark;
using QuarkDefault.Effects;

public class LogItem : Item
{
    protected override EffectCollection GrabEffects
    {
        get
        {
            return new EffectCollection
            {
                new LogEffect("Item Grabbed: " + Identifier)
            };
        }
    }
}
