using System.Collections.Generic;
using Quark;
using Quark.Contexts;
using Quark.Effects;
using Quark.Spells;

namespace Assets.QuarkDefault.Spells
{
    class StagedCastedSpell : Spell
    {
        readonly Dictionary<int, EffectCollection<ICastContext>> _stages;

        public StagedCastedSpell(Dictionary<int, EffectCollection<ICastContext>> stages)
        {
            _stages = stages;
        }

        public override void OnCastingBegan()
        {
            _stageCompleted = new Dictionary<int, bool>();
            base.OnCastingBegan();
        }

        private Dictionary<int, bool> _stageCompleted;
        public override void OnCasting()
        {
            foreach (KeyValuePair<int, EffectCollection<ICastContext>> stage in _stages)
            {
                if (Context.CastPercentage > stage.Key && !_stageCompleted.ContainsKey(stage.Key))
                {
                    stage.Value.Run(Context.Targets, Context);
                    _stageCompleted[stage.Key] = true;
                }
                
            }
                
            base.OnCasting();
        }
    }
}
