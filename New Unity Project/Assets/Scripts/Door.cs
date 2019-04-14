using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
 public static int doorint;
 public GameObject door;

  void Start ()
  {
   doorint = 2;
  }

  void FixedUpdate()
  {
  if (doorint == 0) {
    Destroy(door);
    Debug.Log ("destroyme");
    }
  }

}
