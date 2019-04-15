using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 latestsave;
    public GameObject player;

    // Starts game with starting position as respawn
    void Start()
    {
        latestsave = player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    void OnTriggerEnter(Collider collider)
    {
      // Saves the latest entered save point as the new respawn point
      if (collider.gameObject.tag == "SavePoint"){
        latestsave = collider.transform.position;
        //Debug.Log (latestsave);
      }
      // If player collides falls of the map, brings them back to last save point
      if (collider.gameObject.tag == "Kill"){
        player.transform.position = latestsave;
      }
    }
}
