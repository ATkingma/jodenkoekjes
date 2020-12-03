using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    public bool isNormalMap;
    public GameObject UI,bos;
    public Slider healthSlider;
    void Start()
    {
        if (isNormalMap)
        {
            UI.SetActive(false);
        }
        else
        {
            healthSlider.maxValue = bos.GetComponent<EnemyHealth>().maxHealth;
            healthSlider.minValue = 0;
        }
    }
    void Update()
    {
        if (!isNormalMap)
        {
            healthSlider.value = bos.GetComponent<EnemyHealth>().health;
        }
    }
}
