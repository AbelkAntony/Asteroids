using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Bullet bulletPrefab;
    private Rigidbody2D _rigidbody;
    private bool _thrusting;
    private float _turnDirection;
    public float thrustSpeed = 1f;
    public float turnSpeed = 1f;

    private void Awake()
    {
        this._rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        this._thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        //player movemet
        if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
        {
            this._turnDirection = 1.0f;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this._turnDirection = -1.0f;
        }
        else
        {
            this._turnDirection = 0f;
        }

        //function call for bullet fire
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        
    }

    private void FixedUpdate()
    {
        if(_thrusting)
        {
            this._rigidbody.AddForce(this.transform.up * this.thrustSpeed);
        }

        if(this._turnDirection != 0)
        {
            this._rigidbody.AddTorque(this._turnDirection * this.turnSpeed);
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = 0f;

            this.gameObject.SetActive(false);

            gameManager.PlayerDied();
        }
    }
}
