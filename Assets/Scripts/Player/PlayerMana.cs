using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    [SerializeField] private float initialMana;
    [SerializeField] private float maxMana;
    [SerializeField] private float regenerationPerSecond;
    
    private PlayerLife playerLife;
    public float Mana { get; private set; }

    private void Awake() {
        playerLife = GetComponent<PlayerLife>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Mana = initialMana;
        UpdateManaUI();
        InvokeRepeating(nameof(RegenerateMana), 1, 1);
    }

    public void UseMana(float amount) {
        if (Mana >= amount) {
            Mana-=amount;
            UpdateManaUI();
        }
    }

    public void UpdateManaUI() {
        UIManager.Instance.UpdatePlayerMana(Mana, maxMana);
    }

    public void Update() {
        if (Input.GetKeyUp(KeyCode.G)) {
            UseMana(10);
        }
    }

    public void RegenerateMana() {
        if (!playerLife.IsDefeated && Mana < maxMana) {
            Mana += regenerationPerSecond;
            UpdateManaUI();
        }
    }

    public void RestorePlayer() {
        Mana = initialMana;
        UpdateManaUI();
    }
}
