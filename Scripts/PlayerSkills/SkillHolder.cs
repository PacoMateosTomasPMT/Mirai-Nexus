using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillHolder : MonoBehaviour
{
    public int selectedSkill = 0;
    private void Start()
    {
        SelectSkill();
    }
    private void Update()
    {
        int previousSelectedBullet = selectedSkill;

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedSkill >= transform.childCount - 1)
            {
                selectedSkill = 0;
            }
            else
            {
                selectedSkill++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedSkill <= 0)
            {
                selectedSkill = transform.childCount - 1;
            }
            else
            {
                selectedSkill--;
            }
        }

        if (previousSelectedBullet != selectedSkill)
        {
            SelectSkill();
        }
    }
    void SelectSkill()
    {
        int i = 0;
        foreach (Transform skill in transform)
        {
            if (i == selectedSkill)
            {
                skill.gameObject.SetActive(true);
            }
            else
            {
                skill.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
