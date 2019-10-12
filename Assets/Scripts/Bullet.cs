using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Bullet : MonoBehaviour {
    public Transform shooter;
    
    private void Update() {
        if (Vector2.Distance(shooter.position, transform.position) > 30)
            Destroy(gameObject);
        
        Debug.Log(Vector2.Distance(shooter.position, transform.position));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
        
        //TODO: Play explosion and take damage
    }
}
