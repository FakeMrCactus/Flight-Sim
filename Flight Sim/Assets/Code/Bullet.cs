using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpe = 100f;
    public Rigidbody bulletRigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletRigidbody.linearVelocity = (transform.forward * bulletSpe);
        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

}
