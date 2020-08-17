using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float waitTime = 0.001f;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Quaternion.Euler playerPos = transform.rotation;
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.y = rotationVector.y + 0.31f;
            transform.rotation = Quaternion.Euler(rotationVector);
            timer = 0.0f;
        }
    }
}
