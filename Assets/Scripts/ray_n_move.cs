using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ray_n_move : MonoBehaviour
{
    RaycastHit2D hit;
    public GameObject cam;
    Vector3 camPos, linePos, circlePos;
    spawner spawnSc;
    public GameObject line, circle, colorOnCol, diePart, bg, highScoreText;

    int score = 0;
    public Text scoreTxt;

    public byte bgColor1 = 212, bgColor2 = 225, bgColor3 = 255;

    float colorOnPos = 5.5f;

    bool dead, started;

    public float firePos;

    public AudioClip dieSound, touchSound;
    public GameObject soundCont;

    void Start()
    {
        GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>().volume = 0.6f;

        camPos = cam.transform.position;
        linePos = line.transform.position;
        spawnSc = GetComponent<spawner>();
        circlePos = circle.transform.position;
    }

    void Update()
    {
        if (!dead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.tag == "dot")
                    {
                        if (hit.collider.gameObject.GetComponent<checker>().clickNow)
                        {
                            started = true;
                            hit.collider.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                            camPos = new Vector3(cam.transform.position.x, hit.collider.gameObject.transform.position.y + 3, cam.transform.position.z);
                            linePos = hit.collider.gameObject.transform.position;
                            circlePos = hit.collider.gameObject.transform.position;
                            GetComponent<color_changer>().changeNow = true;
                            soundCont.GetComponent<AudioSource>().PlayOneShot(touchSound,1);

                            score++;
                            scoreTxt.text = score.ToString();

                            if (bgColor1 >= 23)
                            {
                                bgColor1--;
                            }
                            if (bgColor2 >= 30)
                            {
                                bgColor2--;
                            }
                            if (bgColor3 >= 45)
                            {
                                bgColor3--;
                            }

                            if (colorOnPos > 0.5f)
                            {
                                colorOnPos -= 0.02f;
                                colorOnCol.transform.localPosition = new Vector3(colorOnCol.transform.position.x, colorOnPos, 20);
                            }

                            if (firePos > -7)
                            {
                                firePos -= 0.5f;
                            }

                            hit.collider.gameObject.GetComponent<dot_outScreen>().fade = true;
                            spawnSc.genrateNew();
                        }
                        else
                        {
                            dying();
                        }
                        hit.collider.gameObject.GetComponent<checker>().clickNow = false;
                    }
                    else
                    {
                        dying();
                    }
                }
                else
                {
                    dying();
                }
            }
            else
            {
                if (started)
                {
                    firePos += 1.5f * Time.deltaTime;
                }
            }
        }
        else
        {
            bg.GetComponent<SpriteRenderer>().color = Color32.Lerp(bg.GetComponent<SpriteRenderer>().color, new Color32(212, 225, 255, 255), 2 * Time.deltaTime);
        }

        cam.transform.position = Vector3.Lerp(cam.transform.position, camPos, 11 * Time.deltaTime);
        line.transform.position = Vector3.Lerp(line.transform.position, linePos, 4 * Time.deltaTime);
        diePart.transform.position = new Vector3(line.transform.position.x, line.transform.position.y - 1, line.transform.position.z);
        circle.transform.position = Vector3.Lerp(circle.transform.position, circlePos, 10 * Time.deltaTime);
    }

    public void dying()
    {
        dead = true;
        GetComponent<color_changer>().died = true;
        soundCont.GetComponent<AudioSource>().PlayOneShot(dieSound, 1);

        if (score > PlayerPrefs.GetInt("high", 0))
        {
            PlayerPrefs.SetInt("high", score);
        }
        highScoreText.GetComponent<Text>().text = "Best : " + PlayerPrefs.GetInt("high", 0);
        line.GetComponent<ParticleSystem>().Stop();
        diePart.GetComponent<ParticleSystem>().Play();
        circle.GetComponent<Animation>().Play("circleDie");
        StartCoroutine(waitDead());
    }

    IEnumerator waitDead()
    {
        yield return new WaitForSeconds(1);
        GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>().volume = 0.3f;
        GetComponent<gameOverSc>().gameOverMenu();
        GameObject.FindGameObjectWithTag("admob").GetComponent<admob>().remAdBut();
    }
}
