using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthBar : MonoBehaviour
{
    public GameObject player;
    public Slider healthSlider;
    public TextMeshProUGUI healthValueText;

    void Start()
    {
        healthSlider.minValue = 0;
        player = FindObjectOfType<PlayerHealth>().gameObject;
        healthSlider.maxValue = player.GetComponent<PlayerHealth>().maxHealth;
    }
    void Update()
    {
        healthSlider.value = player.GetComponent<PlayerHealth>().health;
        healthValueText.text = player.GetComponent<PlayerHealth>().health.ToString() + " / " + player.GetComponent<PlayerHealth>().maxHealth.ToString();
    }
}