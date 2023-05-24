using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldLabeler : MonoBehaviour
{        
    TextMeshPro label;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
    }

    public void DisplayGold(int gold)
    {
        label.SetText(string.Format("Gold: {0}", gold));
    }

}
