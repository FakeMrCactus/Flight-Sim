using UnityEngine;

public class Missiles : MonoBehaviour
{
    public GameObject target;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        target = GameObject.Find("TGT");

            //the missile knows where it is because it knows where it isnt
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);

        rb.AddForce(transform.forward);
    }
}
