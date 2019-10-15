using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {
    public Transform shootPlace;
    public Rigidbody2D bulletPrefab;
    public ParticleSystem shootFogPrefab;
    public Text reloadText;

    public float reloadTime = 2f;

    private Rigidbody2D body;
    private float currentReloadTime;

    private void Start() {
        body = GetComponent<Rigidbody2D>();
    }
    
    private void Update() {
        if (currentReloadTime < reloadTime)
            currentReloadTime += Time.deltaTime;

        if (currentReloadTime > reloadTime)
            currentReloadTime = reloadTime;

        //TODO: Temporary way, change it soon
        reloadText.text = "Reload: " + currentReloadTime.ToString("0.00") + "/" + reloadTime + " sec";
        
        if (Input.GetButtonDown("Fire1") && currentReloadTime >= reloadTime) {
            Shoot();
        }
    }
    
    private void Shoot() {
        currentReloadTime = 0f;
        
        Rigidbody2D bullet = Instantiate(bulletPrefab, shootPlace.position, shootPlace.rotation);
        bullet.AddRelativeForce(-Vector2.left * 30f, ForceMode2D.Impulse);
        bullet.GetComponent<Bullet>().shooter = transform;
        
        body.AddRelativeForce(Vector2.left * 3f, ForceMode2D.Impulse);

        Instantiate(shootFogPrefab, shootPlace.position, shootPlace.rotation);
    }
}
