using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quark;
using UnityEngine;

class AudioEffect : Effect
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
