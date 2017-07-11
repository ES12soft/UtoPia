using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomWindow : MonoBehaviour {
    public GameObject RainWindow;
    public GameObject CleanWindow;
    public GameObject DarkWindow;
    public GameObject CurtainClose;
    public GameObject StarPowder;
    //창문 상태 : 1.비오는날, 2.맑은날, 3.커튼을 걷음(밤)
    public int Window_State = 1;
    //커튼 상태 : 1.닫혀있음, 2.열려있음
    public int Curtain_State = 1;
    public void Window_State_Change()
    {
        if (Curtain_State == 1)
        {
            if (Window_State >= 3)
            {
                Window_State = 1;
                Curtain_State = 2;
            }
            else
            {
                Window_State++;
                Curtain_State = 2;
            }
        }
        else if (Curtain_State == 2)
        {
            Curtain_State = 1;
        }

    }
    void WindowSetActive()
    {
       
        switch(Window_State)
        {
            case 1:
                RainWindow.SetActive(true);
                CleanWindow.SetActive(false);
                DarkWindow.SetActive(false);
                break;
            case 2:
                RainWindow.SetActive(false);
                CleanWindow.SetActive(true);
                DarkWindow.SetActive(false);
                break;
            case 3:
                RainWindow.SetActive(false);
                CleanWindow.SetActive(false);
                DarkWindow.SetActive(true);
                break;
            default:
                break;
        }

        switch(Curtain_State)
        {
            case 1:
                CurtainClose.SetActive(true);
                StarPowder.SetActive(true);
                break;
            case 2:
                CurtainClose.SetActive(false);
                StarPowder.SetActive(false);
                break;
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        WindowSetActive();
	}
}
