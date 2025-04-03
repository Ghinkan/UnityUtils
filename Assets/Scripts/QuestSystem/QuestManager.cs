using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace UnityUtils.QuestSystem
{
    [CreateAssetMenu]
    public class QuestManager : ScriptableObject
    {
        public event UnityAction OnAllQuestCompleted;

        public List<Quest> Quests;
        public Quest ActiveQuest;

        private int _currentQuest;

        private void OnEnable()
        {
            foreach (Quest quest in Quests)
                quest.OnQuestCompleted += OnQuestCompleted;

            ActiveQuest = Quests[_currentQuest];
        }

        private void OnDisable()
        {
            foreach (Quest quest in Quests)
                quest.OnQuestCompleted -= OnQuestCompleted;
        }

        private void OnQuestCompleted()
        {
            Nextquest();
        }

        private void Nextquest()
        {
            _currentQuest++;

            if (_currentQuest < Quests.Count)
                ActiveQuest = Quests[_currentQuest];
            else
                OnAllQuestCompleted?.Invoke();
        }
    }
}