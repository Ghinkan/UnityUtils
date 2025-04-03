using UnityEngine;
using UnityEngine.UI;
namespace UnityUtils.QuestSystem
{
    public class QuestUI : MonoBehaviour
    {
        [SerializeField] private QuestManager _questManager;
        [SerializeField] private Text _questText;
        [SerializeField] private Text[] _objectiveText;

        private void OnEnable()
        {
            for (int i = 0; i < _questManager.Quests.Count; i++)
            {
                _questManager.Quests[i].OnQuestCompleted += RefreshUI;
                for (int j = 0; i < _questManager.Quests[i].Objectives.Length; i++)
                    _questManager.Quests[i].Objectives[j].OnObjectiveCompleted += RefreshUI;
            }

            RefreshUI();
        }

        private void OnDisable()
        {
            for (int i = 0; i < _questManager.Quests.Count; i++)
            {
                _questManager.Quests[i].OnQuestCompleted -= RefreshUI;
                for (int j = 0; i < _questManager.Quests[i].Objectives.Length; i++)
                    _questManager.Quests[i].Objectives[j].OnObjectiveCompleted -= RefreshUI;
            }
        }

        public void RefreshUI()
        {
            for (int i = 0; i < _questManager.ActiveQuest.Objectives.Length; i++)
                if (_questManager.ActiveQuest.Objectives[i].IsCompleted)
                    _objectiveText[i].text = _questManager.ActiveQuest.Objectives[i].Description + " Completed";
                else
                    _objectiveText[i].text = _questManager.ActiveQuest.Objectives[i].Description;

            if (_questManager.ActiveQuest.IsCompleted)
                _questText.text = _questManager.ActiveQuest.QuestDescription + " Completed";
            else
                _questText.text = _questManager.ActiveQuest.QuestDescription;
        }

    }
}