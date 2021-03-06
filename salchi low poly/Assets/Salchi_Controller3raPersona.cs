﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salchi_Controller3raPersona : MonoBehaviour {

    public float speed = 8.0f;
    public float speedInWater = 1f;
    float speedNormal;

    public float jump = 5.0f;
    bool ground = false;
    Animator anim;

    public bool nadando = false;
    GameObject levelManager;
    Rigidbody rib;
    
    void Start()
    {
     
        anim = GetComponent<Animator>();
        speedNormal = speed;
        levelManager = GameObject.Find("LevelManager");
        rib = GetComponent<Rigidbody>();
    }
    void Update()
    {
            Move2();
            Jump();
    }

    void Move2()
    {

        if (ground)
        {
            transform.Translate(new Vector3(-Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal")) * Time.deltaTime * speed, Space.World);

            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                transform.LookAt(new Vector3(Input.GetAxisRaw("Vertical") * 100000, 0, -Input.GetAxisRaw("Horizontal") * 100000));
                anim.SetBool("run", true);
                
            }
            else
            {
                anim.SetBool("run", false);
                
            }

        }
        else {
            transform.Translate(new Vector3(-Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal")) * Time.deltaTime * speed/3, Space.World);

            rib.AddForce(Vector3.down * 10 * -Physics.gravity.y);

            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                transform.LookAt(new Vector3(Input.GetAxisRaw("Vertical") * 100000, 0, -Input.GetAxisRaw("Horizontal") * 100000));
                anim.SetBool("run", false);
               
            }
        }
               
    }

    void Jump()
    {
        //JUMP
        if (Input.GetKeyDown(KeyCode.Space) && ground)
        {
            StartCoroutine(Saltar());
        }
    }

    IEnumerator Saltar()
    {
        GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(0, 1 * jump, 0), transform.position, ForceMode.Impulse);
        yield return new WaitForSeconds(2f);

    }
    
   /* void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "puerta")
        {

            levelManager.GetComponent<LevelManager>().PuertaCambiarMundo();
           print("deberia cambiar");
        }
    }*/
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "suelo")
        {
            ground = true;
            anim.SetBool("ground", true);
        }
        else if (col.gameObject.tag == "agua")
        {
            nadando = true;
            speed = speedInWater;
            //print("nadando");
        }
        else
        {
            ground = false;
            //print("in air");
            anim.SetBool("ground", false);
            speed = speedNormal;
        }

    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "suelo")
        {
            ground = false;
            //print("in air");
            anim.SetBool("ground", false);

        }
        else if (col.gameObject.tag == "agua")
        {
            nadando = false;
            speed = speedNormal;
            print("salio del agua");
        }
        

    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "suelo")
        {
            ground = true;
            anim.SetBool("ground", true);
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "suelo")
        {
            ground = false;
            //print("in air");
            anim.SetBool("ground", false);
        }
    }


}