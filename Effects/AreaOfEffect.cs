using System.Collections.Generic;
using Assets.QuarkDefault.TargetMacros;
using Quark;
using Quark.Contexts;
using Quark.Effects;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    /// <summary>
    /// This effect relays the characters in a range of the target point to the given effect 
    /// </summary>
    public class AreaOfEffect
    {
        public static IEffect<T> Create<T>(IEffect<T> effect, float range) where T : class, IContext
        {
            return new _AreaOfEffect<T>(effect, range);
        }

        public class _AreaOfEffect<T> : Effect<T> where T : IContext
        {
            readonly IEffect<T> _effect;
            readonly float _range;
            public _AreaOfEffect(IEffect<T> effect, float range)
            {
                _effect = effect;
                _range = range;
            }

            public override void Apply(Vector3 point)
            {
                List<Character> targets = new List<Character>();
                NearbyCharacters chars = new NearbyCharacters(point, _range);
                chars.SetContext(Context);
                chars.CharacterSelected += delegate(Character target)
                {
                    targets.Add(target);
                };
                chars.Run();
                _effect.SetContext(Context);
                foreach (Character target in targets)
                {
                    _effect.Apply(target);
                }
            }
        }
    }

}
