using Quark;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    public class ControllerMoveEffect : Effect
    {
        Vector3 _vector;

        public ControllerMoveEffect (Vector3 vector)
        {
            _vector = vector;
        }

        public override void Apply (Character target)
        {
            target.GetComponent<CharacterController> ().Move (_vector);
            base.Apply (target);
        }
    }
}