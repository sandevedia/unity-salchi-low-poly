﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class tiburon : MonoBehaviour {

    Transform player;
    public UnityEngine.AI.NavMeshAgent agent { get; private set; }
    bool PlayerNadando = false;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {

        Perseguir();
      
	}

    void Perseguir() {
        if (player.GetComponent<Salchi_Controller3raPersona>().nadando && player != null)
        {
            agent.SetDestination(player.position);

        }
    }
}
