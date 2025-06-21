using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; }

    [Header("Quest Timing Settings")]
    [SerializeField] private float timeBetweenSteps = 300f; // 5 minutes real time per step
    [SerializeField] private int stepsPerQuest = 9; // 9 steps = 3 "days"

    [Header("Quest Lists")]
    public List<Quest> allQuests = new List<Quest>();
    public List<Quest> activeQuests = new List<Quest>();
    public List<Quest> completedQuests = new List<Quest>();
    public List<ActiveQuest> processingQuests = new List<ActiveQuest>();

    [Header("References")]
    public MiniMapController miniMap;
    public NPCManager npcManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Guest"))
        {
            NPC npc = other.GetComponent<NPC>();
            if (npc != null)
            {
                AI.Instance.goOut = true; // Сначала активируем ИИ поведение
                AssignQuest(activeQuests[0].questName, npc); // Затем назначаем квест
            }
        }
    }

    private void Start()
    {
        StartCoroutine(QuestStepTimer());
    }

    // Called when player receives quest (from dialogue or item)
    public void ReceiveQuest(Quest quest)
    {
        if (quest == null || activeQuests.Contains(quest) || completedQuests.Contains(quest))
        {
            Debug.LogWarning($"Quest {quest.questName} already active or completed");
            return;
        }

        quest.isActive = true;
        activeQuests.Add(quest);
        Debug.Log($"Received quest: {quest.questName}");
    }

    // Called when player assigns quest to NPC
    public void AssignQuest(string questName, NPC receiverNPC)
    {
        Debug.Log($"Assigning quest: {questName}");
        Quest quest = activeQuests.Find(q => q.questName == questName);
        if (quest == null)
        {
            Debug.LogWarning($"Quest {questName} not found in active quests");
            return;
        }

        activeQuests.Remove(quest);

        ActiveQuest newActiveQuest = new ActiveQuest
        {
            quest = quest,
            assignedNPC = receiverNPC,
            completedSteps = 0,
            successChance = CalculateSuccessChance(quest, receiverNPC)
        };

        processingQuests.Add(newActiveQuest);
        StartCoroutine(HideNps(receiverNPC));
        miniMap.AddQuestMarker(receiverNPC, quest);

        Debug.Log($"Assigned {questName} to {receiverNPC.npcName}");
    }

    private IEnumerator HideNps(NPC npc)
    {
        yield return new WaitForSeconds(4);
        npcManager.HideNPC(npc);
    }

    private IEnumerator QuestStepTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSteps);
            ProcessQuestStep();
        }
    }

    private void ProcessQuestStep()
    {
        foreach (ActiveQuest activeQuest in processingQuests)
        {
            activeQuest.completedSteps++;
            float progress = (float)activeQuest.completedSteps / stepsPerQuest;
            miniMap.UpdateMarkerPosition(activeQuest.assignedNPC, progress);

            if (activeQuest.completedSteps >= stepsPerQuest)
            {
                CompleteQuest(activeQuest);
            }
        }
    }

    private void CompleteQuest(ActiveQuest activeQuest)
    {
        bool success = Random.Range(0f, 1f) <= activeQuest.successChance;
        ApplyQuestResults(activeQuest.quest, activeQuest.assignedNPC, success);

        npcManager.ShowNPC(activeQuest.assignedNPC);
        miniMap.RemoveMarker(activeQuest.assignedNPC);
        completedQuests.Add(activeQuest.quest);
        processingQuests.Remove(activeQuest);

        Debug.Log($"Quest {activeQuest.quest.questName} completed. Success: {success}");
    }

    private void ApplyQuestResults(Quest quest, NPC npc, bool success)
    {
        if (success)
        {
            // Player rewards
            // PlayerStats.AddMoney(quest.moneyReward);
            // PlayerStats.AddReputation(quest.reputationReward);
            
            npc.AddExperience(quest.expReward);
        }
        else
        {
            npc.GetInjured();
            // PlayerStats.ReduceMorale(quest.moralePenalty);
        }
    }

    private float CalculateSuccessChance(Quest quest, NPC npc)
    {
        float baseChance = 0.5f;
        int matchingStats = 0;

        for (int i = 0; i < quest.requiredStats.Count; i++)
        {
            if (i < npc.stats.Count && npc.stats[i] >= quest.requiredStats[i])
            {
                matchingStats++;
            }
        }

        return Mathf.Clamp(baseChance + (matchingStats * 0.1f), 0.1f, 0.9f);
    }
}

[System.Serializable]
public class ActiveQuest
{
    public Quest quest;
    public NPC assignedNPC;
    public int completedSteps;
    public float successChance;
}




