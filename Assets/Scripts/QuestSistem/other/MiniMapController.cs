using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    public GameObject markerPrefab;
    private Dictionary<NPC, GameObject> activeMarkers = new Dictionary<NPC, GameObject>();

    public void AddQuestMarker(NPC npc, Quest quest)
    {
        if (activeMarkers.ContainsKey(npc)) return;

        GameObject marker = Instantiate(markerPrefab, transform);

        // Настройте маркер в соответствии с квестом
        activeMarkers[npc] = marker;
    }

    public void UpdateMarkerPosition(NPC npc, float progress)
    {
        if (activeMarkers.ContainsKey(npc))
        {
            // Пример: перемещение маркера по заранее заданному пути
            Vector3 newPosition = CalculatePosition(progress);
            activeMarkers[npc].transform.localPosition = newPosition;
        }
    }

    public void RemoveMarker(NPC npc)
    {
        if (activeMarkers.ContainsKey(npc))
        {
            Debug.Log(activeMarkers[npc].name);
            Destroy(activeMarkers[npc]);
            activeMarkers.Remove(npc);
        }
    }

    private Vector3 CalculatePosition(float progress)
    {
        // Реализуйте логику перемещения маркера
        return Vector3.Lerp(Vector3.zero, Vector3.one, progress);
    }
}
