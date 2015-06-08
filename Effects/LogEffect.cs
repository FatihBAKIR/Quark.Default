using Quark;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    public class LogEffect : Effect
    {
        private string _log;

        public LogEffect(string log)
        {
            _log = log;
        }

        public override void Apply()
        {
            Debug.Log(_log);
        }

        public override void Apply(Character target)
        {
            Apply();
        }

        public override void Apply(Targetable target)
        {
            Apply();
        }

        public override void Apply(Vector3 point)
        {
            Apply();
        }
    }
}
