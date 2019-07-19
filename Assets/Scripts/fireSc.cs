using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSc : MonoBehaviour
{
    public GameObject firePar, fireCol, fireDetectCol, scCont;
    
    void Update()
    {
        fireCol.transform.position = firePar.transform.position;

        firePar.transform.localPosition = new Vector3(firePar.transform.position.x, scCont.GetComponent<ray_n_move>().firePos - 1, 8);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject == fireCol)
        {
            col.gameObject.SetActive(false);
            scCont.GetComponent<ray_n_move>().dying();
        }
    }
}
