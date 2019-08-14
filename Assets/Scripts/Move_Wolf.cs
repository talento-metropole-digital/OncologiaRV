using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Move_Wolf : MonoBehaviour
{
    //float gravity = 10;
    public float changeMove = 10.0f;
    public float jump_factor = 30;
    public float rotateMove = 90.0f;
    public Rigidbody rgd;
    public bool isGrounded;
    public GameObject wolf;
    public float jump_aux;

    // Start is called before the first frame update
    void Start()
    {
        rgd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyCode key = KeyCode.Space;
        KeyCode key1 = KeyCode.UpArrow;
        KeyCode key2 = KeyCode.DownArrow;
        KeyCode key3 = KeyCode.LeftArrow;
        KeyCode key4 = KeyCode.RightArrow;
        bool jump = Input.GetKey(key), up = Input.GetKey(key1),
                down = Input.GetKey(key2), left = Input.GetKey(key3),
                right = Input.GetKey(key4);
        if (rgd.detectCollisions == true)
        {
            if (jump)
            {
                Jump();
            }

        }
        if (up)
        {
            Wolf_walk(changeMove, 0f);
        }
        if (down)
        {
            Wolf_walk(-changeMove, 0f);
        }
        if (left)
        {
            Wolf_walk(0f, -rotateMove);
        }
        if (right)
        {
            Wolf_walk(0f, rotateMove);
        }
        
    }
    void Jump() {
        jump_aux = jump_factor;
        transform.Translate(new Vector3(0, jump_aux, 0) * Time.deltaTime);
        while (isGrounded == false)
        {
            transform.Translate(new Vector3(0, jump_aux, 0) * Time.deltaTime);
            jump_aux -= jump_factor / 20;
        }
    }
    void Wolf_walk(float x1, float x2) {
        if (x1 != 0.0f) {
            Walk(x1);
        }
        if (x2 != 0.0f)
        {
            Round(x2);
        }

    }
    void Walk(float x1) { transform.Translate(Vector3.forward * x1 * Time.deltaTime); }
    void Round(float x2) { transform.Rotate(Vector3.up, x2 * Time.deltaTime); }
    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
