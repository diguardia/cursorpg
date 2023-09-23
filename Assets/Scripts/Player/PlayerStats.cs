using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Stats")]
    public float Damage;
    public float Defense;
    public float Speed;
    public float Level;
    public float CurrentExperience;
    public float RequiredExperienceNextLevel;

    [Range(0,100)] public float PercentageCritical;
    [Range(0,100)] public float PercentageBlocking;

    [Header("Attributes")]
    public int Strength;
    public int Intelligence;
    public int Dexterity;

    [HideInInspector] public int AvailablePoints;

    private int baseExperience;

    PlayerStats() {
        Reset();
    }

    public void Reset() {
        Damage = 5;
        Defense = 2;
        Speed =1 ;
        PercentageBlocking = 0;
        PercentageCritical = 0;

        Strength=0;
        Intelligence =0;
        Dexterity=0;
        AvailablePoints=0;

        ResetExperience(baseExperience);
    }

    public void ResetExperience(int baseExperience)
    {
        this.baseExperience = baseExperience; 
        Level = 1;
        RequiredExperienceNextLevel = baseExperience;
        CurrentExperience = 0;
    }

    
    public void  UpgradeByStrength() {
        Damage+=2;
        Defense+=1;
        PercentageBlocking+= 0.03F;
    }
    public void  UpgradeByIntelligence() {
        Damage+=3;
        PercentageCritical+=0.2F;
    }
    public void  UpgradeByDexterity() {
        Speed+=0.1F;
        PercentageBlocking+=0.05F;
    }

}
