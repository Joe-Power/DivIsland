using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeightDetection : MonoBehaviour
{
   float mass;
   public Rigidbody rb;
   public GameObject bridge;
   private bool triggered;

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

    void Start()
    {
      triggered = false;
      // From the Break script
      //gameObject.AddComponent<Rigidbody>();
      cubesPivotDistance = cubeSize * cubesInRow / 2;
      cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

    void OnTriggerStay(Collider other)
    {
      // Get the mass value from the colliding object
      rb = other.GetComponent<Rigidbody>();
      mass = rb.mass;

      //Debug.Log (rb.mass);
      // Change the number here to change the mass the bridge breaks on
      if (rb.mass < 1 && triggered == false) {
        triggered = true;
        // Run the break script and reset the bridge after an interval
        Invoke("explode", 0.1f);
        Invoke("reset", 3);
        }
    }

    // Rebuilds the bridge
    void reset(){
      bridge.SetActive(true);
      triggered = false;
    }

    // From the Break script
    public void explode(){
        bridge.SetActive(false);
        for (int x = 0; x < cubesInRow; x++) {
            for (int y = 0; y < cubesInRow; y++) {
                for (int z = 0; z < cubesInRow; z++) {
                    createPiece(x, y, z);
                }
            }
        }
        Vector3 explosionPos = bridge.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders) {
            Rigidbody rigbod = hit.GetComponent<Rigidbody>();
            if(rigbod != null) {
                rigbod.AddExplosionForce(Random.Range(minExplosionForce, maxExplosionForce), bridge.transform.position, explosionRadius, explosionUpward);
            }
        }
    }

    void createPiece(int x, int y, int z){
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.transform.position = bridge.transform.position + new Vector3(cubeSize * x, (cubeSize * y), cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
        Destroy(piece, removeDelay);
    }
  }
