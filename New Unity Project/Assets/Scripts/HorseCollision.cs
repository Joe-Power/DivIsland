using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseCollision : MonoBehaviour
{
    public GameObject horse;
    public GameObject glue;

    private float horseX;
    private float horseY;
    private float horseZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ActivePlayer")
        {
            horse.SetActive(false);
            Invoke("spawnNewHorse", 10);
            Instantiate(glue, new Vector3(horseX, horseY, horseZ), Quaternion.identity);
        }
    }

    void spawnNewHorse()
    {
        //horse.transform.localPosition = new Vector3(Random.Range(20, -20), 0, Random.Range(-40, 40));
        horse.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        horseX = horse.transform.localPosition.x;
        horseY = horse.transform.localPosition.y;
        horseZ = horse.transform.localPosition.z;

    }
}
