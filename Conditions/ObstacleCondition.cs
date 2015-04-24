using Quark;
using UnityEngine;

namespace Assets.QuarkDefault.Conditions
{
    class ObstacleCondition : Condition
    {
        private Vector3 _rotation;
        private float _range;

        public ObstacleCondition(Vector3 rotation, float range)
        {
            _rotation = rotation;
            _range = range;
        }

        public override bool Check(Character character)
        {
            Ray ray = new Ray(character.transform.position, _rotation);
            foreach(RaycastHit hit in Physics.RaycastAll(ray, _range))
            {
                if (!hit.transform.Equals(character.transform))
                {
                    Debug.Log(hit.transform.gameObject.name);
                    return true;
                }
            }
            return false;
        }
    }
}
