using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueCounter : MonoBehaviour
{
    public int glueInventory;
    // Start is called before the first frame update
    void Start()
    {
        glueInventory = 0;
    }

    public void AddGlue()
    {
        glueInventory = glueInventory + 1;
        Debug.Log(glueInventory);
       
    }

    // Update is called once per frame
    void Update()
    {
         Debug.Log(glueInventory);

        if (Input.GetKey(KeyCode.J))
        {
            glueInventory = glueInventory - 1;

        }
    }
}
