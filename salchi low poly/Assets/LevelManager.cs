using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

  public GameObject planetaTierra;
  public GameObject infierno;
  public Camera camera;
  public Color infColor;
  public Color pltierraColor;
  public bool Automatic = false;
  public float temporizador = 2.0f;
  private float time = 0.0f;


	void Start () {

        planetaTierra.SetActive(true);
        infierno.SetActive(false);
        camera.backgroundColor = pltierraColor;
	}
	
	
	void Update () {
        CambiarMundo();
        if (Automatic)
        {
            CambiarAutomaticamente();
        }
        
	}


    void CambiarAutomaticamente()
    {
        time += Time.deltaTime;
        if (time >= temporizador)
        {
            time = 0.0f;
            PuertaCambiarMundo();
            return;
        }
    }
    public void CambiarMundo()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (planetaTierra.activeInHierarchy)
            {
                planetaTierra.SetActive(false);
                infierno.SetActive(true);
                camera.backgroundColor = infColor;
            }
            else
            {
                planetaTierra.SetActive(true);
                infierno.SetActive(false);
                camera.backgroundColor = pltierraColor;
            }
        }
    }
    public void PuertaCambiarMundo()
    {
       
            if (planetaTierra.activeInHierarchy)
            {
                planetaTierra.SetActive(false);
                infierno.SetActive(true);
                camera.backgroundColor = infColor;
            }
            else
            {
                planetaTierra.SetActive(true);
                infierno.SetActive(false);
                camera.backgroundColor = pltierraColor;
            }
        
    }
}
