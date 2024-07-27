using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class objcetSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject prefab;
    public float spawnRange = 10f; // 스폰 위치 기준 생성 범
    private int spawnCount = 0; // 현재 생성된 객체 수
    private int maxSpawnCount = 10; // 최대 생성할 객체 수

    private void Awake()
    {
        InvokeRepeating("SpawnMob", 0.4f, 0.3f); // 2초 후에 시작해서 5초마다 몹 생성
    }

    void SpawnMob()
    {
        if (spawnCount >= maxSpawnCount)
        {
            CancelInvoke("SpawnMob"); // 최대 생성 수에 도달하면 반복 호출 취소
            return;
        }

        // 스폰 위치 기준 랜덤한 위치 계산
        Vector3 spawnPosition = new Vector3(
            UnityEngine.Random.Range(transform.position.x - spawnRange, transform.position.x + spawnRange),
            transform.position.y,
            UnityEngine.Random.Range(transform.position.z - spawnRange, transform.position.z + spawnRange)
        );

        // 랜덤한 위치에 몹 생성
        Quaternion rotation = Quaternion.Euler(0, 0, 45);
        GameObject clone = Instantiate(prefab, spawnPosition, rotation);
        clone.name = "clone";
        clone.GetComponent<SpriteRenderer>().color = Color.red;

        spawnCount++; // 생성된 객체 수 증가
    }
}
