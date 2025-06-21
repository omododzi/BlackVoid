using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public static PlayerStates Instance;
    
    public int Potential = 1;
    public int Dedication = 1;
    public  int CombatSkills = 1;
    public int Endurance = 1;
    public int Craftsmanship = 1;
    public int SpiritualPower = 1;
    public int Mindfulness  = 1;
    public int Charisma = 1;
    
    public List<int> Stats = new List<int>();

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Stats = new List<int>() { Potential,Dedication,CombatSkills,Endurance,Craftsmanship,SpiritualPower,Mindfulness,Charisma};
    }
}
