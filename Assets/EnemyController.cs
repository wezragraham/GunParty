using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject player;
    float forwardSpeed, sidewaysSpeed;
    int hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = 50;
        forwardSpeed = 5;
        sidewaysSpeed = 10;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.x >= player.transform.position.x + 5 || this.gameObject.transform.position.x <= player.transform.position.x -5)
        {
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime, Space.Self);
        }


        transform.LookAt(player.transform);

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Paintball")
        {
            hp--;
        }
    }
}
