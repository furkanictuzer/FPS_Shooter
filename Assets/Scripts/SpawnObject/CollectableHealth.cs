using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectableHealth : CollectableObject
{
    [SerializeField] private TextMeshPro bulletAmountInfo;
    
    public int collectableHealth;
    
    private void Start()
    {
        SetAmountInfoText();
    }
    
    public override void Collect(Player player)
    {
        player.Heal(collectableHealth);
        
        DestroyItself();
    }
    
    
    private void SetAmountInfoText()
    {
        bulletAmountInfo.SetText(collectableHealth.ToString());
    }
}
