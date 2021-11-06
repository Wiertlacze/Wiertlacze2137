using UnityEngine;

public class UndergroundGeneration : MonoBehaviour
{
    public Transform player;
    public GameObject dirt;
    public Transform breakableGround;
    public float offset = 4f;
    public float lowestReached = 1f;

    void Start()
    {
        for(int y=-1; y>-4; --y)
        {
            for (int x = 0; x < 40; ++x)
            {
                Instantiate(dirt, new Vector3(-19.5f + x, y, -2), Quaternion.identity, breakableGround);
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
                Instantiate(dirt, new Vector3(-19.5f + x, lowestReached - offset, -2), Quaternion.identity, breakableGround);
            }
        }
    }
}
