using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
  public GameObject door;
  private static int doorint;

  void Start ()
  {
    door = GameObject.FindWithTag("Test");
    doorint = 2;
  }

  void OnTriggerEnter(Collider other)
  {
    doorint = (doorint - 1);
    if (doorint == 0) {
      Destroy(door);
      }
    Debug.Log (doorint);
  }

  void OnTriggerExit(Collider other)
  {
    doorint = (doorint + 1);
    Debug.Log (doorint);
  }
}
