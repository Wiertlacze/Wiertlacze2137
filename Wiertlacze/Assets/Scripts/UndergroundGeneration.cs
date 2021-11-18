using UnityEngine;

public class UndergroundGeneration : MonoBehaviour
{
    public Transform player;
    public GameObject dirt;
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
    public float offset = 4f;
    public float lowestReached = 1f;
    int randomizer = 0;

    void Start()
    {
        for(int y=-1; y>-4; --y)
        {
            for (int x = 0; x < 40; ++x)
            {
                randomizer = Random.Range(0, 100);
                if (randomizer < 75)
                {
                    Instantiate(dirt, new Vector3(-19.5f + x, y, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 75 && randomizer < 85)
                {
                    Instantiate(copper, new Vector3(-19.5f + x, y, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 85 && randomizer < 95)
                {
                    Instantiate(tin, new Vector3(-19.5f + x, y, -2), Quaternion.identity, breakableGround);
                }
                else
                {
                    Instantiate(iron, new Vector3(-19.5f + x, y, -2), Quaternion.identity, breakableGround);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lowestReached > player.position.y && lowestReached > -50f)
        {
            lowestReached = Mathf.Floor(player.position.y);
            for(int x=0; x<40; ++x) 
            {
                randomizer = Random.Range(0, 100);
                if(randomizer < 75)
                {
                    Instantiate(dirt, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                } 
                else if(randomizer >= 75 && randomizer < 85)
                {
                    Instantiate(copper, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 85 && randomizer < 95)
                {
                    Instantiate(tin, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else
                {
                    Instantiate(iron, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
            }
        }
        else if(lowestReached > player.position.y && lowestReached > -150f)
        {
            lowestReached = Mathf.Floor(player.position.y);
            for (int x = 0; x < 40; ++x)
            {
                randomizer = Random.Range(0, 100);
                if (randomizer < 60)
                {
                    Instantiate(dirt, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 60 && randomizer < 70)
                {
                    Instantiate(copper, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 70 && randomizer < 80)
                {
                    Instantiate(tin, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 80 && randomizer < 90)
                {
                    Instantiate(iron, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 90 && randomizer < 95)
                {
                    Instantiate(nickel, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else
                {
                    Instantiate(aluminium, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
            }
        }
        else if (lowestReached > player.position.y && lowestReached > -300f)
        {
            lowestReached = Mathf.Floor(player.position.y);
            for (int x = 0; x < 40; ++x)
            {
                randomizer = Random.Range(0, 100);
                if (randomizer < 40)
                {
                    Instantiate(dirt, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 40 && randomizer < 50)
                {
                    Instantiate(copper, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 50 && randomizer < 60)
                {
                    Instantiate(tin, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 60 && randomizer < 70)
                {
                    Instantiate(iron, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 70 && randomizer < 80)
                {
                    Instantiate(nickel, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 80 && randomizer < 90)
                {
                    Instantiate(aluminium, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 90 && randomizer < 95)
                {
                    Instantiate(silver, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else
                {
                    Instantiate(gold, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
            }
        }
        else if (lowestReached > player.position.y)
        {
            lowestReached = Mathf.Floor(player.position.y);
            for (int x = 0; x < 40; ++x)
            {
                randomizer = Random.Range(0, 100);
                if (randomizer < 30)
                {
                    Instantiate(dirt, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 30 && randomizer < 35)
                {
                    Instantiate(copper, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 35 && randomizer < 40)
                {
                    Instantiate(tin, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 40 && randomizer < 50)
                {
                    Instantiate(iron, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 50 && randomizer < 60)
                {
                    Instantiate(nickel, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 60 && randomizer < 70)
                {
                    Instantiate(aluminium, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 70 && randomizer < 80)
                {
                    Instantiate(silver, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 80 && randomizer < 90)
                {
                    Instantiate(gold, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else if (randomizer >= 90 && randomizer < 95)
                {
                    Instantiate(platinum, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else
                {
                    Instantiate(iridium, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
            }
        }
    }
}
