using UnityEngine;
namespace UnityUtils.StateMachine
{
    public abstract class State : MonoBehaviour
    {
        protected StateMachine StateMachine;

        public void OnEntry(StateMachine parentStateMachine)
        {
            StateMachine = parentStateMachine;
        }
        public virtual void OnUpdate()      { }
        public virtual void OnFixedUpdate() { }
        public virtual void OnExit()        { }
    }
}