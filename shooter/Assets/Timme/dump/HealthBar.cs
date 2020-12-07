using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject mainCamera, enemy, UI;
    public Slider healthSlider;
    public bool sliderOn;
    private bool gettingDestroyed;

    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        healthSlider.maxValue = enemy.GetComponent<EnemyHealth>().maxHealth;
        healthSlider.minValue = 0;
        sliderOn = PlayerPrefs.GetInt("damageNumbersBool") != 0;
    }
    void Update()
    {
        transform.LookAt(mainCamera.transform.position);
        healthSlider.gameObject.SetActive(sliderOn);
        healthSlider.value = enemy.GetComponent<EnemyHealth>().health;
        if (enemy.GetComponent<EnemyHealth>().health <= 0)
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
        Destroy(gameObject);
        Destroy(healthSlider);
        Destroy(UI);
    }
}
