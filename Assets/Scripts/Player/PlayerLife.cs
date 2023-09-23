using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : LifeBase
{
    public bool IsDefeated { get; private set; }
    public bool CanBeCured() => Health < maxHealth;
    private BoxCollider2D boxCollider2D;

    void Awake () {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    protected override void Start()
    {
        base.Start();
        RefreshUI(Health, maxHealth);
    }
    private void Update() {
        if (IsDefeated) { return; }
        if (Input.GetKeyDown(KeyCode.T)){
            ReceibeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.Y)){
            RestoreHealth(10);
        }
    }   
    public void RestoreHealth(float amount) {
        if (CanBeCured()) {
            Health += amount;
            if (Health >= maxHealth) {Health = maxHealth;}
            RefreshUI(Health, maxHealth);
         }
    }

    override protected void RefreshUI(float health, float maxHealth){
        UIManager.Instance.UpdatePlayerLife(health, maxHealth);
    }

    protected override void Defeated()
    {
        IsDefeated = true;
        boxCollider2D.enabled = false;
        DefeatedEvent?.Invoke();
    }

    public void RestorePlayer() {
        IsDefeated = false;
        boxCollider2D.enabled = true;
        Health = initialHealth;
        RefreshUI(Health, maxHealth);
    }


}