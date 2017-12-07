using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salchi_Controller : MonoBehaviour {

    public float speed = 4.0f;
    public float jump = 2.0f;
    bool ground = false;
    Animator anim;
    //float inputZ;
   // float inputY;

    void Start()
    {
        anim=GetComponent<Animator>();
    }
	void Update () {
      // Move();
      Move2();    
               
	}

    void Move2()
    {
               
           // transform.Translate(new Vector3(-Input.GetAxisRaw("Vertical"), 0 , Input.GetAxisRaw("Horizontal")) * Time.deltaTime * speed, Space.World);
            transform.Translate(new Vector3(0, 0, Input.GetAxisRaw("Horizontal")) * Time.deltaTime * speed, Space.World);

            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                transform.LookAt(new Vector3(0, 0, -999999));
               anim.SetBool("run", true);
                // transform.Translate(new Vector3(inputY, 0 , -inputZ) * Time.deltaTime * speed);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                transform.LookAt(new Vector3(0, 0, 999999));
                anim.SetBool("run", true);
                //transform.Translate(new Vector3(-inputY, 0, inputZ) * Time.deltaTime * speed);

            }
            else
            {
                anim.SetBool("run", false);

            }

        //JUMP
        if (Input.GetKeyDown(KeyCode.UpArrow) && ground)
        {
            StartCoroutine(Saltar());
        }
    }

    IEnumerator Saltar()
    {
        GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(0, 1 * jump, 0), transform.position, ForceMode.Impulse);

        yield return new WaitForSeconds(2f);

    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "suelo")
        {
            ground = true;
            anim.SetBool("ground", true);
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

    }



}
