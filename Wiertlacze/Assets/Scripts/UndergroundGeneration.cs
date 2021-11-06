using UnityEngine;

public class UndergroundGeneration : MonoBehaviour
{
    public Transform player;
    public GameObject dirt;
    public GameObject copper;
    public GameObject iron;
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
                randomizer = Random.Range(0, 10);
                if(randomizer < 7)
                {
                    Instantiate(dirt, new Vector3(-19.5f + x, y, -2), Quaternion.identity, breakableGround);
                } 
                else if(randomizer >= 7 && randomizer < 9)
                {
                    Instantiate(copper, new Vector3(-19.5f + x, y, -2), Quaternion.identity, breakableGround);
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
        if ( lowestReached > player.position.y )
        {
            lowestReached = Mathf.Floor(player.position.y);
            for(int x=0; x<40; ++x) 
            {
                randomizer = Random.Range(0, 10);
                if(randomizer < 7)
                {
                    Instantiate(dirt, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                } 
                else if(randomizer >= 7 && randomizer < 9)
                {
                    Instantiate(copper, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
                else
                {
                    Instantiate(iron, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
                }
            }
        }
    }
}
