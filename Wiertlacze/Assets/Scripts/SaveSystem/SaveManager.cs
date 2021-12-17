using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private GameObject _player;
    private UndergroundGeneration _undergroundGeneration;

    private void Awake()
    {
        _player ??= GameObject.FindWithTag("Player");
        _undergroundGeneration ??= GetComponent<UndergroundGeneration>();
    }

    private void Start()
    {
        if (SaveSystem.ShouldLoad())
        {
            Load();
        }
    }

    [ContextMenu("Load")]
    private void Load()
    {
        var data = SaveSystem.Load();

        var playerPosition = data.playerPosition;
        _player.transform.position = new Vector3(playerPosition[0], playerPosition[1], playerPosition[2]);

        var playerStats = new PlayerStatsData
        {
            MaxFuel = data.maxFuel,
            Fuel = data.fuel,
            Health = data.health,
            Money = data.money,
            Armor = data.armor
        };
        var stats = _player.GetComponent<StatsManagement>();
        if (stats != null)
        {
            stats.OnLoad(playerStats);
        }

        if (_undergroundGeneration != null)
        {
            var breakableGroundData = new BreakableGroundData();
            breakableGroundData.LowestReached = data.lowestReached;
            var blocksCount = data.blocksCount;
            breakableGroundData.BlocksCount = blocksCount;
            breakableGroundData.BlockTypes = new int[blocksCount];
            breakableGroundData.BlockPositions = new float[blocksCount, 2];
            for (var i = 0; i < blocksCount; i++)
            {
                breakableGroundData.BlockTypes[i] = data.blockTypes[i];
                breakableGroundData.BlockPositions[i, 0] = data.blockPositions[i * 2];
                breakableGroundData.BlockPositions[i, 1] = data.blockPositions[i * 2 + 1];
            }

            _undergroundGeneration.OnLoad(breakableGroundData);
        }

        var inventory = Inventory.instance;
        if (inventory != null)
        {
            var inventoryData = new InventoryData();
            inventoryData.itemsCount = data.itemsCount;
            inventoryData.itemsIDs = new int[data.itemsCount];
            for (var i = 0; i < data.itemsCount; i++)
            {
                inventoryData.itemsIDs[i] = data.itemsIDs[i];
            }

            inventory.OnLoad(inventoryData);
        }
    }

    [ContextMenu("Save")]
    public void Save()
    {
        var data = new SaveData();

        var playerPosition = _player.transform.position;
        data.playerPosition = new float[3];
        data.playerPosition[0] = playerPosition.x;
        data.playerPosition[1] = playerPosition.y;
        data.playerPosition[2] = playerPosition.z;

        var stats = _player.GetComponent<StatsManagement>();
        if (stats != null)
        {
            var playerStats = stats.OnSave();
            data.maxFuel = playerStats.MaxFuel;
            data.fuel = playerStats.Fuel;
            data.health = playerStats.Health;
            data.money = playerStats.Money;
            data.armor = playerStats.Armor;
        }

        if (_undergroundGeneration)
        {
            var blocksData = _undergroundGeneration.OnSave();
            data.lowestReached = blocksData.LowestReached;
            var blocksCount = blocksData.BlocksCount;
            data.blocksCount = blocksCount;
            data.blockTypes = new int[blocksCount];
            data.blockPositions = new float[blocksCount * 2];
            for (var i = 0; i < blocksCount; i++)
            {
                data.blockTypes[i] = blocksData.BlockTypes[i];
                data.blockPositions[i * 2] = blocksData.BlockPositions[i, 0];
                data.blockPositions[i * 2 + 1] = blocksData.BlockPositions[i, 1];
            }
        }

        var inventory = Inventory.instance;
        if (inventory != null)
        {
            var inventoryData = inventory.OnSave();
            data.itemsCount = inventoryData.itemsCount;
            data.itemsIDs = new int[inventoryData.itemsCount];
            for (var i = 0; i < data.itemsCount; i++)
            {
                data.itemsIDs[i] = inventoryData.itemsIDs[i];
            }
        }

        SaveSystem.Save(data);
    }
}