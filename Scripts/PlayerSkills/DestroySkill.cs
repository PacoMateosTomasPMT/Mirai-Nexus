using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySkill : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform playerDirection;
    [Header("Numbers")]
    [SerializeField] private bool canDestroy;
    [SerializeField] private float destroyCounter;
    [SerializeField] private float destroyTimeLim;
    private void Start()
    {
        canDestroy = true;
    }
    private void Update()
    {
        //---- Ray to destroy ----

        if (Input.GetKeyDown(KeyCode.Mouse0) && canDestroy == true)
        {
            RaycastHit hit;

            if (Physics.Raycast(playerDirection.position, playerDirection.TransformDirection(Vector3.forward), out hit))
            {
                if (hit.collider.tag == "Destroyable")
                {
                    Destroy(hit.collider.gameObject);
                }
            }

            canDestroy = false;
        }

        if (canDestroy == false)
        {
            destroyCounter += Time.deltaTime;

            if (destroyCounter >= destroyTimeLim)
            {
                destroyCounter = 0;

                canDestroy = true;
            }
        }
    }
}
