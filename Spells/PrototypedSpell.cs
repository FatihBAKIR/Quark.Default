using System;
using Quark;
using Quark.Spells;
using UnityEngine;
using System.Collections.Generic;
using Quark.Contexts;

namespace Assets.QuarkDefault.Spells
{
    class PrototypedSpell : Spell
    {
        private readonly Dictionary<Type, Spell> _prototypes;

        protected IEnumerable<Spell> Prototypes
        {
            get { return _prototypes.Values; }
        }

        public PrototypedSpell()
        {
            _prototypes = new Dictionary<Type, Spell>();
        }

        public void AddPrototype<T>(T prototype) where T : Spell
        {
            if (_prototypes.ContainsKey(typeof(T))) return;

            _prototypes.Add(typeof(T), prototype);
        }

        public void RemovePrototype<T>(T prototype) where T : Spell
        {
            if (!_prototypes.ContainsKey(typeof(T))) return;

            _prototypes.Remove(typeof(T));
        }

        public void RemovePrototype<T>()
        {
            if (!_prototypes.ContainsKey(typeof(T))) return;

            _prototypes.Remove(typeof(T));
        }

        public T GetPrototype<T>() where T : class 
        {
            if (!_prototypes.ContainsKey(typeof(T))) 
                return null;

            return _prototypes[typeof(T)] as T;
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

        public override void OnTravel(Vector3 position, ProjectileContext context)
        {
            foreach (Spell spell in Prototypes)
            {
                spell.SetContext(Context);
                spell.OnTravel(position, context);
            }

            base.OnTravel(position, context);
        }

        public override void OnHit(Character character, IHitContext context)
        {
            foreach (Spell spell in Prototypes)
            {
                spell.SetContext(Context);
                spell.OnHit(character, context);
            }

            base.OnHit(character, context);
        }

        public override void OnHit(Targetable targetable, IHitContext context)
        {
            foreach (Spell spell in Prototypes)
            {
                spell.SetContext(Context);
                spell.OnHit(targetable, context);
            }

            base.OnHit(targetable, context);
        }

        public override void OnHit(Vector3 position, IHitContext context)
        {
            foreach (Spell spell in Prototypes)
            {
                spell.SetContext(Context);
                spell.OnHit(position, context);
            }

            base.OnHit(position, context);
        }

        public override void OnMiss(IProjectileContext context)
        {
            foreach (Spell spell in Prototypes)
            {
                spell.SetContext(Context);
                spell.OnMiss(context);
            }

            base.OnMiss(context);
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
