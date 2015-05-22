using System.Collections.Generic;
using Assets.QuarkDefault.TargetMacros;
using Quark;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    /// <summary>
    /// This effect relays the characters in a range of the target point to the given effect 
    /// </summary>
    public class AreaOfEffect : Effect
    {
        readonly Effect _effect;
        readonly float _range;
        public AreaOfEffect (Effect effect, float range)
        {
            _effect = effect;
            _range = range;
        }

        public override void Apply (Vector3 point)
        {
            List<Character> targets = new List<Character>();
            NearbyCharacters chars = new NearbyCharacters (point, _range);
            chars.SetContext(Context, true);
            chars.CharacterSelected += delegate(Character target)
            {
                targets.Add(target);
            };
            chars.Run ();
            _effect.SetContext(Context);
            foreach (Character target in targets) {
                _effect.Apply (target);
            }
        }
    }
}
