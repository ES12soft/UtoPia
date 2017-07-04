using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour {

    public int number;

    SpriteRenderer x;
    
    void Start ()
    {
        x = GetComponent<SpriteRenderer>();

        number = 1;

        x.sprite = Resources.Load<Sprite>(number.ToString());

        Debug.Log("ww");
	}
	
	// Update is called once per frame
	void Update ()
    {
        x.sprite = Resources.Load<Sprite>(number.ToString());
    }
    public void plus()
    {
        if (number < 5)
        {
            number++;

            x.sprite = Resources.Load<Sprite>(number.ToString());
        }
        else
            number = 0;

     }
    public void minus()
    {
        if (number > 0)
        {
            number--;
            x.sprite = Resources.Load<Sprite>(number.ToString());
        }
        else
            number = 5;
    }
}
