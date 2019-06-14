﻿using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Hermit.UIStack
{
    public class Widget : MonoBehaviour, IWidget, IView
    {
        [SerializeField]
        private UILayer _layer = UILayer.Window;

        public string Path { get; private set; }

        public IWidgetController Controller { get; set; }

        public virtual UILayer Layer => _layer;

        protected IUIStack IuiStack { get; private set; }

        protected UIMessage Message { get; private set; } = UIMessage.Empty;

        public virtual void SetManagerInfo(string path, IUIStack manager, UIMessage message)
        {
            Path = path;
            IuiStack = manager;
            Message = message;
        }

        #region Events

        public event Action<Widget> OnDestroyEvent;

        #endregion

        #region IWidget

        public virtual async Task OnShow()
        {
            await Task.FromResult(default(object));
        }

        public virtual async Task OnHide()
        {
            await Task.FromResult(default(object));
        }

        public virtual async Task OnResume()
        {
            await Task.FromResult(default(object));
        }

        public virtual async Task OnFreeze()
        {
            await Task.FromResult(default(object));
        }

        public void DestroyWidget()
        {
            OnDestroyEvent?.Invoke(this);
        }

        public virtual void OnDestroy()
        {
            DestroyWidget();
        }

        #endregion

        #region IView

        public ulong ViewId { get; private set; }

        public GameObject ViewObject => gameObject;

        public Component ViewComponent => this;

        #endregion

        #region Unity LifeTime

        protected virtual void Awake()
        {
            ViewId = Her.Resolve<IViewManager>().Register(this);
        }

        #endregion
    }
}