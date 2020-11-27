using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saves : MonoBehaviour
{
    //privates
    private ItemList list;
    private Trigger trig;

    private void Start()
    {
        list = FindObjectOfType<ItemList>();
        trig = FindObjectOfType<Trigger>();

    }
    public void SaveEverything()
    {
        list.Save();
        trig.Save();
    }
}
