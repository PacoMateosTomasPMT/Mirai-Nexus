using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookSkill : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform playerDirection, player;
    [SerializeField] private LayerMask hookable;
    [Header("Variables")]
    [SerializeField] private float hookDistance;

    private Vector3 grapplePoint;
    private SpringJoint joint;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartHook();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            EndHook();
        }
    }

    void StartHook()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerDirection.position, playerDirection.forward, out hit, hookDistance, hookable))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = 20f;
            joint.damper = 7f;
            joint.massScale = 4.5f;
        }
    }
    void EndHook()
    {
        Destroy(joint);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }
    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}
