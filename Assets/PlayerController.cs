using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float vInput, hInput, mouseX, mouseY, rotationSpeed = 100, movementSpeed = 10;
    GameObject gun;
    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.Find("Gun");
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        transform.Translate(Vector3.forward * vInput * movementSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * hInput * movementSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * mouseX * rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
