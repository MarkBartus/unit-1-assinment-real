using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 1.5f;
    private Rigidbody rb;   
    private Animator anim;
    private bool inRange;
    private bool attackMode;
    private float distance;
    bool Attack;
    bool movement;
    public float enemyHealth = 100f;

    public float AggroRange = 6f;
    public float InRange = 15f;
    // Start is called before the first frame update

    void Start()

    {
        anim = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        
    }


    // Update is called once per frame
    void Update()
    {
        Attack = range(Attack);
        movement = inter(movement);

    }

    bool inter (bool movement)
    {
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        if (distance < InRange)
        {
            movement = true;
            anim.SetBool("walk", true);
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            anim.SetBool("walk", true);
        }
        return movement;
       
    }
   
 
    bool range(bool Attack)
    {
        float seperation = Vector3.Distance(this.transform.position, player.transform.position);
        print(seperation);
        if (seperation <= AggroRange)
        {
            Attack = true;
            anim.SetBool("walk", false);
            anim.SetBool("Attack", true);
        }
        else
        {
            Attack = false;
            anim.SetBool("walk", true);
            anim.SetBool("Attack", false);
        }
        return Attack;
    }
    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
    
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "bullet")
        {
            enemyHealth.TakeDamage(20)
            if (enemyHealth < 1)
            {
                Destroy(this.gameObject);
            }
        }
        
    }


}

