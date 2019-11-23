using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float speed;

    Rigidbody rb;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        float ver = Input.GetAxis("Vertical") * -speed;
        float hor = Input.GetAxis("Horizontal") * speed;
        Vector3 mov = new Vector3(ver, 0, hor) * Time.deltaTime;
        Vector3 newPos = transform.position + mov;
        rb.MovePosition(newPos);

        Transform tank = transform.GetChild(0).GetComponent<Transform>();
        if (mov.magnitude > 0)
            tank.rotation = Quaternion.LookRotation(mov, Vector3.up);
    }

}