using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform player;

    private bool isfacingright;
    private float health = 100;

    // Start is called before the first frame update
    void Start()
    {
        isfacingright = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > player.position.x && isfacingright || transform.position.x < player.position.x && !isfacingright)
        {
            isfacingright = !isfacingright;
            Flip();
        }
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);       
    }
}
