using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemInfo : MonoBehaviour
{
    public TextMeshProUGUI info;

    public void Test(TextMeshProUGUI UwU)
    {
        info.text = UwU.text;
    }
}
