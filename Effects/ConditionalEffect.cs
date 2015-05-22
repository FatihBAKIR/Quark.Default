using Quark;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    /// <summary>
    /// This effect lets you apply an effect conditionally on Apply time.
    /// </summary>
    public class ConditionalEffect : Effect
    {
        readonly Condition _condition;
        readonly Effect _onTrue;
        readonly Effect _onFalse;

        private readonly bool _boolean;

        public ConditionalEffect(bool condition, Effect ontrue, Effect onfalse = null)
        {
            _condition = null;
            _boolean = condition;
            _onTrue = ontrue;
            _onFalse = onfalse;
        }

        public ConditionalEffect(Condition condition, Effect ontrue, Effect onfalse = null)
        {
            _condition = condition;
            _onTrue = ontrue;
            _onFalse = onfalse;
        }

        public override void Apply()
        {
            if (_onTrue != null)
                _onTrue.SetContext(Context);
            if (_onFalse != null)
                _onFalse.SetContext(Context);

            if (_condition == null)
            {
                if (_boolean)
                    _onTrue.Apply();
                else if (_onFalse != null)
                    _onFalse.Apply();
            }
            else
            {
                _condition.SetContext(Context);
                if (_condition.Check())
                    _onTrue.Apply();
                else if (_onFalse != null)
                    _onFalse.Apply();
            }
        }

        public override void Apply(Vector3 point)
        {
            if (_onTrue != null)
                _onTrue.SetContext(Context);
            if (_onFalse != null)
                _onFalse.SetContext(Context);

            if (_condition == null)
            {
                if (_boolean)
                    _onTrue.Apply(point);
                else if (_onFalse != null)
                    _onFalse.Apply(point);
            }
            else
            {
                _condition.SetContext(Context);
                if (_condition.Check(point))
                    _onTrue.Apply(point);
                else if (_onFalse != null)
                    _onFalse.Apply(point);
            }
        }

        public override void Apply(Targetable target)
        {
            if (_onTrue != null)
                _onTrue.SetContext(Context);
            if (_onFalse != null)
                _onFalse.SetContext(Context);

            if (_condition == null)
            {
                if (_boolean)
                    _onTrue.Apply(target);
                else if (_onFalse != null)
                    _onFalse.Apply(target);
            }
            else
            {
                _condition.SetContext(Context);
                if (_condition.Check(target))
                    _onTrue.Apply(target);
                else if (_onFalse != null)
                    _onFalse.Apply(target);
            }
        }

        public override void Apply(Character target)
        {
            if (_onTrue != null)
                _onTrue.SetContext(Context);
            if (_onFalse != null)
                _onFalse.SetContext(Context);

            if (_condition == null)
            {
                if (_boolean)
                    _onTrue.Apply(target);
                else if (_onFalse != null)
                    _onFalse.Apply(target);
            }
            else
            {
                _condition.SetContext(Context);
                if (_condition.Check(target))
                    _onTrue.Apply(target);
                else if (_onFalse != null)
                    _onFalse.Apply(target);
            }
        }
    }
}