using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    [SerializeField] private Image sliderImage;
    
    public void SetPercent(float percent)
    {
        sliderImage.fillAmount = percent;
    }
}
