using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public Transform shootPlace;
    public Rigidbody2D bulletPrefab;
    public ParticleSystem shootFogPrefab;

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }
    
    private void Shoot() {
        Rigidbody2D bullet = Instantiate(bulletPrefab, shootPlace.position, shootPlace.rotation);
        bullet.AddRelativeForce(-Vector2.left * 30f, ForceMode2D.Impulse);
        bullet.GetComponent<Bullet>().shooter = transform;

        Instantiate(shootFogPrefab, shootPlace.position, shootPlace.rotation);
    }
}
