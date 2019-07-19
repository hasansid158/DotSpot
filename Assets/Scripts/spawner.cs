using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    float dist = 1;
    objPools poolSc;
    GameObject dot, cross, cross2;
    int rand, dotRand;

    void Start()
    {
        poolSc = GetComponent<objPools>();

        dot = poolSc.getDot();
        dot.GetComponent<checker>().clickNow = true;
        dot.transform.position = new Vector2(Random.Range(-1.95f, 1.95f), 1);
        dot.GetComponent<SpriteRenderer>().color = GetComponent<color_changer>().colors[GetComponent<color_changer>().colorNum];
        dot.SetActive(true);

        for (int a = 0; a < 4; a++)
        {
            genrateNew();
        }
    }

    public void genrateNew()
    {
        dist += Random.Range(1.5f, 2);

        rand = Random.Range(1, 5);
        dotRand = Random.Range(1, 5);

        if (dotRand == 2)
        {
            dot = poolSc.getDot();
            dot.GetComponent<checker>().clickNow = false;
            dot.GetComponent<dot_outScreen>().mover = true;
            int randLr = Random.Range(1, 4);

            if(randLr == 2 || randLr == 4)
            {
                dot.GetComponent<dot_outScreen>().right = true;
            }
            else if(randLr == 1 || randLr == 3)
            {
                dot.GetComponent<dot_outScreen>().left = true;
            }
            dot.transform.position = new Vector2(Random.Range(-1.95f, 1.95f), dist);
            dot.SetActive(true);
        }
        else
        {
            dot = poolSc.getDot();
            dot.GetComponent<checker>().clickNow = false;
            dot.transform.position = new Vector2(Random.Range(-1.95f, 1.95f), dist);
            dot.SetActive(true);

            if (rand == 2)
            {
                if (dot.transform.position.x >= 0)
                {
                    cross = poolSc.getCross();
                    cross.transform.position = new Vector2(dot.transform.position.x - Random.Range(1, 1.4f), dot.transform.position.y);
                    cross.SetActive(true);
                }
                else
                {
                    cross = poolSc.getCross();
                    cross.transform.position = new Vector2(dot.transform.position.x + Random.Range(1, 1.4f), dot.transform.position.y);
                    cross.SetActive(true);
                }
            }
            else if (rand == 4)
            {
                if (dot.transform.position.x >= 0)
                {
                    cross = poolSc.getCross();
                    cross.transform.position = new Vector2(dot.transform.position.x - Random.Range(1, 1.4f), dot.transform.position.y);
                    cross.SetActive(true);

                    cross2 = poolSc.getCross();
                    cross2.transform.position = new Vector2(cross.transform.position.x - Random.Range(0.6f, 1.4f), dot.transform.position.y);
                    cross2.SetActive(true);
                }
                else
                {
                    cross = poolSc.getCross();
                    cross.transform.position = new Vector2(dot.transform.position.x + Random.Range(1, 1.4f), dot.transform.position.y);
                    cross.SetActive(true);

                    cross2 = poolSc.getCross();
                    cross2.transform.position = new Vector2(cross.transform.position.x + Random.Range(0.6f, 1.4f), dot.transform.position.y);
                    cross2.SetActive(true);
                }
            }
        }
    }
}
