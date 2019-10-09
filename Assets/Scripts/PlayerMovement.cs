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
    public Transform turret;
    public float acceleration = 5f;
    public float rotationSpeed = 30f;
    public double turretRotationSpeed = 15f;
    
    private Transform body;

    private float velocity;
    private float rotationVelocity;
    private double newRotation;
    private int direction;

    private void Start() {
        body = GetComponent<Transform>();
    }
    
    private void Update() {
        velocity = Input.GetAxis("Vertical") * acceleration;
        rotationVelocity = Input.GetAxis("Horizontal") * rotationSpeed;

        if (velocity >= 0f)
            rotationVelocity *= -1;

        Vector3 convertedMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        newRotation = Mathf.Rad2Deg * Math.Atan2(
            convertedMousePosition.y - turret.position.y,
            convertedMousePosition.x - turret.position.x);
        
        //if (turret.eulerAngles.z - currentRotation < 180 && turret.eulerAngles.z - currentRotation > -180)
        if (newRotation < 0)
            direction = -1;

        else direction = 1;
    }

    private void FixedUpdate() {
        body.Translate(Vector3.up * (velocity * Time.fixedDeltaTime));
        body.Rotate(0f, 0f, rotationVelocity * Time.fixedDeltaTime);
        
        if ((int) turret.eulerAngles.z != (int) newRotation) {
            turret.Rotate(new Vector3(0f, 0f, (float) turretRotationSpeed * direction * Time.fixedDeltaTime));
        }

        Vector2 position = body.position;
        camera.position = new Vector3(position.x, position.y, -10);
    }
}
