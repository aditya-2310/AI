using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Transform groundchecktransform;
    public LayerMask playermask;
    public Animator animator;
    public float health = 100;
    public Text playerHealth;

    private float horizontalinput;
    private Rigidbody2D rigidbodycomponent;
    private bool spacekeywaspressed;
    private bool isgrounded;   
    private bool isfacingright;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodycomponent = GetComponent<Rigidbody2D>();
        isfacingright = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalinput = Input.GetAxis("Horizontal");
        Flip(horizontalinput);
        animator.SetFloat("speed", Mathf.Abs(horizontalinput));

        if (Physics2D.OverlapCircle(groundchecktransform.position, 1f, playermask) == null)
        {
            isgrounded = false;
            animator.SetBool("isjumping", true);
        }
        else if (Physics2D.OverlapCircle(groundchecktransform.position, 1f, playermask) != null)
        {
            isgrounded = true;
            animator.SetBool("isjumping", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            spacekeywaspressed = true;
        }
    }

    private void FixedUpdate()
    {
        rigidbodycomponent.velocity = new Vector2(horizontalinput * 39f, rigidbodycomponent.velocity.y);

        if (spacekeywaspressed)
        {
            rigidbodycomponent.AddForce(Vector2.up*75f, ForceMode2D.Impulse);
            spacekeywaspressed = false;
        }
    }

    void Flip(float horizontalinput)
    {
        if (horizontalinput > 0 && isfacingright == false || horizontalinput < 0 && isfacingright == true)
        {
            isfacingright = !isfacingright;
            transform.Rotate(0, 180f, 0);
        }
    }

    public void takeDamage(float damage)
    {
        health = health - damage;
        playerHealth.text = health.ToString();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(3);
    }
}
