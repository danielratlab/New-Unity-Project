using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inst : MonoBehaviour
{
    public GameObject obj;
    private int d;
    // Start is called before the first frame update
    void Start()
    {
        d = 86;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(obj, new Vector3(d, 3, 150), Quaternion.identity);
            d += 2;
        }
    }
}
