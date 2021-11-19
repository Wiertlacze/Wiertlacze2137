using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{

    StatsManagement statsManagement;
    Text moneyDisplay;

    void Awake()
    {
        statsManagement = GameObject.FindWithTag("Player").GetComponent<StatsManagement>();
        moneyDisplay = GetComponent<Text>();
    }

    void Update()
    {
        moneyDisplay.text = statsManagement.money + "$";
    }
}
