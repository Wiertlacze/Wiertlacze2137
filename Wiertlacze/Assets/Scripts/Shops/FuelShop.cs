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
    public void OpenShop()
    {
        isShopOpen = true;
        Time.timeScale = 0f;
        fuelShopCanvas.SetActive(true);
        playerUI.SetActive(false);
        notEnoughMoneyText.GetComponent<Text>().text = "";

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
            }
        }
    }

    public void Refuel_One()
    {
        if (statsManagement.fuel <= statsManagement.maxFuel - 1)
        {
            if (IsEnoughMoney(1))
            {
                statsManagement.fuel += 1;
                statsManagement.money -= Mathf.Round(1 * pricePerLiter);
            }
            else return;
        }
        else notEnoughMoneyText.GetComponent<Text>().text = "Your tank is already full!";

    }
    public void Refuel_Ten()
    {
        if (statsManagement.fuel <= statsManagement.maxFuel - 10)
        {
            if (IsEnoughMoney(10))
            {
                statsManagement.fuel += 10;
                statsManagement.money -= Mathf.Round(10 * pricePerLiter);
            }
            else return;
        }
        else notEnoughMoneyText.GetComponent<Text>().text = "Your tank is already full!";

    }

    public void Refuel_Half()
    {
        var litersNeeded = (statsManagement.maxFuel - statsManagement.fuel)/2;
        if (litersNeeded < 0) return;
        if (IsEnoughMoney(litersNeeded))
        {
            statsManagement.fuel += litersNeeded;
            statsManagement.money = Mathf.Round(litersNeeded * pricePerLiter);
        }
        else return;
    }
    public void Refuel_Max()
    {
        var litersNeeded = statsManagement.maxFuel - statsManagement.fuel;
        if (litersNeeded < 0) return;
        if (IsEnoughMoney(litersNeeded))
        {
            statsManagement.fuel = statsManagement.maxFuel;
            statsManagement.money = Mathf.Round(litersNeeded * pricePerLiter);
        }
        else return;
    }
    private bool IsEnoughMoney(float litersToTank)
    {
        var money = statsManagement.money;
        if (litersToTank * pricePerLiter > money)
        {
            notEnoughMoneyText.GetComponent<Text>().text = "You don't have funds! Try another option.";
            return false;
        }
        return true;
    }
}