using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using Vector4 = UnityEngine.Vector4;

public class PlayerMovement : MonoBehaviour {
    public Transform camera;
    public float acceleration = 40f;
    public float rotationSpeed = 20f;
    
    private Transform transform;
    private Rigidbody2D rigidbody;

    private float velocity;
    private float rotationVelocity;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }
    
    private void Update() {
        velocity = Input.GetAxis("Vertical") * acceleration;
        
        rotationVelocity = -Input.GetAxis("Horizontal");
    }

    private void FixedUpdate() {
        rigidbody.AddRelativeForce(Vector3.up * velocity);
        rigidbody.AddTorque(rotationVelocity * rotationSpeed);

        camera.position = new Vector3(transform.position.x, transform.position.y, -10);

        //rigidbody.rotation += rotationVelocity;
        //player.Translate(Vector3.up * (velocity * Time.deltaTime));
    }
}
