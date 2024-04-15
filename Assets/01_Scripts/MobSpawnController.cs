using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MobSpawnController : MonoBehaviour
{
    [SerializeField]
    private GameObject mobPrefab;

    private void SpawnNewMob(Vector3 positionVariation)
    {
        // 새로운 몹을 지정된 위치에 생성합니다
        Instantiate(mobPrefab, transform.position + positionVariation, Quaternion.identity);
    }

















    // 미사용 영역 ---------------------------------------------------------------------------

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        Vector3 positionVariation = new Vector3();

        while (true)
        {
            positionVariation.x = Random.Range(-8f, 8f);
            positionVariation.z = Random.Range(-3f, 3f);

            SpawnNewMob(positionVariation);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
