using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : MonoBehaviour
{
    [SerializeField] float _movespeed = 12f;
    [SerializeField] float _turnspeed = 3f;
    [SerializeField] GameObject _UIcomponent;
    [SerializeField] GameObject _UIcomponent2;
    [SerializeField] Bullets _bullet;
    [SerializeField] float _bulletdelay = 0.1f;
    [SerializeField] int _bulletspeed = 25;

    public bool BulletPowerUp = false;

    [Header("Feedback")]
    [SerializeField] TrailRenderer _trail = null;

    Rigidbody _rb = null;
    float lastshoottime; 

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _UIcomponent.SetActive(false);
        _UIcomponent2.SetActive(false);

        _trail.enabled = false;
    }

    private void FixedUpdate()
    {
        MoveShip();
        TurnShip();
        Shoot(); 
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= lastshoottime + _bulletdelay)
            {
                lastshoottime = Time.time;
                if (BulletPowerUp == false)
                {


                    Bullets bullet = Instantiate(_bullet);
                    bullet.Shoot(_bulletspeed, transform.forward, _rb.velocity);
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                }
                if (BulletPowerUp == true)
                {
                    Bullets bullet = Instantiate(_bullet);
                    bullet.Shoot(_bulletspeed, transform.forward, _rb.velocity);
                    bullet.transform.position = transform.position - transform.right;
                    bullet.transform.rotation = transform.rotation;


                    Bullets bullet2 = Instantiate(_bullet);
                    bullet2.Shoot(_bulletspeed, transform.forward, _rb.velocity);
                    bullet2.transform.position = transform.position + transform.right;
                    bullet2.transform.rotation = transform.rotation;
                }
            }
        }
               
    }


    // uses forces to build momentum forward/backward
    void MoveShip()
    {
        // S/Down = -1/Up = 1, None = 0. Scale by moveSpeed
        float movesAmountThisFrame = Input.GetAxisRaw("Vertical") * _movespeed;
        // combine our direction with our calculated amount 
        Vector3 moveDirection = transform.forward * movesAmountThisFrame;
        //apply the movement to the physics object 
        _rb.AddForce(moveDirection);
    }

    // don't use forces for this. We want rotations to be precise

    void TurnShip()
    {

        // A/Left = -1 D/Right = 1, None = 0. Scale by turnSpeed
        float turnAmountThisFrame = Input.GetAxisRaw("Horizontal") * _turnspeed;
        // specify an axis to apply our turn amount (x, y, z) as a rotation
        Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);
        // spin the rigidbody 
        _rb.MoveRotation(_rb.rotation * turnOffset);



    }
    public void Kill()
    {

        Debug.Log("Player has been killed!");
        this.gameObject.SetActive(false);
        _UIcomponent.SetActive(true);

    }

    public void Win()
    {
        Debug.Log("You Win!");
        this.gameObject.SetActive(false);
        _UIcomponent2.SetActive(true);
    }

    public void SetSpeed(float speedChange)
    {
        _movespeed += speedChange;
        //TODO audio/visuals
    }

    public void SetBoosters(bool activeState)
    {
        _trail.enabled = activeState;

    }

    public void SetSize(float sizeChange)
    {
        transform.localScale *= sizeChange;
    }

    
    
        

        
    
}
