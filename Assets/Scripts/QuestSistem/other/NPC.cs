using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPC : MonoBehaviour
{
    public string npcName;
    public List<int> stats = new List<int>();
    public int experience;
    public bool isInjured;

    public void AddExperience(int amount)
    {
        experience += amount;
    }

    public void GetInjured()
    {
        isInjured = true;
        // Add recovery logic here
    }
}