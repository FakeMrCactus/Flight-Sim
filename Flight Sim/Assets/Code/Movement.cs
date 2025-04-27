using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Movement : MonoBehaviour
{
    [SerializeField]
    public float rotationSpeed;
    [SerializeField]
    private float curSpeed = 10.0f;
    [SerializeField]
    private float curHealth;
    public float acceleration = 1.0f;
    public float maxSpeed = 60.0f;
    public float minSpeed = 0.0f;
    Collider PlaneBody;
    private bool gunFire = false;
    public Rigidbody bullet;
    public float bulletSpe = 19f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlaneBody = GetComponent<BoxCollider>();
        curHealth = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        //Code for rotating plane while holding down keys
        if (Input.GetKey(KeyCode.S))
        {
            rotationSpeed = -MathF.Abs(rotationSpeed);
            transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);

        }

        if (Input.GetKey(KeyCode.W)) 
        {
            rotationSpeed = +MathF.Abs(rotationSpeed);
            transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);

        }

        if (Input.GetKey(KeyCode.A))
        {
            rotationSpeed = +MathF.Abs(rotationSpeed);
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotationSpeed = -MathF.Abs(rotationSpeed);
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rotationSpeed = -MathF.Abs(rotationSpeed);
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotationSpeed = +MathF.Abs(rotationSpeed);
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
 
        //Speed controller, including max and min speed to avoid flying infinitely fast or at negative speed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            curSpeed += acceleration * Time.deltaTime;

            if (curSpeed > maxSpeed)
                curSpeed = maxSpeed;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            curSpeed -= acceleration * Time.deltaTime;
            if (curSpeed < minSpeed)
                curSpeed = minSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gunFire = true;
        }

        transform.Translate(Vector3.forward * curSpeed * Time.deltaTime);

        if (curHealth <= 0)
        {
            Destroy(PlaneBody);
            curSpeed = 0;
            StartCoroutine(Death());
        }
       
    }
    //Checker for om flyet rammer jorden,midste liv hvis det sker
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            curHealth = curHealth - 100f;
        }

        if (col.gameObject.tag == "Bullet")
        {
            curHealth = curHealth - 20f;
        }

    }
    
    void GunsGunsGuns()
    {
        if(gunFire==true)
        {
            Rigidbody instantiatedProjectile = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.linearVelocity = transform.TransformDirection(new Vector3(0, 0, bulletSpe));
        }

    } 

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Game Over");
    }
}
