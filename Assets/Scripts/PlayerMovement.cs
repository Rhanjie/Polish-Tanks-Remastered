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
    public float acceleration = 5f;
    public float rotationSpeed = 30f;
    
    private Transform transform;

    private float velocity;
    private float rotationVelocity;

    private void Start() {
        transform = GetComponent<Transform>();
    }
    
    private void Update() {
        velocity = Input.GetAxis("Vertical") * acceleration;
        
        rotationVelocity = Input.GetAxis("Horizontal") * rotationSpeed;
        
        if (velocity >= 0f)
            rotationVelocity *= -1;
    }

    private void FixedUpdate() {
        transform.Translate(Vector3.up * (velocity * Time.fixedDeltaTime));
        transform.Rotate(0f, 0f, rotationVelocity * Time.fixedDeltaTime);
        
        camera.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
