using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Move_Wolf : MonoBehaviour
{
    float gravity = 10;
    public float changeMove = 10.0f;
    public float jump_factor = 6;
    public float rotateMove = 90.0f;
    public Rigidbody rgd;
    private bool isGrounded;
    public GameObject wolf;
    public MeshCollider mcl;
    public float jump_aux;
    //public Collider col;

    // Start is called before the first frame update
    void Start()
    {
        rgd = GetComponent<Rigidbody>();
        rgd.useGravity = true;
        //mcl = GetComponent<MeshCollider>();
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
        if (jump)
        {
            Console.WriteLine("Jump Sucess");
            Jump();
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
        rgd.AddForce(new Vector3(0, 20, 0), ForceMode.Impulse);
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
    void OnCollisionEnter(Collision hit)
    {
        isGrounded = true;
    }
    void OnCollisionExit(Collision hit)
    {
        isGrounded = false;
    }
}
