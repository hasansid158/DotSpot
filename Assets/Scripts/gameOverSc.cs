using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverSc : MonoBehaviour
{
    public GameObject[] menuObjs;
    public GameObject fader;
    bool pressed;

    int ad_Count;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                back();
            }
            else
            {
                Application.Quit();
                Debug.Log("QUIT");
            }
        }
    }

    public void gameOverMenu()
    {
        for(int a = 0; a < menuObjs.Length; a++)
        {
            menuObjs[a].SetActive(true);
        }
    }

    public void back()
    {
        if (!pressed)
        {
            pressed = true;

            fader.GetComponent<Animation>().Play("fade");
            StartCoroutine(reback());
        }
    }

    IEnumerator reback()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

    public void reSet()
    {
        if (!pressed)
        {
            pressed = true;

            if (GameObject.FindGameObjectWithTag("admob").GetComponent<admob>().ad_rand <= 0)
            {
                Debug.Log(GameObject.FindGameObjectWithTag("admob").GetComponent<admob>().ad_rand);
                GameObject.FindGameObjectWithTag("admob").GetComponent<admob>().ShowFullAds();
                GameObject.FindGameObjectWithTag("admob").GetComponent<admob>().ad_rand = Random.Range(1, 5);
            }
            else
            {
                GameObject.FindGameObjectWithTag("admob").GetComponent<admob>().ad_rand--;
            }

            fader.GetComponent<Animation>().Play("fade");
            StartCoroutine(reWait());
        }
    }

    IEnumerator reWait()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
