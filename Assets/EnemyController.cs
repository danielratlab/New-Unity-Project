using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public GameObject explosion;
    public float speed;
    private float health;
    private Text healthText;
    private float maxHealth;
    private Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2.5f;
        maxHealth = 100.0f;
        health = 100.0f;
        healthText = transform.Find("Canvas").Find("Text").GetComponent<Text>();
        healthBar = transform.Find("Canvas").Find("Image2").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.position += transform.forward * speed * Time.deltaTime;
        healthText.text = health.ToString();
        healthBar.fillAmount = health / maxHealth;
    }
    
    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "Bullet"){
            Destroy(col.gameObject);
            health -= 10.0f;
            if(health <= 0){
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this);
            Destroy(gameObject);
        }
        }
    }
}
