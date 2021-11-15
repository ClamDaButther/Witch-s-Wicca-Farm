using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmItemToTargetUI : MonoBehaviour
{
    private GameObject targetTuber;
    private GameObject targetPotato;
    private GameObject targetHerb;

    private GameObject Witch;

    public float speed;
    private float step;

    public bool TuberOn1;
    public bool patatoOn1;
    public bool HerbOn1;

    private bool killItem = false;

    void Start()
    {

    }

    void Update()
    {

        Witch = GameObject.Find("Witch");
        targetTuber = GameObject.Find("tuber44");
        targetPotato = GameObject.Find("potato44");
        targetHerb = GameObject.Find("herb44");

        TuberOn1 = Witch.GetComponent<FarmScript>().tuberOn;
        patatoOn1 = Witch.GetComponent<FarmScript>().patatoOn;
        HerbOn1 = Witch.GetComponent<FarmScript>().herbOn;

        StartCoroutine(CoroutineFITTUI());


        if (transform.position == targetTuber.transform.position && killItem == false)
        {
            killItem = true;
            Witch.GetComponent<FarmScript>().tuberCount.text = ": " + Witch.GetComponent<FarmScript>().tubeN++;
            Destroy(gameObject);
        }
        if (transform.position == targetPotato.transform.position && killItem == false)
        {
            killItem = true;
            Witch.GetComponent<FarmScript>().patatoCount.text = ": " + Witch.GetComponent<FarmScript>().pataN++;
            Destroy(gameObject);
        }
        if (transform.position == targetHerb.transform.position && killItem == false)
        {
            killItem = true;
            Witch.GetComponent<FarmScript>().herbCount.text = ": " + Witch.GetComponent<FarmScript>().herbN++;
            Destroy(gameObject);

        }
    }

    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
    }

    IEnumerator CoroutineFITTUI()
    {
        if (TuberOn1 == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTuber.transform.position, step);
            yield return new WaitForSeconds(2.5f);
            killItem = true;
            if (killItem == true)
            {
                Witch.GetComponent<FarmScript>().tubeN++;
                yield return new WaitForSeconds(0.4f);
                Destroy(gameObject);
            }
        }
        if (patatoOn1 == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPotato.transform.position, step);
            yield return new WaitForSeconds(2.5f);
            killItem = true;
            if (killItem == true)
            {
                Witch.GetComponent<FarmScript>().pataN++;
                yield return new WaitForSeconds(0.4f);
                Destroy(gameObject);
            }
        }
        if (HerbOn1 == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetHerb.transform.position, step);
            yield return new WaitForSeconds(2.1f);
            killItem = true;
            if (killItem == true)
            {
                Witch.GetComponent<FarmScript>().herbN++;
                yield return new WaitForSeconds(0.4f);
                Destroy(gameObject);
            }
        }

        yield return new WaitForSeconds(0.5f);
        
    }
}
