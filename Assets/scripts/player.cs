using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject weapon;

    
    Rigidbody2D rb;
    Animator anim;	// ***
    SpriteRenderer spi;
    HealthManager health;
    // Start is called before the first frame update
    
    void Start()
    {
        print("start");

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // ***
        spi = GetComponent<SpriteRenderer>();
        
        health = GameObject.FindWithTag("Health").GetComponent<HealthManager>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Swalk", false);
        anim.SetBool("walk foward", false);
        float speed = 6f;

        if (Input.GetKey("d") == true)
        {
            print("player pressed d");
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            anim.SetBool("Swalk", true);
            spi.flipX = false;
        }
        if (Input.GetKey("a") == true)
        {
            print("player pressed a");
            transform.position = new Vector2(transform.position.x + (-speed * Time.deltaTime), transform.position.y);
            anim.SetBool("Swalk", true);
            spi.flipX = true;
        }
        if (Input.GetKey("w") == true)
        {
            print("player pressed w");
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
            transform.position += movement * Time.deltaTime * speed;
            anim.SetBool("walk foward", true);

        }
        if (Input.GetKey("s") == true)
        {
            print("player pressed s");
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
            transform.position += movement * Time.deltaTime * speed;
        }



    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            health.TakeDamage(20);
        }
    }
}



