using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{
  public GameObject thisKey;
  public float speed = 10f;
  private int collectedkeys;

  void Start ()
  {
    collectedkeys = 0;
  }

   void Update ()
   {
     transform.Rotate(Vector3.up, speed * Time.deltaTime);
   }

  void OnTriggerEnter(Collider other)
  {
    Destroy(thisKey);
    Debug.Log (collectedkeys);
    collectedkeys = (collectedkeys + 1);
    if (collectedkeys == 3) {
      //unlock whatever
      }
  }
}
