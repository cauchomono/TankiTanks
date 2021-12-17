using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 offset ;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        offset = -player.transform.position + transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        offset = -player.transform.position + transform.position;
        transform.position = player.transform.position + offset;
        

      
    }
}
