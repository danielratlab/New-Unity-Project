using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float timeCount;
    private int z;
    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion target = Quaternion.Euler(0,0,z);
        transform.rotation =  Quaternion.Slerp(transform.rotation, target, timeCount);
        timeCount = timeCount + Time.deltaTime;
        
        z += 1;
        if(z == 361){
            z = 0;
        }
    }
}
