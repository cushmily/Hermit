using System;

namespace Hermit.Fsm
{
    public interface IBuildableState : IState
    {
        TState AddChild<TState>(string name, TState state) where TState : IState;

        void SetEnterAction(Action onEnterAction);

        void SetExitAction(Action onExitAction);

        void SetUpdateAction(Action<float> onUpdateAction);

        void AddEvent(string id, Action<EventArgs> action);

        void AddEvent<TArgs>(string id, Action<TArgs> action) where TArgs : EventArgs;

        void AddCondition(Func<bool> predicate, Action action);
    }
}
