using Quark;
using UnityEngine;

public class InstantiateEffect : Effect
{
	GameObject _object;
	Vector3 _offset;

	public InstantiateEffect (GameObject obj, Vector3 offset = new Vector3())
	{
		_object = obj;
		_offset = offset;
	}

	public override void Apply (Vector3 point)
	{
		MonoBehaviour.Instantiate (_object, point + _offset, Quaternion.identity);
	}
}