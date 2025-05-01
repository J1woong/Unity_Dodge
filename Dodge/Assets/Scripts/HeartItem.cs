using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : MonoBehaviour
{
    public float rotationSpeed = 90f; // 초당 회전 속도 (도 단위)
    public float lifeTime = 3f;       // 생성 후 유지 시간

    void Start()
    {
        // 5초 뒤 오브젝트 파괴
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Y축 중심 회전 (빙글빙글)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal();
                Destroy(gameObject); // 아이템 사라짐
            }
        }
    }
}

