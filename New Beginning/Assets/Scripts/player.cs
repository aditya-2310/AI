using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private float horizontalinput;
    private Rigidbody2D rigidbodycomponent;
    private bool spacekeywaspressed;
    public Transform groundchecktransform;
    private bool isgrounded;
    public LayerMask playermask;
    private bool isfacingright;
    public Animator animator;

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
        rigidbodycomponent.velocity = new Vector2(horizontalinput * 36f, rigidbodycomponent.velocity.y);

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
}
