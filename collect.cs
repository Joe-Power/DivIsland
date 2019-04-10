using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collect : MonoBehaviour
{
    public Text countText;
    private bool istouching = true;
    private int count;
    private Rigidbody rb;
    void Start()
    {
        count = 0;
        SetCountText();
    }
    private void OnCollisionStay()
    {
        istouching = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("collectable"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}