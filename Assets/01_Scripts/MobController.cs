using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{

    private void Update()
    {
        // 새로운 Vector3 변수를 만들고 카메라의 위치를 대입합니다
        Vector3 TargetPosition = new Vector3();
        TargetPosition = Camera.main.GetComponent<Transform>().position;

        // 몹들이 한 곳으로 몰리지 않도록 z 값만 추출합니다
        ExtractZFromVector(ref TargetPosition);

        // 카메라 위치로 이동합니다
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, movementSpeed * Time.deltaTime);

        // 머리가 카메라를 바라보도록 합니다
        transform.Find("MobHead").LookAt(Camera.main.GetComponent<Transform>().position);
    }

    private void HitByBullet()
    {
        // 총알에 맞았을 경우 몹을 제거합니다
        Destroy(gameObject);
    }




















    // 미사용 영역 ---------------------------------------------------------------------------

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
