﻿using Quark;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    public class InstantiateEffect : Effect
    {
        readonly GameObject _object;
        readonly Vector3 _offset;

        public float DestroyAfter { get; set; }

        public InstantiateEffect(GameObject obj, Vector3 offset = new Vector3())
        {
            _object = obj;
            _offset = offset;
        }

        public override void Apply(Vector3 point)
        {
            Object o = Object.Instantiate(_object, point + _offset, Quaternion.identity);
            if (DestroyAfter > 0)
                Object.Destroy(o, DestroyAfter);
        }
    }
}