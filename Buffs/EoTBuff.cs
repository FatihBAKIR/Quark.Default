using Quark;
using Quark.Buff;

public class EoTBuff : Buff
{
	Effect _effect;

	public EoTBuff (Effect effect, float interval, float duration)
	{
		Duration = duration;
		Interval = interval;
		StackBehaviour = StackBehavior.ResetBeginning;
		_effect = effect;
	}

	protected override EffectCollection TickEffects {
		get {
			return new EffectCollection {
				_effect
			};
		}
	}
}
