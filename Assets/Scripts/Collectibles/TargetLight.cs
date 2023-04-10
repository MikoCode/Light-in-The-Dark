using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLight : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D myLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LeavingLight"))
        {
            myLight.intensity += 0.07f;
            myLight.pointLightOuterRadius += 0.04f;
            Destroy(collision.gameObject);
        }
    }
}
