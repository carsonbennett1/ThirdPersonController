using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody capsuleRigidbody;
    [SerializeField] private float speed = 2f;

    void Start()
    {
        
    }


    void Update()
    {

        Vector2 inputVector = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            inputVector += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector += Vector2.right;
        }

        Vector3 inputXYZPlane = new(inputVector.x, 0, inputVector.y);
        capsuleRigidbody.AddForce(inputXYZPlane * speed);

    }
}
