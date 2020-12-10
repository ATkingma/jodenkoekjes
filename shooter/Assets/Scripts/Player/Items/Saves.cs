using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saves : MonoBehaviour
{
    //privates
    private ItemList list;
    private Trigger trig;
    private Index index;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            list = FindObjectOfType<ItemList>();
            trig = FindObjectOfType<Trigger>();
            index = FindObjectOfType<Index>();
            list.GetSaves();
            trig.GetSaves();
            index.AddItem();
        }
    }
    public void SaveEverything()
    {
        list.Save();
        trig.Save();
    }
    public void ClearSaves()
    {
        PlayerPrefs.SetFloat("seconde", 0);
        PlayerPrefs.SetFloat("minuut", 0);
        PlayerPrefs.SetFloat("uur", 0);
        list.DeleteSaves();
        trig.DeleteSaves();
    }
}
