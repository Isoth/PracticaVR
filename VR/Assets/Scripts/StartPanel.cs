using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    public bool play = false;
    public GameObject panelStart;
    public GameObject panelGame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            panelStart.SetActive(false);
            panelGame.SetActive(true);
        }
    }

    void OnCollisionEntre(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            play = true;
        }    
    }
}
