using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmScript : MonoBehaviour
{

    public GameObject tile1;
    public GameObject tile2;
    public GameObject tile3;
    public GameObject tile4;
    public GameObject tile5;

    public GameObject playerSideN;
    public GameObject playerSideE;
    public GameObject playerSideS;
    public GameObject playerSideW;

    public GameObject HerbImage;
    public GameObject PatatoImage;
    public GameObject TuberImage;

    public GameObject player;
    public GameObject[] workList;

    public float walkSpeed;

    private bool nextOne = false;
    private int i = 0;
    private int j = 0;

    public Text herbCount;
    public Text patatoCount;
    public Text tuberCount;

    public int herbN = 0;
    public int pataN = 0;
    public int tubeN = 0;

    public bool herbOn = false;
    public bool patatoOn = false;
    public bool tuberOn = true;


    void Update()
    {

        transform.Translate(Input.GetAxisRaw("Horizontal") * walkSpeed, Input.GetAxisRaw("Vertical") * walkSpeed, 0);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            player.GetComponent<SpriteRenderer>().sprite = playerSideN.GetComponent<SpriteRenderer>().sprite;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            player.GetComponent<SpriteRenderer>().sprite = playerSideS.GetComponent<SpriteRenderer>().sprite;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.GetComponent<SpriteRenderer>().sprite = playerSideE.GetComponent<SpriteRenderer>().sprite;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.GetComponent<SpriteRenderer>().sprite = playerSideW.GetComponent<SpriteRenderer>().sprite;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mark" && nextOne == false)
        {
            nextOne = true;
            workList[i] = collision.gameObject;
            workList[i].tag = "Done";
            StartCoroutine(ExampleCoroutine());
        }
    }

    IEnumerator ExampleCoroutine()
    {
        if (j == 0)
        {
            workList[i].GetComponent<SpriteRenderer>().sprite = tile2.GetComponent<SpriteRenderer>().sprite;
            yield return new WaitForSeconds(0.1f);
        }
        if(j == 1)
        {
            workList[i].GetComponent<SpriteRenderer>().sprite = tile3.GetComponent<SpriteRenderer>().sprite;
            yield return new WaitForSeconds(0.1f);
        }
        if (j == 2)
        {
            workList[i].GetComponent<SpriteRenderer>().sprite = tile4.GetComponent<SpriteRenderer>().sprite;
            yield return new WaitForSeconds(0.1f);
        }
        if (j == 3) {
            workList[i].GetComponent<SpriteRenderer>().sprite = tile5.GetComponent<SpriteRenderer>().sprite;
            yield return new WaitForSeconds(0.1f);
        }
        if (j == 4) {
            workList[i].GetComponent<SpriteRenderer>().sprite = tile1.GetComponent<SpriteRenderer>().sprite;
            if(tuberOn == true)
            {
                Instantiate(TuberImage, workList[i].transform.position, Quaternion.identity);              
            }
            if (herbOn == true)
            {
                Instantiate(HerbImage, workList[i].transform.position, Quaternion.identity);
            }
            if (patatoOn == true)
            {
                Instantiate(PatatoImage, workList[i].transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(0.1f);
        }
        

        i++;

        if (i == 12)
        {
            workList[0].tag = "Mark"; workList[1].tag = "Mark"; workList[2].tag = "Mark";
            workList[3].tag = "Mark"; workList[4].tag = "Mark"; workList[5].tag = "Mark";
            workList[6].tag = "Mark"; workList[7].tag = "Mark"; workList[8].tag = "Mark";
            workList[9].tag = "Mark"; workList[10].tag = "Mark"; workList[11].tag = "Mark";
            if (i == 12)
            {
                yield return new WaitForSeconds(0.01f);
                workList[0] = null; workList[1] = null; workList[2] = null;
                workList[3] = null; workList[4] = null; workList[5] = null;
                workList[6] = null; workList[7] = null; workList[8] = null;
                workList[9] = null; workList[10] = null; workList[11] = null;
                i = 0;
                j++;
                if(j == 5)
                {
                    j = 0;
                }
            }
        }
        nextOne = false;
    }
}