using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    // 하트 UI 오브젝트들을 참조
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;

    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();  // PlayerHealth 참조
        UpdateHearts();  // UI 초기 상태 갱신
    }

    // 하트 상태 갱신
    public void UpdateHearts()
    {
        // 플레이어 목숨에 맞게 하트 UI를 활성화/비활성화
        Heart1.SetActive(playerHealth.currentLives >= 1);
        Heart2.SetActive(playerHealth.currentLives >= 2);
        Heart3.SetActive(playerHealth.currentLives >= 3);
    }
}