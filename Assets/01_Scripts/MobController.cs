using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{

    private void Update()
    {
        // ���ο� Vector3 ������ ����� ī�޶��� ��ġ�� �����մϴ�
        Vector3 TargetPosition = new Vector3();
        TargetPosition = Camera.main.GetComponent<Transform>().position;

        // ������ �� ������ ������ �ʵ��� z ���� �����մϴ�
        ExtractZFromVector(ref TargetPosition);

        // ī�޶� ��ġ�� �̵��մϴ�
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, movementSpeed * Time.deltaTime);

        // �Ӹ��� ī�޶� �ٶ󺸵��� �մϴ�
        transform.Find("MobHead").LookAt(Camera.main.GetComponent<Transform>().position);
    }

    private void HitByBullet()
    {
        // �Ѿ˿� �¾��� ��� ���� �����մϴ�
        Destroy(gameObject);
    }




















    // �̻�� ���� ---------------------------------------------------------------------------

    private float movementSpeed = 12f;

    private void OnCollisionEnter(Collision collision)
    {
        HitByBullet();
    }

    private void ExtractZFromVector(ref Vector3 input)
    {
        input.x = transform.position.x;
        input.y = 2.5f;
    }
}
