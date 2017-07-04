using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 합성시스템


public class AlphaBlend : MonoBehaviour {
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Input.mousePosition);
    }

    public void AlphaBlendClick()
    {
        Debug.Log("클릭");
        Image image = this.gameObject.GetComponent<Image>();
        int speed = 2;
        var color = image.color;
        if (color.a > 0)
            color.a -= Time.deltaTime * speed;

        else
            Destroy(this.gameObject);
    }
}

