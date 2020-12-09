using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saves : MonoBehaviour
{
    //privates
    private ItemList list;
    private Trigger trig;
    private Index index;

    private void Awake()
    {
        list = FindObjectOfType<ItemList>();
        trig = FindObjectOfType<Trigger>();
        index = FindObjectOfType<Index>();
        list.GetSaves();
        trig.GetSaves();
        index.AddItem();
    }
    public void SaveEverything()
    {
        list.Save();
        trig.Save();
    }
    public void ClearSaves()
    {
        list.DeleteSaves();
        trig.DeleteSaves();
    }
}
