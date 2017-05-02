using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour {

    public float radius = 10.0f;
    public float angle = 45.0f;

    public Material material;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * radius * Mathf.Cos(angle * Mathf.Deg2Rad) + transform.right * radius * Mathf.Sin(angle * Mathf.Deg2Rad));
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * radius * Mathf.Cos(angle * Mathf.Deg2Rad) - transform.right * radius * Mathf.Sin(angle * Mathf.Deg2Rad));

    }

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        bool detected = false;
        foreach (Collider c in colliders)
        {
            if (c.gameObject != gameObject)
            {
                detected = Vector3.Angle(transform.forward, c.transform.position - transform.position) < angle;
                if (detected)
                {
                    break;
                }
            }
        }


        if (detected)
        {
            material.color = Color.red;
        }
        else
        {
            material.color = Color.green;
        }
        foreach (Collider c in colliders)
        {
            c.SendMessage("TakeDamage", 10, SendMessageOptions.DontRequireReceiver);
        }
    }
}
