using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void Update()
    {
        // �� �����Ӹ��� �Ѿ��� ������ �����Դϴ�
        transform.Translate(Vector3.up * Time.deltaTime * 500f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �Ѿ��� �ٸ� ��ü�� ���� ��� �Ѿ� �ı��� ��û�մϴ�
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        // �Ѿ��� �ı��մϴ�
        Destroy(gameObject);
    }




















    // �̻�� ���� ---------------------------------------------------------------------------

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
