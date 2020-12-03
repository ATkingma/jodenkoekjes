using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Index : MonoBehaviour
{
    public List<GameObject> items, index;
    public List<int> itemCheck;
    public ItemList itemslist;
    public Image itemindex, tab;

    //privates
    private int itemCount;
    private void Start()
    {
        List<GameObject> items = new List<GameObject>();
        List<GameObject> index = new List<GameObject>();
    }

    public void AddItem()
    {
        for(int i = 0; i < itemslist.itemQuantity.Count; i++)
        {
            if (itemslist.itemQuantity[i] > 0)
            {
                if (!itemCheck.Contains(i))
                {
                    itemCheck.Add(i);
                    index[i] = Instantiate(items[i], transform);
                    itemCount++;
                }
                index[i].GetComponentInChildren<TextMeshProUGUI>().text = itemslist.itemQuantity[i].ToString();
                GetComponent<RectTransform>().sizeDelta = new Vector2(150 * itemCount, 150);
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
                index[i].SetActive(Input.GetButton("TAB"));
            }
        }
    }
}
