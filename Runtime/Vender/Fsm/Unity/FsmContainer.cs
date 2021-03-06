﻿using UnityEngine;

namespace Hermit.Fsm
{
    public abstract class FsmContainer : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        private bool useFixedUpdate = false;

        public bool UseFixedUpdate => useFixedUpdate;

        public IState RootNode { get; protected set; }

        protected bool Running { get; private set; }

        protected abstract IState BuildState();

        protected virtual void OnInit() { }

        protected virtual void OnDestroy() { }

        protected virtual void OnUpdate(float deltaTime) { }

        protected virtual void OnFixedUpdate(float deltaTime) { }

        protected virtual void OnResume() { }

        protected virtual void OnPause() { }

        private void Awake()
        {
            OnInit();
            RootNode = BuildState();
            RootNode.Enter();
        }

        private void OnEnable()
        {
            Running = true;
            OnResume();
        }

        private void OnDisable()
        {
            Running = false;
            OnPause();
        }

        private void Update()
        {
            if (Running && !UseFixedUpdate)
            {
                RootNode?.Update(Time.deltaTime);
            }

            OnUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if (Running && UseFixedUpdate)
            {
                RootNode?.Update(Time.fixedDeltaTime);
            }

            OnFixedUpdate(Time.fixedDeltaTime);
        }
    }
}
