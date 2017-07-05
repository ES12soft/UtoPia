using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour {

    // Use this for initialization
    
	void Start () {

        //PlayerPrefs.DeleteAll();

        if (PlayerPrefs.GetInt("StartMain", 0) == 1)
        {
            gameObject.transform.Find("0_StartMain").gameObject.SetActive(false);
            gameObject.transform.Find("1_Main").gameObject.SetActive(true);
        }

        else
        {
            gameObject.transform.Find("0_StartMain").gameObject.SetActive(true);
            gameObject.transform.Find("1_Main").gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
