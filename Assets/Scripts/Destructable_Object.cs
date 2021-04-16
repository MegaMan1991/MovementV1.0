using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable_Object : MonoBehaviour



{
    //health
    private bool dead = false;
    [SerializeField]
    int health = 100;

    //hurts the object
    public void Damage(int dmg)
    {
        health -= dmg; 
        if (health <= 0 && !GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
            dead = true;
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dead && !GetComponent<AudioSource>().isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
