using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}