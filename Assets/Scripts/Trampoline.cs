using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField]
    private Rigidbody tree;
    [SerializeField]
    private float bounceForce = 10f;
    [SerializeField]
    private float torque = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        tree.AddForce(0, bounceForce, 0, ForceMode.Impulse);
        tree.AddTorque(0, torque, 0, ForceMode.Force);
    }
}
