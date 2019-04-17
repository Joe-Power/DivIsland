using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{
  public GameObject thisKey;
  public GameObject obstacle;
  public float speed = 10f;
  private int collectedkeys;

  // initializes number of keys collected to 0
  void Start ()
  {
    collectedkeys = 0;
  }

  // Key spins in place
   void Update ()
   {
     transform.Rotate(Vector3.up, speed * Time.deltaTime);
   }

  // On collision, destroys the key and adds it to the total key count
  void OnTriggerEnter(Collider other)
  {
    Destroy(thisKey);
    collectedkeys = (collectedkeys + 1);
    Debug.Log(collectedkeys);
    if (collectedkeys == 3) {
      Destroy(obstacle);
      }
  }
}
