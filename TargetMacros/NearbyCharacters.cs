using System;
using Quark.Targeting;
using Quark;
using UnityEngine;
using System.Collections.Generic;

public class NearbyCharacters : TargetMacro
{
	protected Vector3 _point;
	protected float _range;
	protected bool _nearCaster;

	public NearbyCharacters(float range) : base()
	{
		_range = range;
		_nearCaster = true;
	}

	public NearbyCharacters (Vector3 point, float range)
	{
		_point = point;
		_range = range;
	}

	protected virtual Character[] ClosestCharacters ()
	{
		Collider[] closeObjects = Physics.OverlapSphere (_point, _range);

		List<Character> chars = new List<Character> ();

		foreach (Collider obj in closeObjects) {
			if (obj.GetComponent<Character> () == null)
				continue;
			chars.Add (obj.GetComponent<Character> ());
		}

		return chars.ToArray ();
	}

	public override void Run ()
	{
		if (_nearCaster)
			_point = Context.Caster.transform.position;
		foreach (Character target in ClosestCharacters())
			OnTargetSelected (target);
		OnTargetingSuccess ();
	}
}

public class NearbyCharacters <T> : NearbyCharacters where T : MonoBehaviour
{
	public NearbyCharacters(Vector3 point, float range) : base(point, range)
	{
	}

	protected override Character[] ClosestCharacters ()
	{
		Collider[] closeObjects = Physics.OverlapSphere (_point, _range);

		List<Character> chars = new List<Character> ();

		foreach (Collider obj in closeObjects) {
			if (obj.GetComponent<Character> () == null)
				continue;
			if (obj.GetComponent<T> () == null)
				continue;
			chars.Add (obj.GetComponent<Character> ());
		}

		return chars.ToArray ();
	}
}
