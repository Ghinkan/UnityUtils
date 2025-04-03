using UnityEngine;
using UnityEngine.Events;
namespace UnityUtils.QuestSystem
{
    [CreateAssetMenu]
    public class Quest : ScriptableObject
    {
        public event UnityAction OnQuestCompleted;

        public bool IsCompleted;

        [TextArea]
        public string QuestDescription;
        public Objective[] Objectives;

        private void OnEnable()
        {
            foreach (Objective objective in Objectives)
                objective.OnObjectiveCompleted += TryEndQuest;
        }

        private void OnDisable()
        {
            foreach (Objective objective in Objectives)
                objective.OnObjectiveCompleted -= TryEndQuest;
        }

        public void TryEndQuest()
        {
            if (AllObjectivesAreCompleted())
            {
                IsCompleted = true;
                OnQuestCompleted?.Invoke();
            }
        }

        private bool AllObjectivesAreCompleted()
        {
            foreach (Objective objective in Objectives)
                if (objective.IsCompleted != true)
                    return false;

            return true;
        }
    }
}