using System;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;


    public Button removeButton;
    private Item item;

    public void Additem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public float SellItem(Item newItem, float sum)
    {
        if (item != null)
        {
            item.Sell();
            switch (item.name)
            {
                case "Copper":
                    return sum += 4;
                case "Tin":
                    return sum += 8;
                case "Iron":
                    return sum += 12;
                default:
                    return sum += 0;
            }
            
            
        }

        return 0;
    }
}
