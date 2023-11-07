using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;

    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;
    [SerializeField] float MoveSpeed = 3f;
    Rigidbody rb;
    Transform Target;
    Vector2 moveDirection;
    private void Awake()
    {
        intTimer = timer;
        anim = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 direction = (Target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            moveDirection = direction;
        }

        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, raycastMask);
            RaycastDebugger();
        } 
        
        if(hit.collider != null)
        {
            EnemyLogic();
        }

        else if(hit.collider == null)
        {
            inRange = false;
        }

        if(inRange == false)
        {
            anim.SetBool("walk", false);
            StopAttack();
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if(distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            anim.SetBool("Attack", false);
        }
    }
    private void Start()
    {
        Target = GameObject.Find("Player").transform;
    }

    void Move()
    {
        anim.SetBool("walk", true);
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("enemy attack anim"))
        {
            if (Target)
            {
                rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * MoveSpeed;
            }
        }
    }
    void Attack()
    {
        timer = intTimer;
        attackMode = true;

        anim.SetBool("walk", false);
        anim.SetBool("Attack", true);
    }
    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false)
;   }
    void RaycastDebugger()
    {
        if(distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }
}
