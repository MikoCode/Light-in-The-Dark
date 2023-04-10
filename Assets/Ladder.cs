using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private float vertical;
    private bool onLadder;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onLadder)
        {
            vertical = Input.GetAxis("Vertical");
        }
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onLadder = true;
           PlayerController player =  collision.gameObject.GetComponent<PlayerController>();
            player.rb.gravityScale = 0;
            player.rb.velocity = new Vector2(player.rb.velocity.x, vertical * speed);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onLadder = false;
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            
            player.rb.gravityScale = 1;

        }
    }
}
