using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    // 슬라이더 UI와 연결
    public Slider soundSlider;

    void Start()
    {
        // 시작할 때 슬라이더의 값에 맞춰 볼륨을 설정
        soundSlider.value = AudioListener.volume;

        // 슬라이더 값 변경 시 볼륨 조정
        soundSlider.onValueChanged.AddListener(SetVolume);
    }

    // 슬라이더 값에 따라 볼륨을 설정하는 함수
    void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}