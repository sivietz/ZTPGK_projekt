using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    CharacterController characterController;
    [SerializeField]
    private float speed = 10f;

    private float gravity = 9.81f;
    private float x = 0;
    private float y = 0;
    private float z = 0;

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y -= gravity * Time.deltaTime;
        z = Input.GetAxis("Vertical");

        var move = transform.right * x + transform.up * y + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }
}
