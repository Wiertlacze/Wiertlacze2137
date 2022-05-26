using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BaseDetector : MonoBehaviour
{

    public bool isInRange;
    private string interactKey = "e";
    public UnityEvent interactAction;
    public StatsManagement statsManagement;
    GameObject triggerText;

    void Start(){
        triggerText = GameObject.FindWithTag("Text");
        statsManagement = GameObject.FindWithTag("Player").GetComponent<StatsManagement>();
    }

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetButtonDown(interactKey) || Input.GetButtonDown("Cancel"))
            {              
                interactAction.Invoke();
                
                triggerText.SetActive(false);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            triggerText.SetActive(true);
            triggerText.GetComponent<Text>().text = "Click 'E' to enter the " + this.tag;
            isInRange = true;
        }       

    }
    void OnCollisionExit(Collision collision)
    {
        isInRange = false;
        triggerText.SetActive(false);
    }



}
