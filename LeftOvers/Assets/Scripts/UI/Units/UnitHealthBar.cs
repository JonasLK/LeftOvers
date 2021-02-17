using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnitHealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        gradient.Evaluate(1f);
    }

    internal void SetMaxHealth(float fighterTotalHealth)
    {
        throw new NotImplementedException();
    }

    internal void SetHealth(float currentHealth)
    {
        throw new NotImplementedException();
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
