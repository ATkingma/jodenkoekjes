using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Index : MonoBehaviour
{
    public List<GameObject> items, index, index2;
    public ItemList itemslist;

    public Image itemindex, tab;

    //privates
    private int itemCount;

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
                    itemCount++;
                }
                index2[i].GetComponentInChildren<TextMeshProUGUI>().text = itemslist.itemQuantity[i].ToString();
                GetComponent<RectTransform>().sizeDelta = new Vector2(130 * itemCount, 100);
            }
        }
    }
    private void Update()
    {
        itemindex.enabled = Input.GetButton("TAB");
        tab.enabled = Input.GetButton("TAB");
        for (int i = 0; i < itemslist.itemQuantity.Count; i++)
        {
            if (itemslist.itemQuantity[i] > 0)
            {
                index2[i].SetActive(Input.GetButton("TAB"));
            }
        }
    }
}
