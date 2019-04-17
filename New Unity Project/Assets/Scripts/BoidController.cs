using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidController : MonoBehaviour
{
    public Rigidbody rigidBody;
    public Transform boidTransform;

    private GameObject[] boidObjects;
    private List<Rigidbody> rigidbodies = new List<Rigidbody>();

    private GameObject inGameBoid;
    List<GameObject> boidList = new List<GameObject>();

    public GameObject watcher;
    public Rigidbody watcherRb;
    public float maxSpeed;
    public float speed;

    private float charScaleX;
    private float charScaleY;
    private float charScaleZ;

    private float charPosX;
    private float charPosY;
    private float charPosZ;

    public float sizeDifference;

    private bool isDivided;


    public Vector3 averageBoidPos;
    public Vector3 totaledBoidPos;
    public Vector3 boidPos;
    public Vector3 watcherPos;
    public Vector3 difference;
    public Vector3 boidAveraging;
    public Vector3 keepDistance;

    public float distance;



    void Start()
    {

        isDivided = false;
        BoidWatcher boidWatcher = watcher.GetComponent<BoidWatcher>();
        watcherRb = watcher.GetComponent<Rigidbody>();

        boidObjects = GameObject.FindGameObjectsWithTag("Boid");
        foreach (GameObject boid in boidObjects)
        {
            rigidbodies.Add(boid.GetComponent<Rigidbody>());
            boid.SetActive(false);
        }

        Debug.Log(boidObjects.Length);
    }

    Vector3 CalculateAlignment(Rigidbody currentBoid)
    {
        Vector3 alignment = Vector3.zero;
        foreach (Rigidbody rb in rigidbodies)
        {
            if (rb != currentBoid)
            {
                alignment += rb.velocity;
            }
        }

        alignment /= rigidbodies.Count;
        alignment.Normalize();
        return alignment;
    }

    Vector3 CalculateCohesion(Rigidbody currentBoid)
    {
        Vector3 cohesion = Vector3.zero;
        foreach (Rigidbody rb in rigidbodies)
        {
            if (rb != currentBoid)
            {
                cohesion += rb.position;
            }
        }

        cohesion /= rigidbodies.Count;
        Vector3 directionToAverageCenterOfMass = (cohesion - currentBoid.position);
        directionToAverageCenterOfMass.Normalize();
        return directionToAverageCenterOfMass;
    }

    Vector3 CalculateSeperation(Rigidbody currentBoid)
    {
        Vector3 seperation = Vector3.zero;
        foreach (Rigidbody rb in rigidbodies)
        {
            if (rb != currentBoid)
            {
                seperation += (rb.position - currentBoid.position);
            }
        }

        seperation *= -1;
        seperation /= rigidbodies.Count;
        return seperation;
    }

    void SpawnBoids()
    {
        foreach (GameObject boid in boidObjects)
        {
            boid.transform.localPosition = new Vector3(charPosX + 0.5f, charPosY + 0.5f, charPosZ + 0.5f);
            boid.SetActive(true);
        }
    }

    void KillBoids()
    {
        foreach (GameObject boid in boidObjects)
        {
            boid.SetActive(false);
        }

    }

    void Update()
    {
        Vector3 alignment = Vector3.zero;
        Vector3 cohesion = Vector3.zero;
        Vector3 seperation = Vector3.zero;

        foreach (Rigidbody rb in rigidbodies)
        {
            alignment = CalculateAlignment(rb);
            cohesion = CalculateCohesion(rb);
            seperation = CalculateSeperation(rb);

            Vector3 directionToTarget = watcherRb.position - rb.position;
            Vector3 finalVelocity = alignment + cohesion + seperation * distance + directionToTarget;
            finalVelocity.Normalize();
            finalVelocity *= speed;
            rb.velocity = finalVelocity;
        }

        charScaleX = watcher.transform.localScale.x;
        charScaleY = watcher.transform.localScale.y;
        charScaleZ = watcher.transform.localScale.z;

        charPosX = watcher.transform.localPosition.x;
        charPosY = watcher.transform.localPosition.y;
        charPosZ = watcher.transform.localPosition.z;

        if (Input.GetKeyDown("h") && isDivided == false)
        {
            watcher.transform.localScale = new Vector3(charScaleX - sizeDifference, charScaleY - sizeDifference, charScaleZ - sizeDifference);
            watcherRb.mass = 0.5f;
            isDivided = true;
            SpawnBoids();

        }

        if (Input.GetKeyDown("j") && isDivided)
        {
            watcher.transform.localScale = new Vector3(charScaleX + sizeDifference, charScaleY + sizeDifference, charScaleZ + sizeDifference);
            watcherRb.mass = 1f;
            isDivided = false;
            KillBoids();
        }


    }
}
