using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float bulletSpeed = 500f;
    public float maxLifeTime =10f;

    private void Awake()
    {
        this._rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
        this._rigidbody.AddForce(direction * this.bulletSpeed);
        Destroy(this.gameObject, this.maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
