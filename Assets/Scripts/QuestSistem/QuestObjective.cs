[System.Serializable]
public class QuestObjective
{
    public string description;
    public bool QuestComplete;
    public int currentAmount;
    public int requiredAmount = 1;
    
    public void UpdateProgress(int amount)
    {
        currentAmount += amount;
        if (currentAmount >= requiredAmount)
        {
            QuestComplete = true;
        }
    }
}