using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private PlayerStats stats;

    [Header("Config")]
    [SerializeField] private int maxLevel;
    [SerializeField] private int baseExperience;
    [SerializeField] private int incrementalValue;

    private float temporalCurrentExperience;
    
    // Start is called before the first frame update
    void Start()
    {
        stats.ResetExperience(baseExperience);
        RefreshUI();
    }


    private void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            GainExperience(2);
        }
    }

    public void GainExperience(float amount) {
        if (amount > 0) {
            float remainingExperienceForNextLevel = stats.RequiredExperienceNextLevel - temporalCurrentExperience;
            if (amount >= remainingExperienceForNextLevel) {
                amount -= remainingExperienceForNextLevel;
                UpgradeLevel();
                GainExperience(amount);
            }  else {
                temporalCurrentExperience += amount;
                stats.CurrentExperience = temporalCurrentExperience;
            }
            RefreshUI();
        }
    }

    public void UpgradeLevel() {
        stats.Level++;
        temporalCurrentExperience = 0;
        stats.CurrentExperience = temporalCurrentExperience;

        stats.RequiredExperienceNextLevel *= incrementalValue;
        stats.AvailablePoints+=2;
        RefreshUI();
    }

    private void RefreshUI() {
        UIManager.Instance.UpdatePlayerExp(temporalCurrentExperience, stats.RequiredExperienceNextLevel);
    }
}
