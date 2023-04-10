using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavingLight : MonoBehaviour
{
    public Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, target, 15 * Time.deltaTime);
    }
}
