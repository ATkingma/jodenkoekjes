using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saves : MonoBehaviour
{
    public List<int> enemiesKilled, killedBy;
    //list
    //0 = goblin; 1 = fire elemental; 2 = groot; 3 = golem; 4 = boss; 5 = final boss;
    //0 = pistol; 1 = launcher; 2 = rifle; 3 = staff;

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
    public void AddKilledBy(int gun)
    {
        for(int i = 0; i < killedBy.Count; i++)
        {
            killedBy[i] = PlayerPrefs.GetInt("gun" + i, 0);
        }
        killedBy[gun]++;
        print(killedBy[gun]);
        for (int i = 0; i < killedBy.Count; i++)
        {
            PlayerPrefs.SetInt("gun" + i, killedBy[i]);
        }
    }
    public void AddKill(int enemy)
    {
        enemiesKilled[0]++;
        enemiesKilled[enemy]++;
    }
}
