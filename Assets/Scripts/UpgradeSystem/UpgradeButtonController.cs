using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonController : MonoBehaviour
{
    [SerializeField] private UpgradeInfo upgradeInfo;
    [SerializeField] private Button button;
    
    [SerializeField] private int level = 1;
    [SerializeField] private TextMeshProUGUI nameText;

    private void Awake()
    {
        SetName();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(Upgrade);

        EventManager.TalentPointChanged += CheckUpgradeable;
        
        CheckUpgradeable();
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(Upgrade);
        
        EventManager.TalentPointChanged -= CheckUpgradeable;
    }

    private void CheckUpgradeable()
    {
        int talentPoint = TalentController.instance.TalentPoint;
        
        CheckUpgradeable(talentPoint);
    }
    
    private void SetName()
    {
        nameText.SetText(upgradeInfo.upgradeName);
    }

    private void CheckUpgradeable(int talentPoint)
    {
        int requiredPoint = upgradeInfo.GetValue(level).requiredPoint;
        
        bool hasLevelToUpgrade = upgradeInfo.HasLevelToUpgrade(level, out _);

        if (!hasLevelToUpgrade)
        {
            //Fully upgrade
            Debug.Log("Fully upgrade");
            Deactivate();
        }
        else if (requiredPoint > talentPoint)
        {
            //There is no enough talentPoint.
            Debug.Log("There is no enough talentPoint");
            Deactivate();
        }
        else
        {
            Activate();
        }
    }

    private void Activate()
    {
        button.interactable = true;
    }
    private void Deactivate()
    {
        button.interactable = false;
    }

    public void Initialize()
    {
        List<float> upgradeValues = upgradeInfo.GetValue(level).values;
        
        UpgradeController.instance.Upgrade(upgradeInfo.GetUpgradeType(), upgradeValues);
        
        CheckUpgradeable();
    }
    
    private void Upgrade()
    {
        int requiredPoint = upgradeInfo.GetValue(level).requiredPoint;
        
        level++;
        
        TalentController.instance.AddTalentPoint(-requiredPoint);
        
        List<float> upgradeValues = upgradeInfo.GetValue(level).values;
        
        UpgradeController.instance.Upgrade(upgradeInfo.GetUpgradeType(), upgradeValues);
        
        CheckUpgradeable();
        
        
    }
}
