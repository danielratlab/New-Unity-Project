using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1 : MonoBehaviour
{
    public float speed;
    public float gravity;
    public float jumpHeight;
    private Vector3 direction;
    private Vector3 walkingVelocity;
    private Vector3 fallingVelocity;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;
        gravity = 9.8f;
        jumpHeight = 3.0f;
        direction = Vector3.zero;
        walkingVelocity = Vector3.zero;
        fallingVelocity = Vector3.zero;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction = direction.normalized;
        if(direction != Vector3.zero){
            transform.forward = direction;
        }
        walkingVelocity = direction * speed;
        controller.Move(walkingVelocity * Time.deltaTime);
        fallingVelocity.y -= gravity * Time.deltaTime;
        
        if(Input.GetButtonDown("Jump")){
            fallingVelocity.y = Mathf.Sqrt(gravity * jumpHeight);
        }
        
        controller.Move(fallingVelocity * Time.deltaTime);
    }
}
