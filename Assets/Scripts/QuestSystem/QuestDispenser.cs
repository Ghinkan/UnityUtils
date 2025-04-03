using UnityEngine;
namespace UnityUtils.QuestSystem
{
    public class QuestDispenser : MonoBehaviour
    {
        [SerializeField] private QuestManager _questManager;
        [SerializeField] private Quest _quest;

        public void GiveQuest()
        {
            _questManager.Quests.Add(_quest);
        }
    }
}