using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saves : MonoBehaviour
{
    //privates
    private ItemList list;

    private void Start()
    {
        list = FindObjectOfType<ItemList>();
    }
    public void SaveEverything()
    {
        list.Save();

    }
}
