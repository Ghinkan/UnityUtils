using UnityEngine;
namespace UnityUtils.StateMachine
{
    public class StateMachine : MonoBehaviour
    {
        [Header("Components")]
        [Header("States")]
        public State InitialState;
        private State _currentState;

        private void Awake()
        {
            ChangeState(InitialState);
        }

        private void Update()
        {
            _currentState.OnUpdate();
        }

        private void FixedUpdate()
        {
            _currentState.OnFixedUpdate();
        }

        public void ChangeState(State newState)
        {
            if (_currentState)
                _currentState.OnExit();

            _currentState = newState;
            _currentState.OnEntry(this);
        }
    }
}