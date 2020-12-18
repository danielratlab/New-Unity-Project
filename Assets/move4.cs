using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move4 : MonoBehaviour
{
    public float speed;
    public Transform feet;
    public LayerMask ground;
    public float jumpHeight;
    private int doubleJump;
    private Vector3 direction;
    private Rigidbody rbody;
    private float rotationSpeed;
    private float rotationX;
    private float rotationY;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private AudioSource audio;
    private AudioSource audio2;

    
    // Start is called before the first frame update
    void Start()
    {
        speed = 4.0f;
        rotationSpeed = 2f;
        rotationX = 0;
        rotationY = 10f;
        jumpHeight = 5.0f;
        doubleJump = 0;
        rbody = GetComponent<Rigidbody>();
        audio = GetComponents<AudioSource>()[0];
        audio2 = GetComponents<AudioSource>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        doubleJump = 0;
        direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction = direction.normalized;
        if(direction.x != 0){
            rbody.MovePosition(rbody.position + transform.right * direction.x * speed * Time.deltaTime);
        }
        if(direction.z != 0){
            rbody.MovePosition(rbody.position + transform.forward * direction.z * speed * Time.deltaTime);
        }
        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed;
        rotationY += Input.GetAxis("Mouse Y") * rotationSpeed;
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        /**
        bool isGrounded() {
            if(Physics.CheckSphere(feet.position, 0.1f, ground)){
                doubleJump = 0;
                return true;
            } else {
                return false;
            }
        }
         **/
        if(Input.GetButtonDown("Jump") &&  doubleJump < 2){
            audio.Play();
            doubleJump += 1;
            rbody.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
        }
        
        if(Input.GetButtonDown("Fire1")){
            audio2.Play();
            Fire();
        }
    }
    void Fire() {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 9;
        Destroy(bullet, 2.0f);
    }
}
