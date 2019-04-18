using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueController : MonoBehaviour
{

    public GameObject glue;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ActivePlayer")
        { 
       
            Destroy(glue);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
     

    }
}
