using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    /// <summary>
    /// Sets the max value for the slider
    /// </summary>
    /// <param name="health">
    /// The value to set the max to
    /// </param>
    public void SetMaxHealthUI(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    /// <summary>
    /// Sets the current value of the slider and sets the current health
    /// </summary>
    /// <param name="health">
    /// The value to set the slider to
    /// </param>
    public void SetHealthUI(int health)
    {
        slider.value = health;
    }

}
