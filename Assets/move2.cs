using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2 : MonoBehaviour
{
    public GameObject obj3;
    private Vector3 direction = new Vector3(1,0,0);
    private Vector3 angle = new Vector3(1,1,1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime, Space.World);
        transform.Rotate(angle, Space.World);
    }
    
    void OnCollisionEnter(Collision obj){
        if(obj.gameObject.name == "tree04"){
            Instantiate(obj3, obj.gameObject.transform.position, Quaternion.identity);
            Destroy(obj.gameObject);
        }
    }
}
