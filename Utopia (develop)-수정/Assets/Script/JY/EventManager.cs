using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using LitJson;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Image fadeImage;
    private bool isInTransition;
    private float transition;
    private bool isShowing;
    private float duration;

    private ControlDialogue CD;
    private TextAsset Text_Data;
    private JsonData Json_Data;

    public int Event_Number=0;
    public int Event_Number_1=1;

	// Use this for initialization
	void Start ()
    {
        CD =  FindObjectOfType<ControlDialogue>();
	}
	
	// Update is called once per frame
	void Update () {
        Fadechk();
        EventList();
    }

    void Fadechk()
    {
        if (!isInTransition)
            return;

        transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
        fadeImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);

        if (transition > 1 || transition < 0)
        {
            isInTransition = false;
            Event_Number++;
        }
        Debug.Log("페이드중");
    }

    public void Fade(bool showing, float duration)
    {
        isShowing = showing;
        isInTransition = true;
        this.duration = duration;
        transition = (isShowing) ? 0 : 1;
    }

    public void EventList()
    {
        if (Event_Number_1 == Event_Number)
            return;
        else
        {
            switch (Event_Number)
            {
                case 0:
                    Fade(false, 1.5f);
                    break;
                case 1:
                    Text_Data = Resources.Load<TextAsset>("Event_1");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LodaJSON(Json_Data);
                    break;

                case 2:
                    Fade(true, 1.5f);
                    break;
                default:
                    break;
            }
            Event_Number_1 = Event_Number;
        }
    }
}
