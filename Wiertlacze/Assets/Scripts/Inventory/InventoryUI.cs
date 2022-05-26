using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    Inventory inventory;
    public GameObject inventoryUI;
    public StatsManagement stats;
    public GameObject sellingText;
    public StatsManagement statsManagement;
    private bool selling = false;

    private InventorySlot[] slots;
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        
        
        statsManagement = GameObject.FindWithTag("Player").GetComponent<StatsManagement>();
        

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void OpenInv()
    {
        inventoryUI.SetActive(true);
        statsManagement.IsInventory = true;
    }
    void CloseInv()
    {
        inventoryUI.SetActive(false);
        statsManagement.IsInventory = false;
    }

    void Update()
    { 
        
        OpenClose();
        
        //sell items
        if (Input.GetKey("t"))
        {
            if (selling)
            {
                
                float sum = 0;
                for (int i = 0; i < slots.Length; i++)
                {
                    if (i < inventory.items.Count)
                    {
                        // Debug.Log(slots.Length);
                        // Debug.Log(inventory.items.Count);
                        sum = slots[i].SellItem(inventory.items[i], sum);
                        slots[i].ClearSlot();
                    }
                    else
                    {
                        slots[i].ClearSlot();
                    }
                    // Debug.Log(sum);
                }
                // Debug.Log(sum);
                // Debug.Log(stats.money);
                stats.money += sum;
            }
            else
            {
                Debug.Log("You need to be near forge shop");                

            }
            
            
        }

    }

    void OpenClose()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (inventoryUI.activeSelf)
            {
                CloseInv();
                return;
            }         
            OpenInv();
            
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            CloseInv();
        }
    }

    public void openInventorySellOption()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        selling = !selling;
        if (selling)
        {
            sellingText.GetComponent<Text>().text = "Sell all your items here by clicking 'T'!";
        }
        else sellingText.GetComponent<Text>().text = "You can't sell items here!";
    }

    void UpdateUI()
    {
        // Debug.LogWarning("Updating UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].Additem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
    
    
}
