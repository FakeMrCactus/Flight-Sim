using UnityEngine;

public class Target : MonoBehaviour
{
    public bool hittablePlayer = false;
    public bool hittableEnemy = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (gameObject.tag == "Enemy")
        {
            hittableEnemy = true;
        } 
        if (gameObject.tag == "Player")
        {
            hittablePlayer = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hittableEnemy == true)
        {

        }
    }
}
