using Quark;
using Quark.Conditions;
using Quark.Contexts;
using Quark.Effects;
using UnityEngine;

namespace Assets.QuarkDefault.Effects
{
    /// <summary>
    /// This effect lets you apply an effect conditionally on Apply time.
    /// </summary>
    internal class ConditionalEffect
    {
        public static IEffect<T> Create<T>(ICondition<T> condition, IEffect<T> ontrue, IEffect<T> onfalse = null) where T : class, IContext
        {
            return new _ConditionalEffect<T>(condition, ontrue, onfalse);
        }

        public static IEffect<T> Create<T>(bool condition, IEffect<T> ontrue, IEffect<T> onfalse = null) where T : class, IContext
        {
            return new _ConditionalEffect<T>(condition, ontrue, onfalse);
        }

        class _ConditionalEffect<T> : Effect<T> where T : class, IContext
        {
            private readonly ICondition<T> _condition;
            private readonly IEffect<T> _onTrue;
            private readonly IEffect<T> _onFalse;

            private readonly bool _boolean;

            public _ConditionalEffect(bool condition, IEffect<T> ontrue, IEffect<T> onfalse = null)
            {
                _condition = null;
                _boolean = condition;
                _onTrue = ontrue;
                _onFalse = onfalse;
            }

            public _ConditionalEffect(ICondition<T> condition, IEffect<T> ontrue, IEffect<T> onfalse = null)
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
}