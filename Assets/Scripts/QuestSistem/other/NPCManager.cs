using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    private Dictionary<NPC, GameObject> npcObjects = new Dictionary<NPC, GameObject>();

    public void RegisterNPC(NPC npc, GameObject npcObject)
    {
        npcObjects[npc] = npcObject;
    }

    public void HideNPC(NPC npc)
    {
        if (npc.gameObject != null)
        {
            npc.gameObject.SetActive(false); // Просто деактивируем объект
        }
    }

    public void ShowNPC(NPC npc)
    {
        if (npcObjects.ContainsKey(npc))
        {
            npcObjects[npc].SetActive(true);
        }
    }
}
