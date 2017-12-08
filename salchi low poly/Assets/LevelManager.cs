using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

  public GameObject planetaTierra;
  public GameObject infierno;
  public Camera camera;
  public Color infColor;
  public Color pltierraColor;

	void Start () {

        planetaTierra.SetActive(true);
        infierno.SetActive(false);
        camera.backgroundColor = pltierraColor;
	}
	
	
	void Update () {
        CambiarMundo();
	}

    void CambiarMundo()
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
}
