using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepthControler : MonoBehaviour
{
    GameObject player;
    Text depthDisplay;
    // Start is called before the first frame update
    void Start()
    {
        depthDisplay = GetComponent<Text>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        depthDisplay.text = "Depth: " + (int)(player.transform.position.y - 1) + "m";
    }
}
