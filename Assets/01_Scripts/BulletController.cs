using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Lifetime());
    }
    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 500f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyBullet();
    }



    private void DestroyBullet()
    {
        PoolingManager.Instance.StandbyToPool(gameObject);
        //Destroy(gameObject);
    }



















    // 미사용 영역 ---------------------------------------------------------------------------
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
