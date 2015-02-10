using System;
using Quark;

namespace AssemblyCSharpvs
{
    public class HealEffect : StatEffect
    {
        public HealEffect(Interaction casterInteractions, Interaction targetInteractions) : base("hp", casterInteractions, targetInteractions)
        {
        }
    }
}

