using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dot_outScreen : MonoBehaviour
{
    public bool fade;
    bool colOn;
    public bool mover;
    public bool left, right;

    void Update()
    {
        if (fade)
        {
            colOn = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color32.Lerp(GetComponent<SpriteRenderer>().color, new Color32((byte)(gameObject.GetComponent<SpriteRenderer>().color.r * 255), (byte)(gameObject.GetComponent<SpriteRenderer>().color.g * 255), (byte)(gameObject.GetComponent<SpriteRenderer>().color.b * 255), 0), 5f * Time.deltaTime);
        }
        if (colOn)
        {
            GetComponent<SpriteRenderer>().color = Color32.Lerp(GetComponent<SpriteRenderer>().color, new Color32((byte)(gameObject.GetComponent<SpriteRenderer>().color.r * 255), (byte)(gameObject.GetComponent<SpriteRenderer>().color.g * 255), (byte)(gameObject.GetComponent<SpriteRenderer>().color.b * 255), 255), 3f * Time.deltaTime);
        }

        if (mover)
        {
            if (right)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(1.95f, transform.position.y, transform.position.z), 0.5f * Time.deltaTime);
            }
            else if (left)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(-1.95f, transform.position.y, transform.position.z), 0.5f * Time.deltaTime);
            }
        }
    }

    void OnBecameInvisible()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<checker>().clickNow = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "dD")
        {
            fade = false;
            mover = false;
            GetComponent<checker>().clickNow = false;
            right = false;
            left = false;            
            gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "colorOn")
        {
            colOn = true;
        }

        if (col.gameObject.tag == "right")
        {
            right = false;
            left = true;
        }

        if (col.gameObject.tag == "left")
        {
            right = true;
            left = false;
        }
    }
}
