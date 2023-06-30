using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;

    public float size = 1f; 
    public float speed = 5f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float maxLifeTime = 30f;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        this.transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);
        this.transform.localScale = Vector3.one * this.size;
        _rigidbody.mass = this.size ;
    }

    public float GetMinSize() { return minSize; }
    public float GetMaxSize() { return maxSize; }

    public void SetTrajectory(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speed);
        
        Destroy(this.gameObject, this.maxLifeTime);
    }
}
