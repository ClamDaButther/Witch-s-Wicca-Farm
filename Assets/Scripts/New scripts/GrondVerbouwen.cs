using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrondVerbouwen : MonoBehaviour
{
    public GameObject player;
    // Targets tile and outline
    private GameObject[] farmTiles;
    private GameObject targetTile;
    private GameObject oldTargetTile;

    private string[] dbHolder;
    private float[] distanceBetween;
    private string holderS;
    private float smallestNumberOfArray;

    private int i;
    private int j;
    private int indexNumberArray;

    public float distanceToMarkTile;
    

    //Tile work

    public GameObject tile1;
    public GameObject tile2;
    public GameObject tile3;
    public GameObject tile4;
    public GameObject tile3dot1;

    public GameObject plantSprite;
    public GameObject waterSprite;
    public GameObject magicSprite;
    public GameObject HarvestSprite;

    public GameObject buttonSpriteHolder;

    private GameObject ms;
    private GameObject ws;
    private GameObject hs;
    private GameObject ps;

    public int herbN = 0;
    public int pataN = 0;
    public int tubeN = 0;

    private int k;
    private int l;

    private int[] plantStage;

    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;

    public GameObject Canvas;

    public GameObject farmButtonHolderB1;
    public GameObject farmButtonHolderB2;
    public GameObject farmButtonHolderB3;
    public GameObject farmButtonHolderB4;

    private bool[] close1;
    private bool[] close2;
    private bool[] close3;
    private bool[] close4;

    public GameObject HerbImage;
    public GameObject PatatoImage;
    public GameObject TuberImage;

    void Start()
    {
        farmTiles = GameObject.FindGameObjectsWithTag("FarmTile");

        for (l = 0; l < farmTiles.Length; l++)
        {
            plantStage[l] = 0;
            close1[l] = false;
            close2[l] = true;
            close3[l] = true;
            close4[l] = true;
        }
    }

    void Update()
    {
        
        //Checks what tile is closest

        for (i = 0; i < farmTiles.Length; i++)
        {
            distanceBetween[i] = Vector2.Distance(player.transform.position, farmTiles[i].transform.position);
        }

        //Gets smallest number
        smallestNumberOfArray = Mathf.Min(distanceBetween);
        if (distanceToMarkTile >= smallestNumberOfArray)
        {
            //Sets smallest number to string
            holderS = smallestNumberOfArray.ToString();
            for (j = 0; j < distanceBetween.Length; j++)
            {
                dbHolder[j] = distanceBetween[j].ToString();
            }
            indexNumberArray = Array.IndexOf(dbHolder, holderS);
            //Sets target
            targetTile = farmTiles[indexNumberArray];
        }
        else if (distanceToMarkTile < smallestNumberOfArray && distanceToMarkTile != smallestNumberOfArray)
        {
            targetTile = null;
        }

            //Outlines closest tile yellow
            targetTile.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        if (oldTargetTile == null)
        {
            oldTargetTile = targetTile;
        }
        if (targetTile.transform.hasChanged)
        {
            oldTargetTile.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Vector4(0, 0, 0, 0));
            oldTargetTile = targetTile;
            targetTile.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Vector4(255, 223, 0, 0));
        }





        //Buttons
        //b1
        if (plantStage[indexNumberArray] == 0 && close1[indexNumberArray] == false) 
        {

            var b1h = Instantiate(farmButtonHolderB1, Canvas.transform.position, Quaternion.identity);
            b1h.transform.SetParent(Canvas.transform);

            b1 = GameObject.FindWithTag("FarmButton1");
            b1.GetComponent<Button>().onClick.AddListener(b1Action);
            ps = Instantiate(plantSprite, buttonSpriteHolder.transform.position, Quaternion.identity);
            ps.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            ps.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Vector4(0, 255, 0, 0));
            Destroy(ms);
            Destroy(hs);
            Destroy(ws);
        }
        if (plantStage[indexNumberArray] == 0 && close1[indexNumberArray] == true)
        {
            ps = Instantiate(plantSprite, buttonSpriteHolder.transform.position, Quaternion.identity);
            ps.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            ps.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Vector4(255, 0, 0, 0));
            Destroy(ms);
            Destroy(hs);
            Destroy(ws);
        }
            //b2
            if (plantStage[indexNumberArray] == 1 && close2[indexNumberArray] == false)
        {

            var b2h = Instantiate(farmButtonHolderB2, Canvas.transform.position, Quaternion.identity);
            b2h.transform.SetParent(Canvas.transform);

            b2 = GameObject.FindWithTag("FarmButton1");
            b2.GetComponent<Button>().onClick.AddListener(b2Action);
            ws = Instantiate(waterSprite, buttonSpriteHolder.transform.position, Quaternion.identity);
            ws.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            ws.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Vector4(0, 255, 0, 0));
            Destroy(ps);
            Destroy(ms);
            Destroy(hs);
        }
        if (plantStage[indexNumberArray] == 1 && close2[indexNumberArray] == true)
        {
            ws = Instantiate(waterSprite, buttonSpriteHolder.transform.position, Quaternion.identity);
            ws.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            ws.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Vector4(255, 0, 0, 0));
            Destroy(ps);
            Destroy(ms);
            Destroy(hs);
        }
            //b3
            if (plantStage[indexNumberArray] == 2 && close3[indexNumberArray] == false)
        {

            var b3h = Instantiate(farmButtonHolderB3, Canvas.transform.position, Quaternion.identity);
            b3h.transform.SetParent(Canvas.transform);

            b3 = GameObject.FindWithTag("FarmButton1");
            b3.GetComponent<Button>().onClick.AddListener(b3Action);
            ms = Instantiate(magicSprite, buttonSpriteHolder.transform.position, Quaternion.identity);
            ms.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            ms.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Vector4(0, 255, 0, 0));
            Destroy(hs);
            Destroy(ps);
            Destroy(ws);
        }
        if (plantStage[indexNumberArray] == 2 && close3[indexNumberArray] == true)
        {
            ms = Instantiate(magicSprite, buttonSpriteHolder.transform.position, Quaternion.identity);
            ms.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            ms.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Vector4(255, 0, 0, 0));
            Destroy(hs);
            Destroy(ps);
            Destroy(ws);
        }
            //4
            if (plantStage[indexNumberArray] == 3 && close4[indexNumberArray] == false)
        {

            var b4h = Instantiate(farmButtonHolderB4, Canvas.transform.position, Quaternion.identity);
            b4h.transform.SetParent(Canvas.transform);

            b4 = GameObject.FindWithTag("FarmButton1");
            b4.GetComponent<Button>().onClick.AddListener(b4Action);
            hs = Instantiate(HarvestSprite, buttonSpriteHolder.transform.position, Quaternion.identity);
            hs.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            hs.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Vector4(0, 255, 0, 0));
            Destroy(ms);
            Destroy(ps);
            Destroy(ws);
        }
        if (plantStage[indexNumberArray] == 3 && close4[indexNumberArray] == true)
        {
            hs = Instantiate(HarvestSprite, buttonSpriteHolder.transform.position, Quaternion.identity);
            hs.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            hs.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Vector4(255, 0, 0, 0));
            Destroy(ms);
            Destroy(ps);
            Destroy(ws);
        }
    }

    public void b1Action()
    {
        close1[indexNumberArray] = true;
        ps.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Vector4(255, 0, 0, 0));
        StartCoroutine(ExampleCoroutine1());
    }
    public void b2Action()
    {
        close2[indexNumberArray] = true;
        ws.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Vector4(255, 0, 0, 0));
        StartCoroutine(ExampleCoroutine2());
    }
    public void b3Action()
    {
        close3[indexNumberArray] = true;
        ms.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Vector4(255, 0, 0, 0));
        StartCoroutine(ExampleCoroutine3());
    }
    public void b4Action()
    {
        close4[indexNumberArray] = true;
        hs.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Vector4(255, 0, 0, 0));
        StartCoroutine(ExampleCoroutine4());
    }


    IEnumerator ExampleCoroutine1()
    {
        plantStage[indexNumberArray] = 1;
        Destroy(b1);
        targetTile.GetComponent<SpriteRenderer>().sprite = tile1.GetComponent<SpriteRenderer>().sprite;
        yield return new WaitForSeconds(2.0f);
        close2[indexNumberArray] = false;
    }
    IEnumerator ExampleCoroutine2()
    {
        plantStage[indexNumberArray] = 2;
        Destroy(b2);
        targetTile.GetComponent<SpriteRenderer>().sprite = tile2.GetComponent<SpriteRenderer>().sprite;
        yield return new WaitForSeconds(30.1f);
        close3[indexNumberArray] = false;
    }
    IEnumerator ExampleCoroutine3()
    {
        plantStage[indexNumberArray] = 3;
        Destroy(b3);
        targetTile.GetComponent<SpriteRenderer>().sprite = tile3.GetComponent<SpriteRenderer>().sprite;
        yield return new WaitForSeconds(30.1f);
        targetTile.GetComponent<SpriteRenderer>().sprite = tile3dot1.GetComponent<SpriteRenderer>().sprite;
        yield return new WaitForSeconds(40.1f);
        close4[indexNumberArray] = false;
    }
    IEnumerator ExampleCoroutine4()
    {
        plantStage[indexNumberArray] = 0;
        Destroy(b4);
        targetTile.GetComponent<SpriteRenderer>().sprite = tile4.GetComponent<SpriteRenderer>().sprite;
        var ptt = Instantiate(PatatoImage, targetTile.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2.1f);
        Destroy(ptt);
        close1[indexNumberArray] = false;
    }
  }
