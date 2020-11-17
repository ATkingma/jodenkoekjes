using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject mainCamera, enemy;
    public Slider healthSlider;

    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        healthSlider.maxValue = enemy.GetComponent<EnemyHealth>().maxHealth;
        healthSlider.minValue = 0;
    }
    void Update()
    {
        transform.LookAt(mainCamera.transform.position);
       // healthSlider.value = enemy.GetComponent<EnemyHealth>().health;
    }
}
