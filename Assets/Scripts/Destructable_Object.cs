using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable_Object : MonoBehaviour



{
    //health
    [SerializeField]
    int health = 100;

    //hurts the object
    public void Damage(int dmg)
    {
        health -= dmg; 
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
