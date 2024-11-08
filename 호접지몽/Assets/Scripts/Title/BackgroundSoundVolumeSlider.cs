using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSoundVolumeSlider : MonoBehaviour
{
    public Slider volumeSlider; // 슬라이더 UI 요소 연결
    public AudioSource BackgroundSound; // 효과음 AudioSource 컴포넌트 연결

    void Start()
    {
        volumeSlider.interactable = true; // 슬라이더 활성화
        // 슬라이더 값 초기 설정
        volumeSlider.minValue = 0f;
        volumeSlider.maxValue = 100f;
        volumeSlider.value = BackgroundSound.volume * 100; // 현재 볼륨으로 슬라이더 초기화

        // 슬라이더 값 변경 시 실행할 함수 등록
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    // 슬라이더 값 변경 시 호출되는 함수
    void OnVolumeChanged(float value)
    {
        BackgroundSound.volume = value / 100f; // 슬라이더 값을 0~1 범위로 변환
    }
}
