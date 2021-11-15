using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WalkingHouse : MonoBehaviour
{
    public GameObject playerSideN;
    public GameObject playerSideE;
    public GameObject playerSideS;
    public GameObject playerSideW;

    public GameObject player;

    public GameObject pageEnterFields;

    public GameObject yesButton;
    public GameObject noButton;

    public GameObject Canvas;


    public float walkSpeed;

    public bool goFarm = false;
    public bool closeFarmTab = false;

    private bool farmPageIsOpen = false;

    public GameObject pageMenu;

    void Start()
    {
        
    }

   
    void Update()
    {
        if (farmPageIsOpen == false)
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

        if(goFarm == true)
        {
            SceneManager.LoadScene("HouseFarm");
        }

        if (closeFarmTab == true)
        {
            pageMenu = GameObject.FindWithTag("PageEnterFields");
            Destroy(pageMenu);
            farmPageIsOpen = false;
            closeFarmTab = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ExitFarm")
        {
            SceneManager.LoadScene("WildLands1");
        }

        if (collision.gameObject.tag == "EnterFields" && farmPageIsOpen == false)
        {
            farmPageIsOpen = true;
            var myNewPEF = Instantiate(pageEnterFields, Canvas.transform.position, Quaternion.identity);
            myNewPEF.transform.SetParent(Canvas.transform);
            yesButton = GameObject.FindWithTag("yesButton");
            noButton = GameObject.FindWithTag("noButton");
            yesButton.GetComponent<Button>().onClick.AddListener(SetGoFarmActive);
            noButton.GetComponent<Button>().onClick.AddListener(SetCloseFarmTabActive);
        }

    }

    public void SetGoFarmActive()
    {
        goFarm = true;
    }

   public void SetCloseFarmTabActive()
    {
        closeFarmTab = true;
    }
}
