using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, ISaveable<InventoryData>
{
    #region Singleton

    public Sprite[] spriteArray;
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory is running");
        }

        instance = this;
    }

    #endregion

    public delegate void onItemChanged();

    public onItemChanged onItemChangedCallback;

    public int space = 8;

    public Item Copper;
    public Item Tin;
    public Item Iron;

    public List<Item> items = new List<Item>();

    public void Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Cargo is Full.");
                return;
            }

            if (item.name == "Dirt")
                return;


            // Debug.Log("adding " + item.name + " to the inventory");
            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public InventoryData OnSave()
    {
        var data = new InventoryData();
        var itemsCount = items.Count;
        data.itemsCount = itemsCount;
        data.itemsIDs = new int[itemsCount];
        for (var i = 0; i < itemsCount; i++)
        {
            data.itemsIDs[i] = ItemToID(items[i]);
        }

        return data;
    }

    private int ItemToID(Item item)
    {
        var name = item.name;
        var id = name switch
        {
            "Dirt" => 0,
            "Stone" => 1,
            "Copper" => 2,
            "Tin" => 3,
            "Iron" => 4,
            "Nickel" => 5,
            "Aluminium" => 6,
            "Silver" => 7,
            "Gold" => 8,
            "Platinum" => 9,
            "Iridium" => 10,
            _ => 0
        };
        return id;
    }

    public void OnLoad(InventoryData data)
    {
        var itemsCount = data.itemsCount;
        for (var i = 0; i < itemsCount; i++)
        {
            Add(IdToItem(data.itemsIDs[i]));
        }
    }

    private Item IdToItem(int id)
    {
        var item = id switch
        {
            //0 => dirt,
            //1 => stone,
            2 => Copper,
            3 => Tin,
            4 => Iron,
            //5 => nickel,
            //6 => aluminium,
            //7 => silver,
            //8 => gold,
            //9 => platinum,
            //10 => iridium,
            _ => Tin
        };
        return item;
    }
}