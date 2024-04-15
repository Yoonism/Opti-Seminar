using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{

    private void Update()
    {
        // 카메라가 있는 곳까지 이동합니다
        Vector3 TargetPosition = Camera.main.GetComponent<Transform>().position;
        ExtractVectorZ(ref TargetPosition);

        TargetPosition.x = transform.position.x;
        TargetPosition.y = 2.5f;
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, movementSpeed * Time.deltaTime);

        // 머리가 카메라를 바라보도록 합니다
        transform.Find("MobHead").LookAt(Camera.main.GetComponent<Transform>().position);
    }

    private void MobHit()
    {
        Destroy(gameObject);
    }

















    // 미사용 영역 ---------------------------------------------------------------------------

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
