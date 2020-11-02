using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTarget : MonoBehaviour {
    public float maxSpeedValue = 10.0f;
    public float startVolume = 1.0f;
    public AudioSource audioSource;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float clampedVolumeValue = startVolume - Mathf.Clamp01((maxSpeedValue - rb.velocity.sqrMagnitude) / maxSpeedValue);
        audioSource.volume = clampedVolumeValue;
        audioSource.Play();
    }
}
