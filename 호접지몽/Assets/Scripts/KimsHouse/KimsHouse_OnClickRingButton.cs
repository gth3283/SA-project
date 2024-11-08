using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KimsHouse_OnClickRingButton : MonoBehaviour
{
    //선택지 버튼 2개,닫기버튼 들어있는 캔버스 호출
    //각각의 버튼들도 호출

    //KimsHouse_RingMenu에서 선언한 반지의 선택여부 변수 호출


    public void OpenRingMenu() //상단 9개의 반지를 누르면 실행
    {
        //if문으로 선택된 반지인지 판정
        //캔버스 안의 버튼 위치를 반지에 맞게 이동,
        //캔버스 보이게 설정, 상호작용 가능하게 설정

    }

    public void CloseRingMenu() //닫기버튼 누르면 실행
    {
        //캔버스 안보이게 설정, 상호작용 불가능하게 설정
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
