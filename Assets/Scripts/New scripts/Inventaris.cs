using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventaris : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject inventoryImg;

    public GameObject tuberWText;
    public GameObject herbWText;
    public GameObject potatoWText;

    public GameObject inventoryButton;
    public GameObject inventoryExitButton;

    public int tuberCount;
    public int herbCount;
    public int potatoCount;

    private int wPos;

    private bool inMenu = false;

    //Holders
    private GameObject mh1;
    private GameObject mh2;
    private GameObject iIHolder;

    private GameObject tuberImgHolder;
    private GameObject herbImgHolder;
    private GameObject potatoImgHolder;

    private Text tuberText;
    private Text herbText;
    private Text potatoText;

    //IventoryActiveFarmAbles
    public bool tuberActive = true;
    public bool herbActive = true;
    public bool potatoActive = true;

    public bool hActive = false;
    public bool h2Active = false;
    public bool h3Active = false;

    public bool h4Active = false;
    public bool h5Active = false;
    public bool h6Active = false;

    //InventoryPositions
    private GameObject[] allPos;

    private GameObject iPos1;
    private GameObject iPos2;
    private GameObject iPos3;

    private GameObject iPos4;
    private GameObject iPos5;
    private GameObject iPos6;

    private GameObject iPos7;
    private GameObject iPos8;
    private GameObject iPos9;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (inMenu == false)
        {
            mh1 = GameObject.FindWithTag("menuButton");
            mh1.GetComponent<Button>().onClick.AddListener(OpenMenu);
        }
        if(inMenu == true)
        {
            mh2 = GameObject.FindWithTag("menuExitButton");
            mh2.GetComponent<Button>().onClick.AddListener(CloseMenu);          
        }

    }

    public void OpenMenu()
    {
        inMenu = true;
        mh1.GetComponent<Button>().onClick.AddListener(null);
        iIHolder = Instantiate(inventoryImg, Canvas.transform.position, Quaternion.identity);
        iPos1 = GameObject.FindWithTag("iPos1");
        iPos2 = GameObject.FindWithTag("iPos2");
        iPos3 = GameObject.FindWithTag("iPos3");

        iPos4 = GameObject.FindWithTag("iPos4");
        iPos5 = GameObject.FindWithTag("iPos5");
        iPos6 = GameObject.FindWithTag("iPos6");

        iPos7 = GameObject.FindWithTag("iPos7");
        iPos8 = GameObject.FindWithTag("iPos8");
        iPos9 = GameObject.FindWithTag("iPos9");

        allPos[0] = iPos1; allPos[1] = iPos2; allPos[2] = iPos3;
        allPos[3] = iPos4; allPos[4] = iPos5; allPos[5] = iPos6;
        allPos[6] = iPos7; allPos[7] = iPos8; allPos[8] = iPos9;

        if (tuberActive == true)
        {
            tuberImgHolder = Instantiate(tuberWText, allPos[wPos].transform.position, Quaternion.identity);
            wPos++;
            tuberText = GameObject.Find("tuberText").GetComponent<Text>();
            tuberText.text = tuberCount.ToString();
        }
        if (herbActive == true)
        {
            herbImgHolder = Instantiate(herbWText, allPos[wPos].transform.position, Quaternion.identity);
            wPos++;
            herbText = GameObject.Find("herbText").GetComponent<Text>();
            herbText.text = herbCount.ToString();
        }
        if (potatoActive == true)
        {
            potatoImgHolder = Instantiate(potatoWText, allPos[wPos].transform.position, Quaternion.identity);
            wPos++;
            potatoText = GameObject.Find("potatoText").GetComponent<Text>();
            potatoText.text = potatoCount.ToString();
        }
    }

    public void CloseMenu()
    {
        wPos = 0;
        inMenu = false;
        mh2.GetComponent<Button>().onClick.AddListener(null);
        iPos1 = null;
        iPos2 = null;
        iPos3 = null;

        iPos4 = null;
        iPos5 = null;
        iPos6 = null;

        iPos7 = null;
        iPos8 = null;
        iPos9 = null;

        allPos[0] = null;  allPos[1] = null;  allPos[2] = null; 
        allPos[3] = null;  allPos[4] = null;  allPos[5] = null; 
        allPos[6] = null;  allPos[7] = null;  allPos[8] = null;

        tuberText = null;
        herbText = null;
        potatoText = null;

        Destroy(tuberImgHolder);
        Destroy(herbImgHolder);
        Destroy(potatoImgHolder);
        Destroy(iIHolder);
    }
}
