using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        transform.position = new Vector3(playerPos.x - 1, 26, playerPos.z - 9);
    }
}
