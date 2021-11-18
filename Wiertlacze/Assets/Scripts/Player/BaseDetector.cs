using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseDetector : MonoBehaviour
{

    GameObject tirggerText;

    void Start(){
        tirggerText = GameObject.FindWithTag("Text");
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "FuelBase" || collision.gameObject.tag == "ArmorBase" || collision.gameObject.tag == "ForgeBase" || collision.gameObject.tag == "UpgradesBase")
        {
            tirggerText.SetActive(true);
            tirggerText.GetComponent<Text>().text = "Click 'E' to enter the " + collision.gameObject.tag;
        }
        else
        {
            tirggerText.SetActive(false);
        }
        
    }   
    void OnCollisionStay(Collision collision){
        if (Input.GetKey(KeyCode.E)){
            Debug.Log("I am in " + collision.gameObject.tag);               
        }
    }  
    
}
