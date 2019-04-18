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
    private TextMeshProUGUI keyCountTextArea;

    
    public GameObject glueUICanvas;
    public GameObject keyUICanvas;
    public GameObject glue;
    public static int glueCounter;
    public int keyCounter;
  

    public float force;


    void Start()
    {
        glueCountTextArea = glueUICanvas.GetComponent<TextMeshProUGUI>();
        keyCountTextArea = keyUICanvas.GetComponent<TextMeshProUGUI>();

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

        if (other.gameObject.tag == "Keys")
        {
            keyCounter = keyCounter + 1;
            UpdateUI();
        }

      
    }

    void UpdateUI()
    {
        glueCountTextArea.SetText("Glue : {0}", glueCounter);
        keyCountTextArea.SetText("Keys : {0}", keyCounter);


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
