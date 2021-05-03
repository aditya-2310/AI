using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public Transform player;
    public GameObject health_status;

    private bool isfacingright;
    private float health = 100;
    private Text health_on_screen;
    

    // Start is called before the first frame update
    void Start()
    {
        isfacingright = false;

        health_on_screen =  health_status.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > player.position.x && isfacingright || transform.position.x < player.position.x && !isfacingright)
        {
            isfacingright = !isfacingright;
            Flip();
        }

        health_on_screen.text = health.ToString();
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
