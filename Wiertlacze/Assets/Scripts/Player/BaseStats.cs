using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    
    public float fuel = 100.0f;
    public float health = 100.0f;
    [SerializeField] float fuelConsuption = 0.0f;
    private float movingConsuption = 1f;
    private float flyingConsuption = 1.5f;
    //private float drillingConsuption = 2f;
    private float armor = 0f;
    
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update(){    
        CheckFuelConspution();
        //CheckDamage();    
    }

    private void CheckFuelConspution(){
        
        if (_rigidbody.velocity.y > 1) {
            fuelConsuption = flyingConsuption;
        }
        else if ((_rigidbody.velocity.x > 1 || _rigidbody.velocity.x < -1) && _rigidbody.velocity.y > -1) {
            fuelConsuption = movingConsuption;
        }
        else {
            fuelConsuption = 0f;
        }
        fuel -= fuelConsuption * Time.deltaTime; 
        
    }

    private void OnCollisionEnter(Collision collision){
        if (_rigidbody.velocity.y < -7){
            health += _rigidbody.velocity.y + armor;
        }
    }
    
    
}
