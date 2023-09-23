using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBase : MonoBehaviour
{
    [SerializeField] protected float initialHealth;
    [SerializeField] protected float maxHealth;

    public float Health {get; protected set;}

    public static Action DefeatedEvent;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Health =initialHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceibeDamage(float amount) {
        if (amount <= 0) {return;}
        if (Health > 0 ) { Health -= amount;}

        if (Health <= 0 ) {Defeated();}

        RefreshUI(Health, maxHealth);

    }

    protected virtual void RefreshUI(float health, float maxHealth) {
         
    }

    protected virtual void Defeated() {
    }
}
