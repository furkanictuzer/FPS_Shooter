using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    public void SetText(string str)
    {
        text.SetText(str);
    }
}
