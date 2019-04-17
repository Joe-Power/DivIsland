using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
  public GameObject door;
  public int doorint;
  // Can add more ints for multiple sets of pressure pads
  private bool broken;

  //Integrating the Break script
  public float cubeSize = 0.05f;
  public int cubesInRow = 5;

  float cubesPivotDistance;
  Vector3 cubesPivot;

  public float minExplosionForce = 1f;
  public float maxExplosionForce = 20f;
  public float explosionRadius = 4f;
  public float explosionUpward = 0.4f;
  public float removeDelay = 3f;

  // Initialize values, set doorint to however many pressure pads there are
  void Start ()
  {
    door = GameObject.FindWithTag("Test");
    doorint = 2;
    broken = false;

    // From the Break script
    // gameObject.AddComponent<Rigidbody>();
    cubesPivotDistance = cubeSize * cubesInRow / 2;
    cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
  }

  // On something coming into contact with the pressure pads reduces count by 1
  // Breaks the door when target goal is reached
  void OnTriggerEnter(Collider other)
  {
    doorint = (doorint - 1);
    if (doorint == 0 && broken == false ) {
      Invoke("explode", 1);
      broken = true;
      }
    //Debug.Log (doorint);
  }

  // Raises count if there's nothing on the plate anymore
  void OnTriggerExit(Collider other)
  {
    doorint = (doorint + 1);
  }

  // From the Break script
  public void explode(){
      door.SetActive(false);
      for (int x = 0; x < cubesInRow; x++) {
          for (int y = 0; y < cubesInRow; y++) {
              for (int z = 0; z < cubesInRow; z++) {
                  createPiece(x, y, z);
              }
          }
      }
      Vector3 explosionPos = door.transform.position;
      Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
      foreach (Collider hit in colliders) {
          Rigidbody rigbod = hit.GetComponent<Rigidbody>();
          if(rigbod != null) {
              rigbod.AddExplosionForce(Random.Range(minExplosionForce, maxExplosionForce), door.transform.position, explosionRadius, explosionUpward);
          }
      }
  }

  void createPiece(int x, int y, int z){
      GameObject piece;
      piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
      piece.transform.position = door.transform.position + new Vector3(cubeSize * x, (cubeSize * y + 6), cubeSize * z) - cubesPivot;
      piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
      piece.AddComponent<Rigidbody>();
      piece.GetComponent<Rigidbody>().mass = cubeSize;
      Destroy(piece, removeDelay);
  }
}
