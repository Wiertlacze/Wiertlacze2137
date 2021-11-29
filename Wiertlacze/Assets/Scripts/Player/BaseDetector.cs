using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BaseDetector : MonoBehaviour
{

    public bool isInRange;
    private KeyCode interactKey = KeyCode.E;
    public UnityEvent interactAction;
    GameObject triggerText;

    void Start(){
        triggerText = GameObject.FindWithTag("Text");
    }

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
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
