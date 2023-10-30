using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSkill : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform tr;
    [SerializeField] GameObject platform;
    [SerializeField] bool canPlatform;
    [SerializeField] Material previewMaterial;
    float platTimer;
    GameObject platformClone;
    [Header("Numbers")]
    [SerializeField] float platformRecovery;
    [Header("Preview")]
    [SerializeField] GameObject platformPreview;
    private void Start()
    {
        canPlatform = true;
    }
    private void Update()
    {
        //---- SpawnPlatform

        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Mouse0) && canPlatform == true)
        {
            if(Physics.Raycast(tr.position, tr.TransformDirection(Vector3.forward), out hit, 10))
            {
                platformClone = Instantiate(platform, hit.point, platform.transform.rotation);
            }
            else
            {
                platformClone = Instantiate(platform, tr.position + transform.forward * 10, platform.transform.rotation);
            }

            canPlatform = false;
        }

        //---- Platform Used
        if (canPlatform == false)
        {
            platTimer += Time.deltaTime;

            if (platTimer >= platformRecovery)
            {
                canPlatform = true;

                Destroy(platformClone);

                platTimer = 0;
            }
        }

        if(canPlatform == true)
        {
            previewMaterial.color = Color.green;
        }
        else if (canPlatform == false)
        {
            previewMaterial.color = Color.red;
        }

        if (Physics.Raycast(tr.position, tr.TransformDirection(Vector3.forward), out hit, 10))
        {
            platformPreview.transform.position = hit.point;
            platformPreview.transform.rotation = platform.transform.rotation;
        }
        else
        {
            platformPreview.transform.position = tr.position + transform.forward * 10;
            platformPreview.transform.rotation = platform.transform.rotation;
        }
    }
}
