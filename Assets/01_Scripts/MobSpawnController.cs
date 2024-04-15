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
        // ���ο� ���� ������ ��ġ�� �����մϴ�
        Instantiate(mobPrefab, transform.position + positionVariation, Quaternion.identity);
    }

















    // �̻�� ���� ---------------------------------------------------------------------------

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
