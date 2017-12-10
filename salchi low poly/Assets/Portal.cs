using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    GameObject levelManager;
    public Transform Destino;
    void Start()
    {
        levelManager = GameObject.Find("LevelManager");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            levelManager.GetComponent<LevelManager>().PuertaCambiarMundo();

        }
        else if (col.gameObject.tag == "bicho")
        {
            col.gameObject.GetComponentInParent<BichoInfierno>().CambiarPadre(Destino);
           
        }
    }
}
