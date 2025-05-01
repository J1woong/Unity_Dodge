using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    public GameObject heartPrefab;
    public float spawnInterval = 5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnHeart), 1f, spawnInterval);
    }

    void SpawnHeart()
    {
        Vector3 randomPos = GetRandomPosition();
        Instantiate(heartPrefab, randomPos, Quaternion.identity);
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(-9.5f, 9.5f); // Plane 중심 기준
        float z = Random.Range(-9.5f, 9.5f);
        float y = 0.5f; // 바닥 위 약간 띄움

        return new Vector3(x, y, z);
    }


    // 시각화용
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.up * 0.5f, new Vector3(1f, 0.1f, 1f)); // 내부 범위
    }
}

