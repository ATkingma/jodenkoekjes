using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Options : MonoBehaviour

{
    public GameObject x;
    public Dropdown resolutionDropDown;
    Resolution[] resolutions;

    //saves
    public Slider mouse;
    public Toggle damageNumersToggle, enemyHealthBar;

    //privates
    private CameraController cam;

    public void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();

        //camera
        if(FindObjectOfType<CameraController>())
        {
            cam = FindObjectOfType<CameraController>();
        }
        mouse.value = PlayerPrefs.GetFloat("sensitivity", 10);

        //damage numebrs
        damageNumersToggle.isOn = PlayerPrefs.GetInt("damageNumbersBool") != 0;

        //enemy slider
        enemyHealthBar.isOn = PlayerPrefs.GetInt("EnemyHealthBarOn") != 0;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        if (isFullscreen == true)
        {
            x.SetActive(true);
        }
        if (isFullscreen == false)
        {
            x.SetActive(false);
        }
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetSensitivity(Slider slider)
    {
        if (FindObjectOfType<CameraController>())
        {
            cam.sliderValue = slider.value;
        }
        PlayerPrefs.SetFloat("sensitivity", slider.value);
    }
    //damage numbers
    public void DamageNumbers(Toggle Check)
    {
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
        foreach(EnemyHealth enemy in enemies)
        {
            enemy.damageNumbersBool = Check.isOn;
        }
        PlayerPrefs.SetInt("damageNumbersBool", Check.isOn ? 1 : 0);
    }
    //health slider
    public void EnemyHealthBars(Toggle Check)
    {
        HealthBar[] enemies = FindObjectsOfType<HealthBar>();
        foreach (HealthBar enemy in enemies)
        {
            enemy.sliderOn = Check.isOn;
        }
        PlayerPrefs.SetInt("EnemyHealthBarOn", Check.isOn ? 1 : 0);
    }
}
