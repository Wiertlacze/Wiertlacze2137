using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class UndergroundGeneration : MonoBehaviour, ISaveable<BreakableGroundData>
{
    public Transform player;
    public GameObject dirt;
    public GameObject stone;
    public GameObject granite;
    public GameObject bedrock;
    public GameObject copper;
    public GameObject iron;
    public GameObject tin;
    public GameObject silver;
    public GameObject gold;
    public GameObject aluminium;
    public GameObject nickel;
    public GameObject platinum;
    public GameObject iridium;
    public Transform breakableGround;
    public Transform undergroundBackground;
    public float offset = 4f;
    public float lowestReached = 1f;
    int randomizer = 0;

    private void Awake()
    {
        for (int y = -1; y > -4; --y)
        {
            for (int x = 0; x < 56; ++x)
            {
                randomizer = Random.Range(0, 100);

                Instantiate(dirt, new Vector3(-27.5f + x, y, -1), Quaternion.identity, undergroundBackground);

                if (randomizer < 75)
                {
                    Instantiate(dirt, new Vector3(-27.5f + x, y, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 75 && randomizer < 85)
                {
                    Instantiate(copper, new Vector3(-27.5f + x, y, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 85 && randomizer < 95)
                {
                    Instantiate(tin, new Vector3(-27.5f + x, y, -2), Quaternion.identity, breakableGround);
                }
                else
                {
                    Instantiate(iron, new Vector3(-27.5f + x, y, -2), Quaternion.identity, breakableGround);
                }
            }
        }
    }

    public BreakableGroundData OnSave()
    {
        var data = new BreakableGroundData();
        data.LowestReached = lowestReached;

        var blocksCount = breakableGround.childCount;
        data.BlocksCount = blocksCount;
        data.BlockTypes = new int[blocksCount];
        data.BlockPositions = new float[blocksCount, 2];
        var index = 0;
        foreach (Transform block in breakableGround)
        {
            data.BlockTypes[index] = GetBlockTypeId(block.name);
            var position = block.position;
            data.BlockPositions[index, 0] = position.x;
            data.BlockPositions[index, 1] = position.y;
            index++;
        }

        return data;
    }

    private static int GetBlockTypeId(string name)
    {
        var endIndex = name.IndexOf("Tile", StringComparison.Ordinal);
        var cleanName = name.Substring(0, endIndex);
        var id = cleanName switch
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

    public void OnLoad(BreakableGroundData data)
    {
        lowestReached = data.LowestReached;
        foreach (Transform block in breakableGround)
        {
            Destroy(block.gameObject);
        }

        foreach (Transform background in undergroundBackground)
        {
            if (background.position.y < -3)
            {
                Destroy(background.gameObject);
            }
        }

        var blocksCount = data.BlocksCount;
        for (var i = 0; i < blocksCount; i++)
        {
            var type = data.BlockTypes[i];
            var position = new Vector2(data.BlockPositions[i, 0], data.BlockPositions[i, 1]);
            var block = GetBlockById(type);
            Instantiate(block, new Vector3(position.x, position.y, -2), Quaternion.identity,
                breakableGround);
        }

        for (var level = -4; level > lowestReached - offset - 1; level--)
        {
            var background = GetBackgroundByHeight(level);
            for (var x = 0; x < 40; ++x)
            {
                Instantiate(background, new Vector3(-19.5f + x, level, -1), Quaternion.identity,
                    undergroundBackground);
            }
        }
    }

    private GameObject GetBlockById(int id)
    {
        var block = id switch
        {
            0 => dirt,
            1 => stone,
            2 => copper,
            3 => tin,
            4 => iron,
            5 => nickel,
            6 => aluminium,
            7 => silver,
            8 => gold,
            9 => platinum,
            10 => iridium,
            _ => dirt
        };

        return block;
    }

    private GameObject GetBackgroundByHeight(float height)
    {
        if (height > -50.0f)
        {
            return dirt;
        }

        if (height > -150.0f)
        {
            return stone;
        }

        return height > -300.0f ? granite : bedrock;
    }

    // Update is called once per frame
    void Update()
    {
        if (lowestReached > player.position.y && lowestReached > -50f)
        {
            lowestReached = Mathf.Floor(player.position.y);
            for (int x = 0; x < 56; ++x)
            {
                randomizer = Random.Range(0, 100);

                Instantiate(dirt, new Vector3(-27.5f + x, lowestReached - offset, -1), Quaternion.identity,
                    undergroundBackground);

                if (randomizer < 75)
                {
                    Instantiate(dirt, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else if (randomizer >= 75 && randomizer < 85)
                {
                    Instantiate(copper, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else if (randomizer >= 85 && randomizer < 95)
                {
                    Instantiate(tin, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else
                {
                    Instantiate(iron, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
            }
        }
        else if (lowestReached > player.position.y && lowestReached > -150f)
        {
            lowestReached = Mathf.Floor(player.position.y);
            for (int x = 0; x < 56; ++x)
            {
                randomizer = Random.Range(0, 100);

                Instantiate(stone, new Vector3(-27.5f + x, lowestReached - offset, -1), Quaternion.identity,
                    undergroundBackground);

                if (randomizer < 60)
                {
                    Instantiate(stone, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else if (randomizer >= 60 && randomizer < 70)
                {
                    Instantiate(copper, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else if (randomizer >= 70 && randomizer < 80)
                {
                    Instantiate(tin, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else if (randomizer >= 80 && randomizer < 90)
                {
                    Instantiate(iron, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else if (randomizer >= 90 && randomizer < 95)
                {
                    Instantiate(nickel, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else
                {
                    Instantiate(aluminium, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
            }
        }
        else if (lowestReached > player.position.y && lowestReached > -300f)
        {
            lowestReached = Mathf.Floor(player.position.y);
            for (int x = 0; x < 56; ++x)
            {
                randomizer = Random.Range(0, 100);

                Instantiate(granite, new Vector3(-27.5f + x, lowestReached - offset, -1), Quaternion.identity,
                    undergroundBackground);

                if (randomizer < 40)
                {
                    Instantiate(granite, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else if (randomizer >= 40 && randomizer < 50)
                {
                    Instantiate(copper, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else if (randomizer >= 50 && randomizer < 60)
                {
                    Instantiate(tin, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else if (randomizer >= 60 && randomizer < 70)
                {
                    Instantiate(iron, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else if (randomizer >= 70 && randomizer < 80)
                {
                    Instantiate(nickel, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else if (randomizer >= 80 && randomizer < 90)
                {
                    Instantiate(aluminium, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else if (randomizer >= 90 && randomizer < 95)
                {
                    Instantiate(silver, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else
                {
                    Instantiate(gold, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
            }
        }
        else if (lowestReached > player.position.y)
        {
            lowestReached = Mathf.Floor(player.position.y);
            for (int x = 0; x < 56; ++x)
            {
                randomizer = Random.Range(0, 100);

                Instantiate(bedrock, new Vector3(-27.5f + x, lowestReached - offset, -1), Quaternion.identity,
                    undergroundBackground);

                if (randomizer < 30)
                {
                    Instantiate(bedrock, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else if (randomizer >= 30 && randomizer < 35)
                {
                    Instantiate(copper, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else if (randomizer >= 35 && randomizer < 40)
                {
                    Instantiate(tin, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else if (randomizer >= 40 && randomizer < 50)
                {
                    Instantiate(iron, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else if (randomizer >= 50 && randomizer < 60)
                {
                    Instantiate(nickel, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else if (randomizer >= 60 && randomizer < 70)
                {
                    Instantiate(aluminium, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else if (randomizer >= 70 && randomizer < 80)
                {
                    Instantiate(silver, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else if (randomizer >= 80 && randomizer < 90)
                {
                    Instantiate(gold, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else if (randomizer >= 90 && randomizer < 95)
                {
                    Instantiate(platinum, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
                else
                {
                    Instantiate(iridium, new Vector3(-27.5f + x, lowestReached - offset, -2), Quaternion.identity,
                        breakableGround);
                }
            }
        }
    }
}