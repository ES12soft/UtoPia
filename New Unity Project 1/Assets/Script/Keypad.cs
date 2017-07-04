using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour {

    public GameObject First;
    public GameObject Second;
    public GameObject Third;
    public GameObject Forth;
    Test first_;
    Test second_;
    Test third_;
    Test forth_;

    public string answer;
    public string qu;
    void Start ()
    {
        first_ = First.GetComponent<Test>();
        second_ = Second.GetComponent<Test>();
        third_ = Third.GetComponent<Test>();
        forth_ = Forth.GetComponent<Test>();
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void commit()
    {
        qu = first_.number.ToString() + second_.number.ToString() + third_.number.ToString() + forth_.number.ToString();

        if (qu == answer)
        {
            Debug.Log("정답");
        }
        else
            Debug.Log("때앵");
    }
}
