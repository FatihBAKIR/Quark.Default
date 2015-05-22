using System;
using Quark.Utilities;
using UnityEngine;
using System.Collections.Generic;
using Quark;
using Quark.Spells;

namespace Assets.QuarkDefault.ControllerBuffs
{
    interface IBinding
    {
        bool Check(string prefix);
        void Activate(Character caster);
    }

    public class KeyBinding<T> : IBinding where T : Spell, new()
    {
        readonly KeyCode _key;
        private readonly string _button;


        public KeyBinding(string button)
        {
            _button = button;
        }

        public bool Check(string prefix)
        {
            return (Input.GetButtonUp(prefix + _button));
        }

        public void Activate(Character caster)
        {
            Cast.PrepareCast(caster, new T());
        }
    }

    class InputController : QuarkController
    {
        private readonly string _inputPrefix;

        public InputController()
        {
            _inputPrefix = "";
        }

        public InputController(string prefix)
        {
            _inputPrefix = prefix + " ";
        }

        protected override bool IsMoving
        {
            get { return Mathf.Abs(Input.GetAxis(_inputPrefix + "Vertical")) > 0.1f; }
        }

        private Vector3 _move;
        protected override Vector3 Movement
        {
            get
            {
                if (IsGrounded)
                {
                    _move = Possessor.transform.forward * Mathf.Round(Input.GetAxis(_inputPrefix + "Vertical")) * MoveSpeed;

                    if (Input.GetButton(_inputPrefix + "Jump"))
                        _move.y = JumpSpeed;
                }

                _move -= Gravity * Time.deltaTime;
                return _move;
            }
        }

        protected override Vector3 Rotation
        {
            get
            {
                return IsGrounded ? new Vector3(0, Mathf.Round(Input.GetAxis(_inputPrefix + "Horizontal")) * RotateSpeed, 0) : Vector3.zero;
            }
        }

        protected override void OnTick()
        {
            base.OnTick();
            CheckBindings();
        }

        void CheckBindings()
        {
            foreach (IBinding binding in Bindings)
                if (binding.Check(_inputPrefix))
                    binding.Activate(Possessor);
        }

        public List<IBinding> Bindings = new List<IBinding>();
    }
}