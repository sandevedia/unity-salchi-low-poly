using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BichoInfierno : MonoBehaviour
{

    Transform player;
    public UnityEngine.AI.NavMeshAgent agent { get; private set; }
    bool PlayerNadando = false;
    Animator anim;
    public float speed;
    GameObject parent1;
    GameObject parent2;
   

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        parent1 = GameObject.Find("BichosPlanetaTierra");
        
        parent2 = GameObject.Find("BichosInfierno");
        gameObject.transform.parent = parent2.transform;
    }

   
   public void Perseguir(bool Setwalk)
    {
       // if (player.GetComponent<Salchi_Controller3raPersona>().nadando && player != null)
        //{
            agent.SetDestination(player.position);
            anim.SetBool("walk", Setwalk);
            agent.speed = speed;

       // }
    }


   public void CambiarPadre(Transform ubicacion)
   {
       if (gameObject.transform.parent == parent1.transform)
       {
           gameObject.transform.parent = parent2.transform;
           gameObject.transform.position = ubicacion.position;
       }
       else {
           gameObject.transform.parent = parent1.transform;
           gameObject.transform.position = ubicacion.position;
       }
   }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Perseguir(true);
            print("deberia andar");
            agent.Resume();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Perseguir(false);
            agent.Stop();
        }
    }
}
