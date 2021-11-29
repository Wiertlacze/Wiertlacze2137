using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelShop : MonoBehaviour
{
    public bool isShopOpen = false;
    public GameObject fuelShopCanvas;
    public GameObject playerUI;
    public GameObject pricePerLiterText;
    public GameObject fullTankText;
    public GameObject currentTankText;
    public GameObject currentMoneyText;
    public GameObject notEnoughMoneyText;
    public float pricePerLiter = 2.30f;
    private KeyCode escapeKey = KeyCode.Backspace;
    private StatsManagement statsManagement;
    // Start is called before the first frame update
    void Start()
    {
        statsManagement = GameObject.FindWithTag("Player").GetComponent<StatsManagement>();
        notEnoughMoneyText.SetActive(false);
        fuelShopCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckClose();
        if (isShopOpen)
        {
            setText();
        }
    }

    private void setText()
    {
        pricePerLiterText.GetComponent<Text>().text = pricePerLiter.ToString() + " $/L";
        fullTankText.GetComponent<Text>().text = Mathf.Round((statsManagement.maxFuel - statsManagement.fuel) * pricePerLiter).ToString() + "$";
        currentTankText.GetComponent<Text>().text = Mathf.Round(statsManagement.fuel) + "/" + statsManagement.maxFuel + "L";
        currentMoneyText.GetComponent<Text>().text = statsManagement.money + "$";       
    }
    private void setNotEnoughFundsText()
    {
        notEnoughMoneyText.SetActive(true);
    }   

    public void OpenShop()
    {
        isShopOpen = true;
        Time.timeScale = 0f;
        fuelShopCanvas.SetActive(true);
        playerUI.SetActive(false);
        
    }

    private void CheckClose()
    {
        if (isShopOpen)
        {
            if (Input.GetKeyDown(escapeKey))
            {
                Time.timeScale = 1f;
                isShopOpen = false;
                fuelShopCanvas.SetActive(false);
                playerUI.SetActive(true);
                notEnoughMoneyText.SetActive(false);
            }
        }
    }

    public void Refuel_One()
    {
        if (IsEnoughMoney(1))
        {
            statsManagement.fuel += 1;
            statsManagement.money -= Mathf.Round(1 * pricePerLiter);
        }
        else setNotEnoughFundsText();
    }
    public void Refuel_Ten()
    {
        if (IsEnoughMoney(10))
        {
            statsManagement.fuel += 10;
            statsManagement.money -= Mathf.Round(10 * pricePerLiter);
        }
        else setNotEnoughFundsText();
    }

    public void Refuel_Half()
    {
        var litersNeeded = (statsManagement.maxFuel - statsManagement.fuel)/2;
        if (IsEnoughMoney(litersNeeded))
        {
            statsManagement.fuel += litersNeeded;
            statsManagement.money = Mathf.Round(litersNeeded * pricePerLiter);
        }
        else setNotEnoughFundsText();
    }
    public void Refuel_Max()
    {
        var litersNeeded = statsManagement.maxFuel - statsManagement.fuel;
        if (IsEnoughMoney(litersNeeded))
        {
            statsManagement.fuel = statsManagement.maxFuel;
            statsManagement.money = Mathf.Round(litersNeeded * pricePerLiter);
        }
        else setNotEnoughFundsText();
            
    }
    private bool IsEnoughMoney(float litersToTank)
    {
        var money = statsManagement.money;
        if (litersToTank * pricePerLiter > money)
        {
            return false;
        }
        return true;
    }
}
