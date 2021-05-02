using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonChangePanel : MonoBehaviour
{
    public GameObject panelMenu;
    public GameObject panelScore;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            if (panelMenu.activeSelf)
            {
                panelMenu.SetActive(false);
                panelScore.SetActive(true);
            }
            else
            {
                panelMenu.SetActive(true);
                panelScore.SetActive(false);
            }
        }
    }
}
