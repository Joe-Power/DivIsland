using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject homeUI;
    public GameObject inGameUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ShowInGameUI()
    {
        homeUI.SetActive(false);
        inGameUI.SetActive(true);

    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("return"))
        {
            ShowInGameUI();

        }
    }
}
