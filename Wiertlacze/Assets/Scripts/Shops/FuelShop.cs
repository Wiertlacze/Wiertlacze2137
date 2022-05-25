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
    public float pricePerLiter = 0f;
    private KeyCode escapeKey = KeyCode.Escape;
    private StatsManagement statsManagement;
    public float timeToPriceChange = 0f;
    // Start is called before the first frame update
    void Start()
    {
        statsManagement = GameObject.FindWithTag("Player").GetComponent<StatsManagement>();       
        fuelShopCanvas.SetActive(false);
        pricePerLiter = Random.Range(2f, 3f);
    }

    // Update is called once per frame
    void Update()
    {   
        if (isShopOpen)
        {
            setText();
            CheckClose();
        }
        checkPriceChange();


    }
    private void checkPriceChange()
    {
        timeToPriceChange += Time.deltaTime;
        if (timeToPriceChange > 120f)
        {
            timeToPriceChange = 0f;
            pricePerLiter = Random.Range(2f, 3f);
        }
    }

    private void setText()
    {
        pricePerLiterText.GetComponent<Text>().text = (Mathf.Round(pricePerLiter * 100f) / 100f).ToString() + " $/L";
        fullTankText.GetComponent<Text>().text = Mathf.Round((statsManagement.maxFuel - statsManagement.fuel) * pricePerLiter).ToString() + "$";
        currentTankText.GetComponent<Text>().text = Mathf.Round(statsManagement.fuel) + "/" + statsManagement.maxFuel + "L";
        currentMoneyText.GetComponent<Text>().text = statsManagement.money + "$";       
    }  
    public void OpenShop()
    {
        statsManagement.IsInventory = true;
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
            if (Input.GetKeyDown(escapeKey) || Input.GetKeyDown("m"))
            {
                
                Time.timeScale = 1f;
                isShopOpen = false;
                fuelShopCanvas.SetActive(false);
                playerUI.SetActive(true);
                statsManagement.IsInventory = false;               
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
            statsManagement.money -= Mathf.Round(litersNeeded * pricePerLiter);
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
            statsManagement.money -= Mathf.Round(litersNeeded * pricePerLiter);
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
