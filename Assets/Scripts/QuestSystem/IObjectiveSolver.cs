namespace UnityUtils.QuestSystem
{
    public interface IObjectiveSolver
    {
        public Objective Objective { get; set; }

        public void ObjectiveReached();
    }
}