using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FarmingMenu : MonoBehaviour
{
    public bool menuIsOpen = false;

    public GameObject ButtonMenu;
    public GameObject ButtonExitMenu;
    public GameObject ButtonExitLevel;
    public GameObject ButtonOptions;
    public GameObject ButtonRestart;
    public GameObject ButtonStats;
    public GameObject ButtonHelp;

    public GameObject Canvas;

    public GameObject Menu;
    public GameObject CreatedMenu;

    void Start()
    {
        ButtonMenu = GameObject.FindWithTag("Button1");
        ButtonMenu.GetComponent<Button>().onClick.AddListener(OpenMenu);
    }

    void Update()
    {
        CreatedMenu = GameObject.FindWithTag("Menu");
    }

    public void OpenMenu()
    {
        if (menuIsOpen == false)
        {
            menuIsOpen = true;
            var myNewMenu = Instantiate(Menu, Canvas.transform.position, Quaternion.identity);
            myNewMenu.transform.SetParent(Canvas.transform);

            ButtonExitMenu = GameObject.FindWithTag("Button2");
            ButtonExitMenu.GetComponent<Button>().onClick.AddListener(CloseMenu);

            ButtonExitLevel = GameObject.FindWithTag("Button3");
            ButtonExitLevel.GetComponent<Button>().onClick.AddListener(ExitLevel);

            ButtonOptions = GameObject.FindWithTag("Button4");
            ButtonOptions.GetComponent<Button>().onClick.AddListener(Options);

            ButtonRestart = GameObject.FindWithTag("Button5");
            ButtonRestart.GetComponent<Button>().onClick.AddListener(Restart);

            ButtonStats = GameObject.FindWithTag("Button6");
            ButtonStats.GetComponent<Button>().onClick.AddListener(Stats);

            ButtonHelp = GameObject.FindWithTag("Button7");
            ButtonHelp.GetComponent<Button>().onClick.AddListener(Help);
        }
    }

    public void CloseMenu()
    {
        if (menuIsOpen == true)
        {
            Destroy(CreatedMenu);
            menuIsOpen = false;
        }
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("HouseScene");
    }

    public void Options()
    {

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Stats()
    {

    }

    public void Help()
    {

    }

}
