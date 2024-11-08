using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KimsHouse_OpenBalance : MonoBehaviour
{
    //천칭 이미지 호출

    //상단 9개의 반지 이미지,버튼 호출
    //하단 버튼 3개 닫기, 비교, 호출
    //위의 호출은 캔버스 1개에 뭉쳐서(BalanceUICanvas)

    public void OpenBalance()
    {
        //캐릭터 못움직이게 하는 함수 사용

        //if문으로 지금까지 천칭 연 횟수 판정
        //천칭 이미지 보이게

        //대화문 출력으로 천칭 팁 출력
        //대화문 출력으로 천칭 남은 횟수 출력

        //버튼 들어있는 캔버스 보이게, 상호작용 허용

    }

    public void CloseBalance()
    {
        //캐릭터 움직일 수 있게 하는 함수 호출

        //천칭 이미지 안보이게
        //버튼 들어있는 캔버스 안보이게, 상호작용 금지

    }

}
