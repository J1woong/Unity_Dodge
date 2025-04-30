using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    public int currentLives;

    public GameObject hitEffectPrefab; // 피격 효과
    private HealthBarController healthBarController; // HealthBarController 참조

    IEnumerator Start()
    {
        currentLives = maxLives;

        // HealthBarController가 씬에 완전히 생성될 때까지 기다린다
        yield return new WaitUntil(() => FindObjectOfType<HealthBarController>() != null);

        healthBarController = FindObjectOfType<HealthBarController>();

        if (healthBarController != null)
        {
            healthBarController.UpdateHearts(); // 하트 초기화
        }
        else
        {
            Debug.LogError("HealthBarController를 찾을 수 없습니다! 씬에 있는지 확인하세요.");
        }
    }

    public void TakeHit()
    {
        // 피격 효과
        if (hitEffectPrefab != null)
        {
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
        }

        // 목숨 차감
        currentLives--;

        // 하트 UI 업데이트
        if (healthBarController != null)
        {
            healthBarController.UpdateHearts();
        }

        // 목숨이 0 이하이면 죽음 처리
        if (currentLives <= 0)
        {
            Die();
        }
        else
        {
            Debug.Log("Hit! Lives left: " + currentLives);
        }
    }

    void Die()
    {
        Debug.Log("Game Over!");

        // GameManager에 게임 종료 요청
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.EndGame();
        }

        // 죽었을 때 처리
        PlayerController playerController = GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.Die();
        }

        // 플레이어 오브젝트 비활성화
        gameObject.SetActive(false);

        // 마지막 하트까지 갱신
        if (healthBarController != null)
        {
            healthBarController.UpdateHearts();
        }
    }

    void UpdateLivesUI()
    {
        // (지금은 안 쓰고 있지만 나중에 텍스트로 목숨 표시할 때 쓰일 수도 있음)
    }
    
}