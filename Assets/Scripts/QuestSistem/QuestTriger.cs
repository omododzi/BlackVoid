using System.Collections.Generic;
using UnityEngine;

public class QuestTriger : MonoBehaviour
{
    public Quest _Quest;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && QuestManager.Instance != null)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            QuestManager.Instance.ReceiveQuest(_Quest);
        }

     
    }
    
    // Или для диалогов:
    public void CompleteOnDialogueEnd()
    {
       
    }
}
