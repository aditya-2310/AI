using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject impactEffect;

    private float speed = 50f;
    private float damage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        enemy Enemy = collision.GetComponent<enemy>();
        if (Enemy != null)
        {
            Enemy.takeDamage(damage);
        }
        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
