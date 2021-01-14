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
        int ooga = (int)player.GetComponent<PlayerHealth>().health;
        int ooooga = (int)player.GetComponent<PlayerHealth>().maxHealth;
        healthSlider.value = player.GetComponent<PlayerHealth>().health;
        healthValueText.text = ooga.ToString() + " / " + ooooga.ToString();
        healthSlider.maxValue = player.GetComponent<PlayerHealth>().maxHealth;
    }
}