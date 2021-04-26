using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private ParticleSystem hitPos;
    private Rigidbody rb;
    private AudioSource bulletAs;
    public AudioClip m_shootSound;
    public AudioClip m_hitSound;
    public float m_impulse = 10f;

    void Start()
    {
        hitPos = GetComponent<ParticleSystem>();
        if (hitPos == null)
            Debug.Log("Ande está el particle system de la bala");
        rb = GetComponent<Rigidbody>();
        if (hitPos ==null)
            Debug.Log("Ande está el particle system del rigidbody");
        bulletAs = GetComponent<AudioSource>();
        if (hitPos == null)
            Debug.Log("Ande está el AudioSourcec de la bala");
    }

    public void Shoot (Vector3 direction)
    {
        Start();
        bulletAs.PlayOneShot(m_shootSound);
        rb.AddForce(direction.normalized * m_impulse, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        hitPos.Play();
        bulletAs.PlayOneShot(m_hitSound);
    }
}
