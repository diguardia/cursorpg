using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private PlayerStats stats;

    [Header("Pannels")]
    [SerializeField] private GameObject pannelStats;
    [SerializeField] private GameObject inventoryPannel;

    [Header("Bar")]
    [SerializeField] private Image playerLife;
    [SerializeField] private Image playerMana;
    [SerializeField] private Image playerExp;
    
    
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI lifeLabel;
    [SerializeField] private TextMeshProUGUI manaLabel;
    [SerializeField] private TextMeshProUGUI expLabel;
    [SerializeField] private TextMeshProUGUI LevelLabel;
    

    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI statsDamage;
    [SerializeField] private TextMeshProUGUI statsDefense;
    [SerializeField] private TextMeshProUGUI statsCritical;
    [SerializeField] private TextMeshProUGUI statsBlocking;
    [SerializeField] private TextMeshProUGUI statsSpeed;
    [SerializeField] private TextMeshProUGUI statsLevel;
    [SerializeField] private TextMeshProUGUI statsExp;
    [SerializeField] private TextMeshProUGUI statsReqExp;

    [Header("Attributes")]
    [SerializeField] private TextMeshProUGUI statsStrength;
    [SerializeField] private TextMeshProUGUI statsIntelligence;
    [SerializeField] private TextMeshProUGUI statsDexterity;
    [SerializeField] private TextMeshProUGUI statsAvailablePoints;
    


    private float currentLife;
    private float maxLife;

    private float currentMana;
    private float maxMana;

    private float currentExp;
    private float maxExp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUILifePlayer();
        UpdatePannelStats();
    }

    private void UpdateUILifePlayer() {
        playerLife.fillAmount = Mathf.Lerp(playerLife.fillAmount, currentLife / maxLife
                                            , 10 * Time.deltaTime ) ;

        lifeLabel.text = $"{currentLife}/{maxLife}";

        playerMana.fillAmount = Mathf.Lerp(playerMana.fillAmount, currentMana / maxMana
                                            , 10 * Time.deltaTime ) ;

        manaLabel.text = $"{currentMana}/{maxMana}";

        playerExp.fillAmount = Mathf.Lerp(playerExp.fillAmount, currentExp / maxExp
                                            , 10 * Time.deltaTime ) ;

        expLabel.text = $"{(currentExp/maxExp*100):F2}%";
        
        LevelLabel.text = $"LEVEL {stats.Level}";
    }

    public void UpdatePlayerLife(float pCurrentLife, float pMaxLife) {
        currentLife = pCurrentLife;
        maxLife = pMaxLife;
    }
    public void UpdatePlayerMana(float pCurrentMana, float pMaxMana) {
        currentMana = pCurrentMana;
        maxMana = pMaxMana;
    }
    public void UpdatePlayerExp(float pCurrentExp, float pMaxExp) {
        currentExp = pCurrentExp;
        maxExp = pMaxExp;
    }
    public void UpdatePannelStats() {
        if (!pannelStats.activeSelf) { return; }

        statsDamage.text = stats.Damage.ToString();
        statsDefense.text = stats.Defense.ToString();
        statsCritical.text = $"{stats.PercentageCritical}%";
        statsBlocking.text = $"{stats.PercentageBlocking}%";
        statsSpeed.text = stats.Speed.ToString();
        statsLevel.text = stats.Level.ToString();
        statsExp.text = stats.CurrentExperience.ToString();
        statsReqExp.text = stats.RequiredExperienceNextLevel.ToString();

        statsStrength.text = stats.Strength.ToString();
        statsIntelligence.text = stats.Intelligence.ToString();
        statsDexterity.text = stats.Dexterity.ToString();
        
        statsAvailablePoints.text = $"Available points: {stats.AvailablePoints}";
    }

    #region Pannels
    public void OpenCloseStatsPannel() {
        pannelStats.SetActive(!pannelStats.activeSelf);
    }
    
    public void OpenCloseInventoryPannel() {
        inventoryPannel.SetActive(!inventoryPannel.activeSelf);

    }
    
    #endregion
}
