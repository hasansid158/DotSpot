using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objPools : MonoBehaviour
{
    public GameObject dot, cross;

    List<GameObject> dotList;
    List<GameObject> crossList;

    void Awake()
    {
        dotList = new List<GameObject>();
        crossList = new List<GameObject>();

        //looping and creating objects 7 times
        for (int a = 0; a < 7; a++)
        {
            //creating new instance of dot game object in the hierarchy and making it inactive and then adding it to the list to use later
            GameObject dotP = (GameObject)Instantiate(dot);
            dotP.SetActive(false);
            dotList.Add(dotP);

            GameObject crossP = (GameObject)Instantiate(cross);
            crossP.SetActive(false);
            crossList.Add(crossP);
        }
    }

    public GameObject getDot()
    {
        //looping through the list of dot list
        for(int a = 0; a < dotList.Count; a++)
        {
            //current item in the list in active?
            if (!dotList[a].activeInHierarchy)
            {
                dotList[a].GetComponent<checker>().clickNow = false;
                //returning the item which is not active
                return dotList[a];
            }
        }
        //if all the items are active then creating another game object and adding it to the list and returning it
        GameObject dotP = (GameObject)Instantiate(dot);
        dotP.SetActive(false);
        dotList.Add(dotP);

        return dotP;
    }

    public GameObject getCross()
    {
        for (int a = 0; a < crossList.Count; a++)
        {
            if (!crossList[a].activeInHierarchy)
            {
                return crossList[a];
            }
        }

        GameObject crossP = (GameObject)Instantiate(cross);
        crossP.SetActive(false);
        crossList.Add(crossP);

        return crossP;
    }
}
