using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color_changer : MonoBehaviour
{
    public Color32[] colors;
    public bool changeNow;
    GameObject[] dots, cross;
    public int colorNum;
    public GameObject circle1, circle2, bg;
    ray_n_move rnm;
    public bool died;

    void Start()
    {
        rnm = GetComponent<ray_n_move>();
        StartCoroutine(randColor());
        colorNum = Random.Range(0, colors.Length);
    }

    void Update()
    {
        if (changeNow)
        {
            bg.GetComponent<SpriteRenderer>().color = new Color32(rnm.bgColor1, rnm.bgColor2, rnm.bgColor3, 255);

            dots = GameObject.FindGameObjectsWithTag("dot");
            cross = GameObject.FindGameObjectsWithTag("cros");

            for (int a = 0; a < dots.Length; a++)
            {
                dots[a].GetComponent<SpriteRenderer>().color = Color32.Lerp(dots[a].GetComponent<SpriteRenderer>().color, new Color32(colors[colorNum].r, colors[colorNum].g, colors[colorNum].b, (byte)(dots[a].GetComponent<SpriteRenderer>().color.a * 255)), 1f * Time.deltaTime);
            }
            for(int b = 0; b < cross.Length; b++)
            {
                cross[b].GetComponent<SpriteRenderer>().color = Color32.Lerp(cross[b].GetComponent<SpriteRenderer>().color, new Color32(colors[colorNum].r, colors[colorNum].g, colors[colorNum].b, (byte)(cross[b].GetComponent<SpriteRenderer>().color.a * 255)), 1f * Time.deltaTime);
            }
            circle1.GetComponent<SpriteRenderer>().color = Color32.Lerp(circle1.GetComponent<SpriteRenderer>().color, colors[colorNum], 1f * Time.deltaTime);
            circle2.GetComponent<SpriteRenderer>().color = Color32.Lerp(circle2.GetComponent<SpriteRenderer>().color, colors[colorNum], 1f * Time.deltaTime);
        }

        if (died)
        {
            changeNow = false;

            dots = GameObject.FindGameObjectsWithTag("dot");
            cross = GameObject.FindGameObjectsWithTag("cros");

            for (int a = 0; a < dots.Length; a++)
            {
                dots[a].GetComponent<dot_outScreen>().fade = true;
            }
            for (int b = 0; b < cross.Length; b++)
            {
                cross[b].GetComponent<cross_outScreen>().fade = true;
            }
        }
    }

    IEnumerator randColor()
    {
        yield return new WaitForSeconds(5);
        colorNum = Random.Range(0, colors.Length);
        StartCoroutine(randColor());
    }
}
