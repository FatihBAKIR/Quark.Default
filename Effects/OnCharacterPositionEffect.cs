using Quark;
using Quark.Contexts;
using Quark.Effects;

namespace Assets.QuarkDefault.Effects
{
    /// <summary>
    /// This effect relays the target Characters position to the given effect.
    /// </summary>
    public class OnCharacterPositionEffect<T> : Effect<T> where T: class, IContext
    {
        readonly IEffect<T> _effect;

        public OnCharacterPositionEffect(IEffect<T> effect)
        {
            _effect = effect;
        }

        public override void Apply (Character target)
        {
            _effect.SetContext(Context);
            _effect.Apply (target.gameObject.transform.position);
        }
    }
}