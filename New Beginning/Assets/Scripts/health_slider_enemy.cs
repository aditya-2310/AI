using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_slider_enemy : MonoBehaviour
{
    public Slider health_slider;

    public void setMaxHealth(float health)
    {
        health_slider.value = health;
    }
}
