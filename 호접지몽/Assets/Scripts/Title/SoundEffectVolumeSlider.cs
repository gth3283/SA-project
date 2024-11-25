using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectVolumeSlider: MonoBehaviour
{
    public Slider volumeSlider; // 슬라이더 UI 요소 연결
    public AudioManager soundEffect; // 효과음 AudioSource 컴포넌트 연결

    void Start()
    {
        //soundEffect = FindObjectOfType<AudioManager>();
        //soundEffect.GetVolume();


        volumeSlider.interactable = true; // 슬라이더 활성화
        // 슬라이더 값 초기 설정
        volumeSlider.minValue = 0f;
        volumeSlider.maxValue = 100f;
        volumeSlider.value = soundEffect.GetVolume() * 100; // 현재 볼륨으로 슬라이더 초기화

        //볼륨값 세이브했다가 게임꺼도 저장되게 하는 파트.
        PlayerPrefs.SetFloat("SoundVolume", soundEffect.GetVolume());
        PlayerPrefs.Save();
        //여기까지 (현재 유니티엔진에서 게임 켜고끌때는 적용안되는듯함)

        // 슬라이더 값 변경 시 실행할 함수 등록
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    // 슬라이더 값 변경 시 호출되는 함수
    void OnVolumeChanged(float value)
    {
        soundEffect.SetVolume(value / 100f); // 슬라이더 값을 0~1 범위로 변환
    }
}
