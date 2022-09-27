using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    GameObject barrel, projectile;

    GameObject[] projectilePool;
    int index = 0;

    float timeStamp, rateOfFire, mouseY, rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rateOfFire = 0.25f;
        timeStamp = -0.1f;
        rotationSpeed = 100;

        projectilePool = new GameObject[20];
        for (int i = 0; i < projectilePool.Length; i++)
        {
            projectilePool[i] = Instantiate(projectile, Vector3.zero, Quaternion.identity);
            projectilePool[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        mouseY = Input.GetAxis("Mouse Y");
        if (Input.GetKey(KeyCode.Space) && Time.time > timeStamp + rateOfFire)
        {
            projectilePool[index].SetActive(true);
            projectilePool[index].transform.position = barrel.transform.position;
            projectilePool[index].GetComponent<Rigidbody>().velocity = transform.up * 25;
            index++;
            if (index >= projectilePool.Length)
            {
                index = 0;
            }
            timeStamp = Time.time;
        }
        transform.Rotate(Vector3.right * -mouseY * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
