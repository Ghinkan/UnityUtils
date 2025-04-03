using UnityEngine;
using UnityEngine.Events;
namespace UnityUtils.QuestSystem
{
    [CreateAssetMenu(fileName = "Objective", menuName = "QuestSystem")]
    public class Objective : ScriptableObject
    {
        public event UnityAction OnObjectiveCompleted;

        public bool IsCompleted;

        [TextArea]
        public string Description;

        public void ObjectiveCompleted()
        {
            IsCompleted = true;
            OnObjectiveCompleted?.Invoke();
        }
    }
}