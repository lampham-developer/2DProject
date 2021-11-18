using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{

    public Slider slider;
    public Color highHealthColor = Color.green;
    public Color lowHealthColor = Color.red;
    float max;
    public Image Fill;

    // Update is called once per frame
    void Update()
    {

    }

    public void setHealthBar(float maxHealth){
        max = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        slider.gameObject.SetActive(true);
    }

    public void setHealth(float health){
        slider.value = health;
        Fill.color = Color.Lerp(lowHealthColor, highHealthColor, (float)health / max);
    }
}
