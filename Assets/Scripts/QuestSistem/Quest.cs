using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string questName;
    public string description;
    public bool isComplete;
    public bool isActive;
    public List<int> requiredStats = new List<int>();
    
    // Rewards
    public int moneyReward;
    public int expReward;
    public int reputationReward;
    public int moralePenalty;
}