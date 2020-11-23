using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Index : MonoBehaviour
{
    public List<GameObject> items, index, index2;
    public ItemList itemslist;

    public void AddItem()
    {
        for(int i = 0; i < itemslist.itemQuantity.Count; i++)
        {
            if (itemslist.itemQuantity[i] > 0)
            {
                if (!index.Contains(items[i]))
                {
                    index.Add(items[i]);
                    index2[i] = Instantiate(index[i], transform);
                }
                index2[i].GetComponentInChildren<TextMeshProUGUI>().text = itemslist.itemQuantity[i].ToString();
            }
        }
    }
}
