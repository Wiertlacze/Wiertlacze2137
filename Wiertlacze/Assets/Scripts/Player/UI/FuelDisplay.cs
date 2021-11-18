using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelDisplay : MonoBehaviour
{

    BaseStats baseStats;
    private Slider slider;

    void Awake()
    {
        baseStats = GameObject.FindWithTag("Player").GetComponent<BaseStats>();
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = baseStats.fuel;
    }
}
