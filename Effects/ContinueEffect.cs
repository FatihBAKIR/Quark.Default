using Quark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.QuarkDefault.Effects
{
    class ContinueEffect : Effect
    {
        public override void Apply(Character target)
        {
            target.Continue();
        }
    }
}
