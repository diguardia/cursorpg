using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerStats stats;
    public PlayerLife PlayerLife {get; private set;}
    public PlayerMana PlayerMana {get; private set;}
    public PlayerAnimation PlayerAnimation {get; private set;}

    internal void ComeBackToLife()
    {
        PlayerLife.RestorePlayer();
        PlayerAnimation.ComeBackToLife();
        PlayerMana.RestorePlayer();
    }

    private void Awake() {
        PlayerLife = GetComponent<PlayerLife>();
        PlayerMana = GetComponent<PlayerMana>();
        PlayerAnimation = GetComponent<PlayerAnimation>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnEnable() {
        ButtonAddAttribute.AddAttributeEvent += AttributeAddResponse;
    }

    private void OnDisable() {
        ButtonAddAttribute.AddAttributeEvent -= AttributeAddResponse;        
    }

    private void AttributeAddResponse(AttributeType type)
    {
        if (stats.AvailablePoints<=0) { return; }

        stats.AvailablePoints--;
        switch (type)
        {
            case AttributeType.Strength:
                stats.Strength++;
                stats.UpgradeByStrength();
                break;
            case AttributeType.Intelligence:
                stats.Intelligence++;
                stats.UpgradeByIntelligence();
                break;
            case AttributeType.Dexterity:
                stats.Dexterity++;
                stats.UpgradeByDexterity();
                break;
               
        }


    }
}
