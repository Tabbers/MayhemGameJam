using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : MonoBehaviour
{

    void Update()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Clamp(Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg, 15, 170);
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
}
