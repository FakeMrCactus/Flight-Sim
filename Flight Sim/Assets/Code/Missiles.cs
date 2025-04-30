using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Missiles : MonoBehaviour
{
    public GameObject[] targets;

    private Rigidbody rb;

    public Vector3 target = new Vector3(0, 100, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        targets = GameObject.FindGameObjectsWithTag("Enemy");

            //the missile knows where it is because it knows where it isnt
        rb = GetComponent<Rigidbody>();

        for (int i = 0; i < targets.Length; i++)
        {
            for (int j = i; j < targets.Length; j++)
            {
                if (Vector3.Distance(transform.position, targets[i].transform.position) > Vector3.Distance(transform.position, targets[j].transform.position))
                {
                    GameObject tempVal = targets[i];
                    targets[i] = targets[j];
                    targets[j] = tempVal;
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targets[0].transform);

        rb.AddForce(transform.forward);
       StartCoroutine(selfDestroy());
    }

    IEnumerator selfDestroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
