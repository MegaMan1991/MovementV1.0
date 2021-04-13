using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    
    //bullet code
    [SerializeField]
    int dmg = 25;
    void OnTriggerEnter(Collider collider)
    {
        Destructable_Object obj = collider.transform.GetComponent<Destructable_Object>();
        if (obj != null)
        {
            obj.Damage(dmg);
            Destroy(gameObject);
        }
}
    public void Shoot(int speed, Vector3 dir, Vector3 playershipVelocity )
        
    {
        _rb.velocity = dir * speed + playershipVelocity; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

  
}
