using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Divide : MonoBehaviour
{

    public Transform characterTransform;
    private Vector3 halfSize;
    public GameObject character;
    public GameObject newCharacter;

    private float charScaleX;
    private float charScaleY;
    private float charScaleZ;
    private float difference;
    public GameObject[] divisionsArray;


    public float charShrink;
    private bool isDivided;


    // Start is called before the first frame update
    void Start()
    {
        characterTransform = GetComponent<Transform>();
        charScaleX = characterTransform.localScale.x;
        charScaleY = characterTransform.localScale.y;
        charScaleZ = characterTransform.localScale.z;

       // isDivided = true;
        //character = GameObject.FindWithTag("CanDivide");
        //divisionsArray  = new GameObject[2];
    }

        //void DivideCharacter()
        //{
        //    charShrink = 0.5F;
        //    difference = Random.Range(2F, -3F);
        //   // halfSize = new Vector3(charScaleX / charShrink, charScaleY / charShrink, charScaleZ / charShrink);

        //    characterTransform.localScale -= halfSize;
        //    newCharacter = Instantiate(character, new Vector3(charScaleX + difference, charScaleY + difference, charScaleZ + difference), Quaternion.identity);
        //    //  newCharacter.transform.localScale(get, new Vector3(3, 3, 1);
        //    isDivided = false;
        //    Debug.Log(isDivided);

        //}


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("h"))
        {   
            Destroy(newCharacter);
            Instantiate(character, new Vector3(charScaleX, charScaleY, charScaleZ), Quaternion.identity);

        }
    }
}