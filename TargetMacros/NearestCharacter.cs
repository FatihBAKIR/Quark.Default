using UnityEngine;
using Quark.Targeting;
using Quark;

/// <summary>
/// This macro seleccts the nearest targetable Character within a given radius around a point or the Caster
/// </summary>
public class NearestCharacter : TargetMacro
{
	protected Vector3 _point;
	protected float _range;
	protected bool _nearCaster;

	public NearestCharacter (float range) : base ()
	{
		_range = range;
		_nearCaster = true;
	}

	public NearestCharacter (Vector3 point, float range)
	{
		_point = point;
		_range = range;
	}

	protected virtual Character ClosestCharacter ()
	{
		Collider[] closeObjects = Physics.OverlapSphere (_point, _range);

		float nearestDistance = _range * 10;
		Character nearest = null;
		foreach (Collider obj in closeObjects) {
			if (obj.GetComponent<Character> () == null || obj.GetComponent<Character>().Identifier == Caster.Identifier)
				continue;

			float dist = Vector3.Distance (obj.gameObject.transform.position, _point);
			if (dist < nearestDistance) {
				nearest = obj.GetComponent<Character> ();
				nearestDistance = dist;
			}
		}

		return nearest;
	}

	public override void Run ()
	{
		if (_nearCaster)
			_point = Caster.transform.position;

		Character closest = ClosestCharacter ();
		if (closest != null) {
			OnTargetSelected (closest);
			OnTargetingSuccess ();
		} else {
			OnTargetingFail (TargetingError.NotFound);
		}
	}
}

