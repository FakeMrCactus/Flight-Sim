using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject waow;
    public GameObject target;
    public float curHealth;
    public GameObject fullModel;
    public float bulletCD;
    public float bulletTime;
    public GameObject bulletPrefab;
    public Transform bulletCreate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.Find("Player");
        curHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        transform.RotateAround(waow.transform.position, Vector3.up, 20 * Time.deltaTime);

        if (curHealth <= 0)
        {
            Destroy(fullModel);
        }

        //code for at få skud til at skyde
        bulletTime += Time.deltaTime;
            if (bulletTime > bulletCD)
            {
                EvilShoot();
                bulletTime = 0;
            }

    }

    void EvilShoot()
    {
            Instantiate(bulletPrefab, bulletCreate.transform.position, transform.rotation);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            curHealth = curHealth - 20f;
        }

        if (col.gameObject.tag == "Missile")
        {
            curHealth = curHealth - 50f;
        }
    }
}
