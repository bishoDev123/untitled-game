using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthbarController : MonoBehaviour
{
    public Slider slider;
    public Vector3 offset;

    public void SetHealth(float currentHealth, float maxHealth)
    {
        slider.value = currentHealth;
        slider.maxValue = maxHealth;
    }
  
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);  
    }
}
