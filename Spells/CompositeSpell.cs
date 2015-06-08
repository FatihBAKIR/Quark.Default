using System.Collections.Generic;
using Quark;
using Quark.Spells;
using UnityEngine;

namespace Assets.QuarkDefault.Spells
{
    class PrototypedSpell : Spell
    {
        protected virtual Spell[] Prototypes
        {
            get;
            set;
        }

        public override bool CanInvoke()
        {
            foreach (Spell spell in Prototypes)
            {
                spell.SetContext(Context);
                if (!spell.CanInvoke())
                    return false;
            }

            return base.CanInvoke();
        }

        public override void OnInvoke()
        {
            foreach (Spell spell in Prototypes)
            {
                spell.SetContext(Context);
                spell.OnInvoke();
            }

            base.OnInvoke();
        }

        public override void OnTargetingDone()
        {
            foreach (Spell spell in Prototypes)
            {
                spell.SetContext(Context);
                spell.OnTargetingDone();
            }

            base.OnTargetingDone();
        }

        public override void OnCastingBegan()
        {
            foreach (Spell spell in Prototypes)
            {
                spell.SetContext(Context);
                spell.OnCastingBegan();
            }

            base.OnCastingBegan();
        }

        public override void OnCasting()
        {
            foreach (Spell spell in Prototypes)
            {
                spell.SetContext(Context);
                spell.OnCasting();
            }

            base.OnCasting();
        }

        public override void OnCastDone()
        {
            foreach (Spell spell in Prototypes)
            {
                spell.SetContext(Context);
                spell.OnCastDone();
            }

            base.OnCastDone();
        }

        public override void OnInterrupt()
        {
            foreach (Spell spell in Prototypes)
            {
                spell.SetContext(Context);
                spell.OnInterrupt();
            };

            base.OnInterrupt();
        }

        public override void OnTravel(Vector3 position)
        {
            foreach (Spell spell in Prototypes)
            {
                spell.SetContext(Context);
                spell.OnTravel(position);
            }

            base.OnTravel(position);
        }

        public override void OnHit(Character character)
        {
            foreach (Spell spell in Prototypes)
            {
                spell.SetContext(Context);
                spell.OnHit(character);
            }

            base.OnHit(character);
        }

        public override void OnHit(Targetable targetable)
        {
            foreach (Spell spell in Prototypes)
            {
                spell.SetContext(Context);
                spell.OnHit(targetable);
            }

            base.OnHit(targetable);
        }

        public override void OnHit(Vector3 position)
        {
            foreach (Spell spell in Prototypes)
            {
                spell.SetContext(Context);
                spell.OnHit(position);
            }

            base.OnHit(position);
        }

        public override void OnMiss()
        {
            foreach (Spell spell in Prototypes)
            {
                spell.SetContext(Context);
                spell.OnMiss();
            }

            base.OnMiss();
        }

        public override void OnFinal()
        {
            foreach (Spell spell in Prototypes)
            {
                spell.SetContext(Context);
                spell.OnFinal();
            }

            base.OnFinal();
        }
    }
}
