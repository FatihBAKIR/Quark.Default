using Quark;
using Quark.Contexts;
using Quark.Effects;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    class AudioEffect : Effect<IContext>
    {
        private readonly AudioClip _clip;

        public AudioEffect(AudioClip clip)
        {
            _clip = clip;
        }

        public override void Apply(Character target)
        {
            AudioSource source = target.GetComponent<AudioSource>();
            source.PlayOneShot(_clip);
            base.Apply(target);
        }
    }
}
