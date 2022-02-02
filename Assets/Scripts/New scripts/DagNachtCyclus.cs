using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DagNachtCyclus : MonoBehaviour
{
    public GameObject Camera;

    public GameObject morningFrame;
    public GameObject middayFrame;
    public GameObject eveningFrame;
    public GameObject nightFrame;

    private GameObject moF;
    private GameObject miF;
    private GameObject evF;
    private GameObject niF;

    private bool cycling;
    
    void Start()
    {
        cycling = false;
    }
    
    void Update()
    {
        if (cycling == false)
        {
            StartCoroutine(TimeCycle());
        }
    }

    IEnumerator TimeCycle()
    {
        cycling = true;


        yield return new WaitForSeconds(300f);
        //6 hours
        moF = Instantiate(morningFrame, Camera.transform.position, Quaternion.identity);


        yield return new WaitForSeconds(300f);
        //12 hours
        miF = Instantiate(middayFrame, Camera.transform.position, Quaternion.identity);


        yield return new WaitForSeconds(300f);
        //18 hours
        evF = Instantiate(eveningFrame, Camera.transform.position, Quaternion.identity);


        yield return new WaitForSeconds(300f);
        //24/0 hours reached
        niF = Instantiate(nightFrame, Camera.transform.position, Quaternion.identity);


        cycling = false;
    }
}
