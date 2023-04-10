using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float movement;
    public float speed;
   [SerializeField] private float startSpeed, startTime, timeBtw;
    private bool moving;
    public GameObject[] projectile;
    public Transform ALaunchOffset, DLaunchOffset;
    
    public Rigidbody2D rb;
    public CircleCollider2D bc;
    private bool canJump, onSlope;
    [SerializeField] private LayerMask platformsLM;
    public int jumpPower;
    // Start is called before the first frame update
    void Start()
    {
        startTime = 0.3f;
        timeBtw = startTime;
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        if(GameManager.Instance.shootingDisabled == false)
        {
            Shooting();
        }
        
        

    }

    private void Moving()
    {
        movement = Input.GetAxisRaw("Horizontal");
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {

            rb.velocity += Vector2.up * jumpPower;
            canJump = false;
        }
    }
    
    private void Shooting()
    {
        if(GameManager.Instance.lighting > 0)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Instantiate(projectile[0], transform.position, Quaternion.identity);
                    GameManager.Instance.TakeDamage(1);
                }



            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Instantiate(projectile[1],transform.position, Quaternion.identity);
                    GameManager.Instance.TakeDamage(1);
                }
            }
        }
       



    }

    private void FixedUpdate()
    {

        Vector2 moving = new Vector2(speed * movement, rb.velocity.y);
        if(rb.velocity.x < 9 && rb.velocity.x > -9 && onSlope == false)
        {
            rb.AddForce(moving);
        }
        if (onSlope)
        {
           if(rb.velocity.y <= 0) 
            
            {
                if (rb.velocity.x > 0)
                {
                    rb.AddForce(new Vector2(speed * 1.5f, rb.velocity.y));
                }
                else if (rb.velocity.x < 0)
                {
                    rb.AddForce(new Vector2(-speed * 1.5f, rb.velocity.y));
                }
            }
                
            
            
            
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") )
        {
            canJump = true;
        }

        if (collision.gameObject.CompareTag("Slope"))
        {
            onSlope = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slope"))
        {
            onSlope = false;
        }
    }
      

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    




}

