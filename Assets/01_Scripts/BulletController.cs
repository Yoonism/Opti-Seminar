using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void Update()
    {
        // 매 프레임마다 총알을 앞으로 움직입니다
        transform.Translate(Vector3.up * Time.deltaTime * 500f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 총알이 다른 물체에 닿을 경우 총알 파괴를 요청합니다
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        // 총알을 파괴합니다
        Destroy(gameObject);
    }




















    // 미사용 영역 ---------------------------------------------------------------------------

    private void OnEnable()
    {
        StartCoroutine(Lifetime());
    }

    private void OnDisable()
    {
        StopAllCoroutines();    
    }

    private IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(5f);

        DestroyBullet();
    }

}
