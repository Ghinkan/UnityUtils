﻿using UnityEngine;
using UnityEngine.Events;
namespace UnityUtils.EventChannels
{
    [CreateAssetMenu(fileName = "VoidEventChannel", menuName = "Events/Void Event Channel", order = 0)]
    public class VoidEventChannel : ScriptableObject
    {
        public UnityAction GameEvent;
        public void RaiseEvent()
        {
            GameEvent?.Invoke();
        }
    }
}