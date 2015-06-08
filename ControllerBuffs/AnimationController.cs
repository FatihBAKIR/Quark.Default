using Quark.Buffs;
using UnityEngine;

namespace Assets.QuarkDefault.ControllerBuffs
{
    class AnimationController : Buff
    {
        public AnimationController()
        {
            Duration = -1;
            Hidden = true;
            Continuous = true;
        }

        Animator _animator;

        private string _fadingAnim;

        public override void OnPossess ()
        {
            _animator = Possessor.GetComponent<Animator>();

            /*StateMachine sm = ((AnimatorController)_animator.runtimeAnimatorController).GetLayer(0).stateMachine;
        for (int i = 0; i < sm.stateCount; i++)
        {
            State state = sm.GetState(i);
            //Debug.Log(string.Format("State: {0}", state.uniqueName));
        }*/
        }

        protected override void OnTick()
        {
            if (IsAnimActive(_fadingAnim))
                _fadingAnim = "";
            base.OnTick();
        }

        bool IsAnimActive(string name)
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName(name);
        }

        private string _lastPlayed;
        public void SwitchAnim(string name, bool restartOnExists = false)
        {
            if (IsAnimActive(name))
            {
                if (restartOnExists)
                    _animator.CrossFade(name, 0.05f, 0, 0);
                else
                    _animator.Play(name);
                return;
            }

            if (_fadingAnim == name)
                return;
        
            _animator.CrossFade(name, 0.05f);
            _fadingAnim = name;
        }
    }
}