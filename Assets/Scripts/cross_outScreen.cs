using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cross_outScreen : MonoBehaviour
{
    bool colorOn;
    public bool fade;

    void Update()
    {
        if (colorOn)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color32.Lerp(GetComponent<SpriteRenderer>().color, new Color32((byte)(gameObject.GetComponent<SpriteRenderer>().color.r * 255), (byte)(gameObject.GetComponent<SpriteRenderer>().color.g * 255), (byte)(gameObject.GetComponent<SpriteRenderer>().color.b * 255), 255), 3f * Time.deltaTime);
        }

        if (fade)
        {
            colorOn = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color32.Lerp(GetComponent<SpriteRenderer>().color, new Color32((byte)(gameObject.GetComponent<SpriteRenderer>().color.r * 255), (byte)(gameObject.GetComponent<SpriteRenderer>().color.g * 255), (byte)(gameObject.GetComponent<SpriteRenderer>().color.b * 255), 0), 5f * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "colorOn")
        {
            colorOn = true;
        }

        else if (col.gameObject.tag == "dD")
        {
            gameObject.SetActive(false);
            colorOn = false;
            gameObject.GetComponent<SpriteRenderer>().color = new Color32((byte)(gameObject.GetComponent<SpriteRenderer>().color.r * 255), (byte)(gameObject.GetComponent<SpriteRenderer>().color.g * 255), (byte)(gameObject.GetComponent<SpriteRenderer>().color.b * 255), 0);
        }
    }
}
