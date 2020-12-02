using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public GameObject Player;
    public Slider healthSlider;
    void Start()
    {
        healthSlider.minValue = 0;
        healthSlider.maxValue = Player.GetComponent<PlayerHealth>().maxHealth;
    }
    void Update()
    {
        healthSlider.value = Player.GetComponent<PlayerHealth>().health;
    }
}