using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_attack : MonoBehaviour
{
    public float damage = 20;

    public LayerMask attackmask;
    public Transform attackpoint;
    public float attackrange;

    public void attack()
    {
        Collider2D collinfo = Physics2D.OverlapCircle(attackpoint.position, attackrange, attackmask);

        if (collinfo != null)
        {
            collinfo.GetComponent<player>().takeDamage(damage);
        }
    }
}
