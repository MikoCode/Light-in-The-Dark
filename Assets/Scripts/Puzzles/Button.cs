using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool pushed = false, move, moveDown;
    public GameObject whatToOpen;
    public float DoorsHowMuch;
    public float ButtonHowMuch;
    public Vector2 target, targetDown;
    // Start is called before the first frame update
    void Start()
    {
        target = whatToOpen.transform.position;
        targetDown = new Vector2(whatToOpen.transform.position.x, whatToOpen.transform.position.y + DoorsHowMuch);
    }

    // Update is called once per frame
    void Update()
    {
        if(move == true)
        {
            if(whatToOpen.transform.position.y != target.y)
            {
                whatToOpen.transform.position = Vector2.Lerp(whatToOpen.transform.position, target, 15 * Time.deltaTime);
                
            }
            

           
        }

        if(moveDown == true)
        {
            if(whatToOpen.transform.position.y != targetDown.y)
            {
                whatToOpen.transform.position = Vector2.Lerp(whatToOpen.transform.position, targetDown, 13 * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(pushed == false)
        {
            move = false;
            moveDown = true;
            Debug.Log("Button");
            transform.position = new Vector2(transform.position.x, transform.position.y - ButtonHowMuch);
            pushed = true;
          
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(pushed == true)
        {
            move = true;
            moveDown = false;
            transform.position = new Vector2(transform.position.x, transform.position.y + ButtonHowMuch);
            pushed = false;
            
        }
    }
}
