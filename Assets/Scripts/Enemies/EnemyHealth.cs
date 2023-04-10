using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startHealth;
   [SerializeField] private int curHealth;
    public GameObject body;
    public bool isOnlyOne;
    public EnemyObject enemyObject;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
           
            if (curHealth - GameManager.Instance.playerDamage <= 0)
            {
                if (isOnlyOne)
                {
                    Destroy(enemyObject.gameObject);
                }
                else
                {
                    enemyObject.healthPieces--;
                    if (enemyObject.healthPieces == 0)
                    {
                        Destroy(enemyObject.gameObject);
                    }
                    Destroy(body);
                }

            }
            else
            {
                curHealth -= GameManager.Instance.playerDamage;
            }
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.CompareTag("Player"))
        {

            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if (player.rb.velocity.x > 4.5f || player.rb.velocity.x < -4.5f)
            {
                

                if (curHealth - GameManager.Instance.playerDamage <= 0)
                {
                    if (isOnlyOne)
                    {
                        Destroy(enemyObject.gameObject);
                    }
                    else
                    {
                        enemyObject.healthPieces--;
                        if (enemyObject.healthPieces <= 0)
                        {
                            Destroy(enemyObject.gameObject);
                        }
                        Destroy(gameObject);
                    }

                }
                else
                {
                    curHealth -= GameManager.Instance.playerDamage;
                }
            }

        }

    }


    
}
