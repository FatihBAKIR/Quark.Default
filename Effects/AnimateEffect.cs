using Assets.QuarkDefault.ControllerBuffs;
using Quark;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    public class AnimateEffect : Effect
    {
        private string _anim;
        private bool _replayOnExists;
        public AnimateEffect(string animName, bool replayOnExists = false)
        {
            _anim = animName;
            _replayOnExists = replayOnExists;
        }

        public override void Apply(Targetable target)
        {
            Animator anim = target.GetComponent<Animator>();
            anim.Play(_anim, -1);
        }

        public override void Apply(Character target)
        {
            AnimationController ac = (AnimationController)target.GetHidden(new AnimationController());
            ac.SwitchAnim(_anim, _replayOnExists);
        }
    }
}
