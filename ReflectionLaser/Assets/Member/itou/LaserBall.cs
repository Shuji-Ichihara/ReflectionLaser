using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBall : MonoBehaviour
{
    public float Speed = 3f;

    Rigidbody2D _rb;
    private Vector2 LastVelocity;

    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        _rb.AddForce(transform.up * Speed, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        this.LastVelocity = this._rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Mira"))
        {
            Vector2 refrectVec = Vector2.Reflect(this.LastVelocity, other.contacts[0].normal);
            this._rb.velocity = refrectVec;
        }
    }
}
