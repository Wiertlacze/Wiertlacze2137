using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    Inventory inventory;
    public GameObject inventoryUI;
    public StatsManagement stats;

    private InventorySlot[] slots;
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
             inventoryUI.SetActive(!inventoryUI.activeSelf);
        }

        //sell items
        if (Input.GetKey("t"))
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
