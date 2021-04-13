using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Volume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // detect if it's the player
        PlayerShip playerShip
            = other.gameObject.GetComponent<PlayerShip>();
        // if we found something valid, continue 
        if (playerShip != null)
        {
            // do something! 
            playerShip.Win();
            // win sound effect
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

}