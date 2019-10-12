using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using Vector4 = UnityEngine.Vector4;

public class PlayerMovement : MonoBehaviour {
    public Camera playerCamera;
    public Transform turret;

    public float acceleration = 5f;
    public float rotationSpeed = 30f;
    public double turretRotationSpeed = 15f;
    
    private Transform body;

    private float velocity;
    private float rotationVelocity;
    private double newRotation;
    private Quaternion completedRotation;

    private void Start() {
        body = GetComponent<Transform>();
    }
    
    private void Update() {
        velocity = Input.GetAxis("Vertical") * acceleration;
        rotationVelocity = Input.GetAxis("Horizontal") * rotationSpeed;
        
        if (velocity >= 0f)
            rotationVelocity *= -1;

        Vector3 convertedMousePosition = playerCamera.ScreenToWorldPoint(Input.mousePosition);

        newRotation = Mathf.Rad2Deg * Math.Atan2(
            convertedMousePosition.y - turret.position.y,
            convertedMousePosition.x - turret.position.x);

        completedRotation = Quaternion.Euler(0f, 0f, (float)newRotation);
    }

    private void FixedUpdate() {
        body.Translate(-Vector3.left * (velocity * Time.fixedDeltaTime));
        body.Rotate(0f, 0f, rotationVelocity * Time.fixedDeltaTime);
        
        turret.rotation = Quaternion.RotateTowards(turret.rotation, completedRotation,
            (float)turretRotationSpeed * Time.fixedDeltaTime);

        Vector2 position = body.position;
        playerCamera.transform.position = new Vector3(position.x, position.y, -10);
    }
}
