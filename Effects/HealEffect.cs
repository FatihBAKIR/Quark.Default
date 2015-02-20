﻿using System;
using Quark;

namespace AssemblyCSharpvs
{
    public class HealEffect : StatEffect
    {
        public HealEffect(Interaction casterInteractions, Interaction targetInteractions, float constant = 0) : base("hp", casterInteractions, targetInteractions, constant)
        {
        }

		public HealEffect(float constant) : base ("hp", constant)
		{
		}
    }
}

