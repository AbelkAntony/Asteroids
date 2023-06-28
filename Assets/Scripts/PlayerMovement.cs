using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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
}
