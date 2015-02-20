using System;
using Quark;
using Quark.Buff;
using UnityEngine;

public class PullEffect : Effect
{
	Vector3 _point;
	bool _noPoint;
	float _speed;

	public PullEffect (float speed = 1)
	{
		_speed = speed;
		_noPoint = true;
	}

	public PullEffect (Vector3 position, float speed = 1)
	{
		_speed = 1;
		_point = position;
	}

	public override void Apply (Character target)
	{
		Buff puller;

		if (_noPoint)
			puller = new PullBuff (_speed);
		else
			puller = new PullBuff (_point, _speed);

		Effect buffEffect = new BuffEffect(puller);

		buffEffect.SetContext (Context);

		buffEffect.Apply (target);
	}
}