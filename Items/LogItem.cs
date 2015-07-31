using Assets.QuarkDefault.Effects;
using Quark;
using Quark.Contexts;
using Quark.Effects;

namespace Assets.QuarkDefault.Items
{
    public class LogItem : Item
    {
        protected /*override*/ EffectCollection<IContext> GrabEffects
        {
            get
            {
                return new EffectCollection<IContext>
                {
                    new LogEffect("Item Grabbed: " + Identifier)
                };
            }
        }
    }
}
