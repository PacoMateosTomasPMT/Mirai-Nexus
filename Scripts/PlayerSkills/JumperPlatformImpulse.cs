using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperPlatformImpulse : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 dir = collision.contacts[0].point - transform.position;

            dir = -dir.normalized;

            collision.gameObject.GetComponent<CharacterController>().Move(Vector3.forward * 100 * Time.deltaTime);
        }
    }
}
