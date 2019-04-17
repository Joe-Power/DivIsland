using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    // Checks if the falling object is the player
    // If it is not, destroy object to reduce unnecessary lag
    void OnTriggerEnter(Collider collider)
    {
      if (collider.gameObject != player){
        Destroy(collider.gameObject);
        //Debug.Log ("Destroyed");
      }
    }
}
