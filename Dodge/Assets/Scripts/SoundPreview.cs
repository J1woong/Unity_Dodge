using UnityEngine;
using UnityEngine.UI;

public class SoundPreview : MonoBehaviour
{
    public AudioSource audioSource;  // 오디오 소스
    public Button playButton;        // 재생 버튼
    public Button pauseButton;       // 일시 정지 버튼

    private bool isPlaying = false;  // 재생 상태 추적

    void Start()
    {
        // 시작 시 오디오를 재생하지 않도록 설정 (Play On Awake 비활성화)
        audioSource.playOnAwake = false;

        // 버튼 클릭 시 각각의 메서드 실행
        playButton.onClick.AddListener(PlaySound);
        pauseButton.onClick.AddListener(PauseSound);
    }

    void PlaySound()
    {
        if (!isPlaying)  // 이미 재생 중이지 않으면 재생
        {
            audioSource.Play();
            isPlaying = true;
        }
    }

    void PauseSound()
    {
        if (isPlaying)  // 재생 중이면 일시 정지
        {
            audioSource.Pause();
            isPlaying = false;
        }
    }
}