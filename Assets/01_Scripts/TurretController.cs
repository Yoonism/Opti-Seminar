using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    private void FireTurret()
    {
        // 총알을 터렛 위치에 생성합니다
        Instantiate(_bulletPrefab, transform.position, transform.localRotation);
    }

















    // 미사용 영역 ---------------------------------------------------------------------------

    [SerializeField]
    private float turretFireDelay = 0.3f;
    [SerializeField]
    private GameObject _bulletPrefab;
    private Quaternion _baseQuaternion;

    private void Start()
    {
        _baseQuaternion = transform.localRotation;
        StartCoroutine(CalculateTurret());
    }

    private IEnumerator CalculateTurret()
    {
        yield return new WaitForSeconds(Random.Range(0.01f, 0.2f));
        float[] rotationVariation = { -0.03f, 0.03f };

        while(true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                transform.localRotation = new Quaternion(_baseQuaternion.x + Random.Range(rotationVariation[0], rotationVariation[1]), _baseQuaternion.y
                + Random.Range(rotationVariation[0], rotationVariation[1]), _baseQuaternion.z + Random.Range(rotationVariation[0], rotationVariation[1]), _baseQuaternion.w + Random.Range(rotationVariation[0], rotationVariation[1]));

                FireTurret();
            }

            yield return new WaitForSeconds(turretFireDelay);
        }
    }
}
