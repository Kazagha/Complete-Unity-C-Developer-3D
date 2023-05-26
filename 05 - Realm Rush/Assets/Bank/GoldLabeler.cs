using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldLabeler : MonoBehaviour
{        
    TextMeshProUGUI label;

    private void Awake()
    {
        //label = GetComponent<TextMeshPro>();
        label = GetComponent<TextMeshProUGUI>();
    }

    public void DisplayGold(int gold)
    {
        label.SetText(string.Format("Gold: {0}", gold));
    }

}
