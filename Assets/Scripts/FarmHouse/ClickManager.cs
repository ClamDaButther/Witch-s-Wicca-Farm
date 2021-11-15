using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{

    public Button yesButton;
    public Button noButton;

    public bool goFarm = false;
    public bool closeFarmTab = false;
 

    // Update is called once per frame
    void Start()
    {
        yesButton.onClick.AddListener(SetGoFarmActive);
        noButton.onClick.AddListener(SetCloseFarmTabActive);
    }

  void SetGoFarmActive()
    {
        Debug.Log("You have clicked the button!");
        goFarm = true;
    }

   void SetCloseFarmTabActive()
    {
        Debug.Log("You have clicked the button!");
        closeFarmTab = true;
    }
}
