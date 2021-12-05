using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatsManagement : MonoBehaviour, ISaveable<PlayerStatsData>
{
    // public for debugging purposes only 
    //--
    public float maxFuel = 100.0f;
    public float fuel;
    public float health = 100.0f;
    public float money = 40.0f;
    // -- 
    [SerializeField] float fuelConsuption = 0.0f;
    private float movingConsuption = 4f;
    private float flyingConsuption = 5.5f;
    private float drillingConsuption = 7f;
    private float armor = 0f;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        fuel = maxFuel;
    }

    public PlayerStatsData OnSave()
    {
        var data = new PlayerStatsData
        {
            MaxFuel = maxFuel,
            Fuel = fuel,
            Health = health,
            Money = money,
            Armor = armor
        };

        return data;
    }

    public void OnLoad(PlayerStatsData data)
    {
        maxFuel = data.MaxFuel;
        fuel = data.Fuel;
        health = data.Health;
        money = data.Money;
        armor = data.Armor;
    }

    void Update(){    
        CheckFuelConspution();
        CheckTankAndHealth();
        //CheckDamage();    
    }

    private void CheckFuelConspution(){
        
        if (_rigidbody.velocity.y > 1) {
            fuelConsuption = flyingConsuption;
        }
        else if ((_rigidbody.velocity.x > 1 || _rigidbody.velocity.x < -1) && _rigidbody.velocity.y > -1) {
            fuelConsuption = movingConsuption;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            fuelConsuption = drillingConsuption;
        }
        else {
            fuelConsuption = 0f;
        }
        fuel -= fuelConsuption * Time.deltaTime; 
        
    }

    private void CheckTankAndHealth()
    {
        if (fuel < 0)
        {
            SceneManager.LoadScene(0);
        }
        if(health < 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionEnter(Collision collision){
        if (_rigidbody.velocity.y < -7){
            health += _rigidbody.velocity.y + armor;
        }
    }
    
    
}
