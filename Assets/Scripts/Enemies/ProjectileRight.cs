using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRight : MonoBehaviour
{
    public float speed;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("targetRight");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
}
