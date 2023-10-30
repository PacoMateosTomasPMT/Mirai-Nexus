using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseSkill : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CharacterController ctrl;
    [SerializeField] Transform cmDir;
    [SerializeField] bool canImpulse;

    [Header("Numbers")]
    [SerializeField] float impulseStrength;
    [SerializeField] float impulseTime;
    [SerializeField] float impulseCountdown;
    private void Start()
    {
        canImpulse = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canImpulse == true)
        {
            ImpulseStart();

            canImpulse = false;

            impulseCountdown = impulseTime;
        }

        if (impulseCountdown >= 0)
        {
            impulseCountdown -= Time.deltaTime;

            if (impulseCountdown <= 0)
            {
                canImpulse = true;
            }
        }
    }
    void ImpulseStart()
    {
        Vector3 move = cmDir.TransformDirection(Vector3.forward);

        ctrl.Move(-move * Time.deltaTime * 100 * impulseStrength);
    }
}
