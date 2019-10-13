using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class Bullet : MonoBehaviour {
    public Transform shooter;
    public Transform explosion;
    
    private void Update() {
        if (Vector2.Distance(shooter.position, transform.position) > 30)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);

        Instantiate(explosion, transform.position, Quaternion.identity);

        //TODO: Take damage
    }
}
