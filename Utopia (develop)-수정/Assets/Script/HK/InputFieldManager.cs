using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{

    InputField field;
    int stage = 0;

    // Use this for initialization
    void Start()
    {

        GameObject inputObj = GameObject.Find("InputField");

        field = inputObj.GetComponent<InputField>();

<<<<<<< HEAD
// HEAD:Utopia (develop)-수정/Assets/Script/HK/InputField.cs
        /*
=======
        

>>>>>>> 8b6e4ae0c7cc56f4b8d7f454082354e72f2f123d
        field.onValidateInput += delegate (string text, int charIndex, char addedChar)
        { 
            return changeUpperCase(addedChar);
        };
        
    }

    // Update is called once per frame
    void Update()
    {
        // 이건 스위치문으로 패스워드를 가려내면 될듯!
        /*
        if (field.text == "003")
        {
            Debug.Log("성공");
        }
        */
        textCode(field.text);
    }

    char changeUpperCase(char _cha)
    {
        char tmpChar = _cha;

        string tmpString = tmpChar.ToString();

        tmpString = tmpString.ToUpper();

        tmpChar = System.Convert.ToChar(tmpString);

        return tmpChar;
    }

    void textCode(string text)
    {
        switch (text)
        {
            case "003":
                stage = 1;
                Debug.Log("성공");
                break;
            default:
                break;
        }
    }

    public void StageChange()
    {
        switch (stage)
        {
            case 1:
                // 다른 것은 모두 닫고
                // 스테이지 1만 보여준다!
                break;
            default:
                break;
        }
    }
}
