using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarController : Singleton<HPBarController>
{
    [SerializeField] private Image sliderImage;

    public void SetPercent(float percent)
    {
        sliderImage.fillAmount = percent;
    }
}
