using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelDisplay : MonoBehaviour
{

    StatsManagement statsManagement;
    private Slider slider;

    void Awake()
    {
        statsManagement = GameObject.FindWithTag("Player").GetComponent<StatsManagement>();
        slider = GetComponent<Slider>();
    }
    void Start()
    {
        slider.maxValue = statsManagement.maxFuel;
    }

    void Update()
    {
        slider.value = statsManagement.fuel;
    }
}
