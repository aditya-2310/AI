using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_flip : MonoBehaviour
{
    public Transform player;
    private bool isfacingright;

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
}
