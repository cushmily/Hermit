using System;

namespace Hermit
{
    public interface IViewModelProvider : IView
    {
        void SetViewModel(object context);

        ViewModel GetViewModel();

        string GetViewModelTypeName { get; }

        void ReBindAll();

        event Action DataReadyEvent;
    }
}