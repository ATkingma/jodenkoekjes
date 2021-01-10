using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    public bool isNormalMap;
    public GameObject UI,bos;
    public Slider healthSlider;
    private bool gettingDestroyed,homieIsDood;
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
        if (!homieIsDood)
        {
            if (!isNormalMap)
            {
                    healthSlider.value = bos.GetComponent<EnemyHealth>().health;
            }
            if (bos.GetComponent<EnemyHealth>().health <= 0)
            {
                homieIsDood = true;
                gameObject.GetComponent<BossBar>().enabled = false;
            }
        }
        if (bos.GetComponent<EnemyHealth>().health <= 0)
        {
            if (!gettingDestroyed)
            {
                Invoke("DestroyBar", 0.1f);
                gettingDestroyed = true;
            }
        }
    }
    public void DestroyBar()
    {
        Destroy(healthSlider);
        Destroy(UI);
    }
}
