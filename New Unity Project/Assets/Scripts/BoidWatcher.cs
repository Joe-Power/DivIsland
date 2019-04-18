using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class BoidWatcher : MonoBehaviour
{
    public Rigidbody rigidBody;
    public Transform watcherTransform;
    private TextMeshProUGUI glueCountTextArea;

    public GameObject uiCanvas;
    public GameObject glue;
    public static int glueCounter;
    public int keyCounter;
  

    public float force;


    void Start()
    {
        glueCountTextArea = uiCanvas.GetComponent<TextMeshProUGUI>();  
        glueCounter = 0;
        keyCounter = 0;
        UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Glue")
        {
            glueCounter = glueCounter + 1;
            UpdateUI();      
        }
    }

    void UpdateUI()
    {
        glueCountTextArea.SetText("Glue : {0}", glueCounter);


    }

    void Update ()
    {

        
        if ( Input.GetKey( KeyCode.A ))
        {
			
            rigidBody.AddForce( new Vector3( -1, 0, 0 ) * force, ForceMode.Acceleration );
         
		} 
        else if ( Input.GetKey( KeyCode.S ))
        {
            rigidBody.AddForce( new Vector3( 0, 0, -1 ) * force, ForceMode.Acceleration );
         

		}
		else if ( Input.GetKey( KeyCode.W ))
        {
            rigidBody.AddForce( new Vector3( 0, 0,  1 ) * force, ForceMode.Acceleration );
         

		}
		else if ( Input.GetKey( KeyCode.D ))
        {
            rigidBody.AddForce( new Vector3( 1, 0, 0 ) * force, ForceMode.Acceleration );
            
		}


	}
  
}
