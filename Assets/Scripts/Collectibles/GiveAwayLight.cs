using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveAwayLight : MonoBehaviour
{
    public GameObject bulb;
    public GameObject target;
    private int neededLight;
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
        neededLight = GameManager.Instance.lighting;
        StartCoroutine("Wait");
       
    }

    IEnumerator Wait()
    {
        for (int i = 0; i < neededLight; i++)

        {
            yield return new WaitForSeconds(0.2f);
            GameManager.Instance.TakeDamage(1);
            GameObject light = Instantiate(bulb, transform.position, Quaternion.identity);
            light.GetComponent<LeavingLight>().target = target.transform.position;


        }
        
        
    }
}
