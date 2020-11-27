using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public List<float> itemQuantity;

    public void Save()
    {
        for(int i = 0; i < itemQuantity.Count; i++)
        {
            PlayerPrefs.SetFloat("itemQuantity" + i, itemQuantity[i]);
        }
    }
}