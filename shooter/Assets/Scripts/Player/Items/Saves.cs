using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saves : MonoBehaviour
{
    public List<int> enemiesKilled, killedBy;
    //list
    //0 = all; 1 = goblin; 2 = fire elemental; 3 = groot; 4 = golem; 5 = boss; 6 = final boss;
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
        for (int i = 0; i < killedBy.Count; i++)
        {
            PlayerPrefs.SetInt("gun" + i, killedBy[i]);
        }
    }
    public void AddKill(int enemy)
    {
        for (int i = 0; i < enemiesKilled.Count; i++)
        {
            enemiesKilled[i] = PlayerPrefs.GetInt("enemy" + i, 0);
        }
        enemiesKilled[0]++;
        enemiesKilled[enemy]++;
        for (int i = 0; i < enemiesKilled.Count; i++)
        {
            PlayerPrefs.SetInt("enemy" + i, enemiesKilled[i]);
        }
    }
}
