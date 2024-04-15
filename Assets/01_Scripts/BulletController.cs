using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Lifetime());
    }
    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 500f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(5f);

        Destroy(gameObject);
    }
}
