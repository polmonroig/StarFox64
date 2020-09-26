using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

    private AudioSource soundSource;

    [SerializeField] private AudioClip hitSound;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float healthValue;
    private static bool _animating;

    private void Start()
    {
        _animating = false;
        soundSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health != null) {
            health.reduce(healthValue);
            if(!_animating)
                StartCoroutine(Animate());
        }
    }

    private IEnumerator Animate()
    {
        _animating = true;
        GameObject explosion = null; 
        if(explosionPrefab != null)
            explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        if(soundSource != null && hitSound != null)
            soundSource.PlayOneShot(hitSound);
        Destroy(explosion, 1);
        yield return new WaitForSeconds(2);
        _animating = false;
    }

}
