using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{

    StatsManagement statsManagement;
    private Slider slider;

    void Awake()
    {
        statsManagement = GameObject.FindWithTag("Player").GetComponent<StatsManagement>();
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        if (slider.value > statsManagement.health)
        {
            slider.value -= 15f * Time.deltaTime;
        }
    }
}
