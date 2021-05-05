using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impact_effect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyImpactEffect());
    }

    IEnumerator destroyImpactEffect()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
