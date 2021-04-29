using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Camera : MonoBehaviour
{
    public AudioClip m_shootSound;
    public AudioSource bulletAs;
    public float camSens = 0.50f; //Sensibilidad con el ratón
    Vector3 lastMouse = new Vector3(255, 255, 255);
    [SerializeField] GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!XRSettings.enabled)
        {
            CameraPosition();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            ShootABullet();
        }
    }

    void CameraPosition()
    {
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
    }

    void ShootABullet()
    {
        bulletAs.PlayOneShot(m_shootSound);
        GameObject instFoam = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody instFoamRB = instFoam.GetComponent<Rigidbody>();

        instFoamRB.AddForce(this.transform.forward * 1000);
        Destroy(instFoam, 3f);
    }
}
