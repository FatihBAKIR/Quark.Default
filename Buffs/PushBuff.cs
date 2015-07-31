using Quark;
using Quark.Buffs;
using UnityEngine;

namespace Assets.QuarkDefault.Buffs
{
    class PushBuff : MoveToBuff
    {
        private float _range;
        private Vector3 _from;
        private bool _fromCaster;

        Vector3 From
        {
            get { return _fromCaster ? Context.Source.transform.position : _from; }
        }

        Vector3 Direction
        {
            get { return (Possessor.transform.position - From).normalized; }
        }

        public PushBuff(float speed, float range)
        {
            Speed = speed;
            _range = range;
            _fromCaster = true;
        }

        public PushBuff(float speed, float range, Vector3 from)
        {
            Speed = speed;
            _range = range;
            _from = from;
            _fromCaster = false;
        }

        public override void OnPossess()
        {
            base.OnPossess();
            Destination = Possessor.transform.position + Direction * _range;
        }
    }
}
