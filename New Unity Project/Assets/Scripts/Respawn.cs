using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 latestsave;
    public GameObject player;
    //public GameObject save;
  //  public GameObject kill;

    // Start is called before the first frame update
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
      if (collider.gameObject.tag == "SavePoint"){
        latestsave = collider.transform.position;
        Debug.Log (latestsave);
      }
      if (collider.gameObject.tag == "Kill"){
        player.transform.position = latestsave;
      }
    }
}
