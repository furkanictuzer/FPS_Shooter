using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerXpUIController : MonoBehaviour
{
    [SerializeField] private PlayerBarController xpBar;
    [SerializeField] private TextMeshProUGUI levelText;

    public void SetLevelInfo(float xpPercent, int level)
    {
        xpBar.SetPercent(xpPercent);
        levelText.SetText("Level " + level);
    }

}
