using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paloma : MonoBehaviour {

    Animator anim;
    Rigidbody rig;
    bool Playertrigger = false;
	void Start () {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Playertrigger)
        {
            StartCoroutine(Volar());
        }
        
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Playertrigger = true;
            Destroy(gameObject, 10f);           
        }
    }

    IEnumerator Volar()
    {
        anim.SetBool("fly", true);
        transform.Translate(new Vector3(0, 2, 2) * Time.deltaTime * 4, Space.Self);

        yield return new WaitForSeconds(0.0f);

    }
}
