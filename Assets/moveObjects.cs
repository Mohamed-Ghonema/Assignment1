using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class moveObjects : MonoBehaviour
{
    [SerializeField] public float pushForce = 1;


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        Rigidbody rb = hit.collider.attachedRigidbody;



        if (rb != null && hit.gameObject.tag == "moveable")
        {

            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rb.AddForceAtPosition(forceDirection * pushForce, transform.position, ForceMode.Impulse);

        }

    }
}
