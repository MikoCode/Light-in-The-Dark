using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingObject : MonoBehaviour
{
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
        
    }
}
