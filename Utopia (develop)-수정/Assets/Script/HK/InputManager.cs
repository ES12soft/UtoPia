using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Video;


public class InputManager : MonoBehaviour
{
    private bool draggingItem = false;          // 드래그되었는지 유무
    private GameObject draggedObject;           // 드래그되고있는 객체의 참조를 보관,유지
    private Vector2 touchOffset;                // 잡고난 후 플레이어의 터치위치
    public GameObject Inventory;
 //   public AudioSource audioSource;

    bool Interaction = false; 

    void Update()
    {
        // 입력이 있다면, 이동
        if (HasInput)
        {
            DragOrPickUp();
        }

        // 입력이 없다면 객체 삭제
        else
        {
            if (draggingItem)
            {
                DropItem();
                RayCollision();
            }
        }

   //     if (!audioSource.isPlaying && Interaction)
     //       UnityEngine.SceneManagement.SceneManager.LoadScene("End");
    }


    // 감지된 마우스의 현재 입력 위치를 반환
    Vector2 CurrentTouchPosition
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }


    // 항목을 드래그하는 경우 입력과 함께 사용
    // 드래그가 되지 않으면 터치된 오브젝트를 선택
    private void DragOrPickUp()
    {
        var inputPosition = CurrentTouchPosition;

        // 객체가 이미 선택되어 있다면 해당 개체는 입력 위치로 이동
        if (draggingItem)
        {
            draggedObject.transform.position = inputPosition + touchOffset;
        }

        // 객체가 선택되지 않은 경우, Raycast를 사용하여 객체를 draggedObject 변수에 저장하고,
        // draggingItem 변수를 true로 설정하여 객체를 선택하는지 여부를 확인
        else
        {
            // Raycast를 이용해 마우스 아래 객체 충돌 감지
            RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);
            Transform CheckTag = Physics2D.Raycast(inputPosition, inputPosition, 0.5f).transform;

            if (touches.Length > 0)
            {
                var hit = touches[0];
                //audioSource = hit.transform.GetComponent<AudioSource>();


                if (hit.transform != null && CheckTag.tag == "Item")
                {
                    hit.transform.SetParent(Inventory.transform);
                    hit.transform.GetComponent<AudioSource>().Play();
                    draggingItem = true;
                    draggedObject = hit.transform.gameObject;
                    touchOffset = (Vector2)hit.transform.position - inputPosition;          // 처음위치에 상대적으로 움직임
                    draggedObject.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);     // 드래그 중일때 오브젝트 확대
                }
            }
        }
    }

    // 플레이어가 현재 마우스를 누를 때 true를 반환
    private bool HasInput
    {
        get
        {
            // 마우스 버튼이 눌려 있거나 적어도 하나의 터치가 화면에 있다면 true를 반환
            return Input.GetMouseButton(0);
        }
    }

    //public AudioSource Audio
    //{
    //    get
    //    {
    //        return audio;
    //    }

    //    set
    //    {
    //        audio = value;
    //    }
    //}


    // 가져온 항목을 해제
    void DropItem()
    {
        draggingItem = false;
        draggedObject.transform.localScale = new Vector3(1, 1, 1);         // 드래그가 끝났으니 원래대로 스케일 변경
    }

    void RayCollision()
    {

        RaycastHit2D[] touches = Physics2D.RaycastAll(CurrentTouchPosition, CurrentTouchPosition, 0.5f);
        Transform CheckTag = Physics2D.Raycast(CurrentTouchPosition, CurrentTouchPosition, 0.5f).transform;

        if (touches.Length > 1)
        {
            var obj = touches[0];
            var hit = touches[1];

            if (obj.transform.name == "0_GateCard" && hit.collider.tag == "Collision")
            {
                hit.transform.GetComponent<AudioSource>().Play();
                Debug.Log("오브젝트 접촉완료");

                Interaction = true;
                Destroy(obj.collider.gameObject);

                //if (hit.transform.GetComponent<AudioSource>().isPlaying)
                //    UnityEngine.SceneManagement.SceneManager.LoadScene("End");

                //while (hit.transform.GetComponent<AudioSource>().isPlaying)
                //{
                //    Debug.Log("비트에 몸을맡겨");
                //}

                //if (!hit.transform.GetComponent<AudioSource>().isPlaying)
                //Debug.Log("1" + hit.transform.GetComponent<AudioSource>().isPlaying.ToString());

            }

            if (hit.collider.tag == "Others")
                hit.transform.SetParent(Inventory.transform.Find("2_Grid"));

            //Debug.Log("2" + hit.transform.GetComponent<AudioSource>().isPlaying.ToString());
        }

        else if (touches.Length <= 1)
            touches[0].transform.SetParent(Inventory.transform.Find("2_Grid"));

        //Debug.Log("3" + touches[1].transform.GetComponent<AudioSource>().isPlaying.ToString());
    }
}
