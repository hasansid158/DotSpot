using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checker : MonoBehaviour
{
    public bool clickNow = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "chk")
        {
            clickNow = true;
        }
    }
}
