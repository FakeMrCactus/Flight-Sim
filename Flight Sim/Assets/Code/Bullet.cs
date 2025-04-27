using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpe = 70f;
    public Rigidbody bulletRigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletRigidbody.linearVelocity = (Vector3.forward * bulletSpe);
        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
