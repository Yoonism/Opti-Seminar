using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{

    private void Update()
    {
        // ī�޶� �ִ� ������ �̵��մϴ�
        Vector3 TargetPosition = Camera.main.GetComponent<Transform>().position;
        ExtractVectorZ(ref TargetPosition);

        TargetPosition.x = transform.position.x;
        TargetPosition.y = 2.5f;
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, movementSpeed * Time.deltaTime);

        // �Ӹ��� ī�޶� �ٶ󺸵��� �մϴ�
        transform.Find("MobHead").LookAt(Camera.main.GetComponent<Transform>().position);
    }

    private void MobHit()
    {
        Destroy(gameObject);
    }

















    // �̻�� ���� ---------------------------------------------------------------------------

    private float movementSpeed = 12f;

    private void OnCollisionEnter(Collision collision)
    {
        MobHit();
    }

    private void ExtractVectorZ(ref Vector3 input)
    {
        input.x = transform.position.x;
        input.y = 2.5f;
    }
}
