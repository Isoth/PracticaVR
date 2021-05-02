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

    public LineRenderer _line;
    public float laserWidth = 0.1f;

    public GameObject mirilla;

    // Start is called before the first frame update
    void Start()
    {
        _line = gameObject.GetComponent<LineRenderer>();
        gameObject.GetComponent<LineRenderer>().widthCurve = AnimationCurve.Linear(0, 0.1f, .5f, .1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!XRSettings.enabled)
        {
            CameraPosition();
        }

        if (Input.GetButtonDown("Fire1") || Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            ShootABullet();
        }

        //int LayerMask = 1 << 8;

        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 500);
        _line.SetPosition(0, this.transform.position);
        _line.SetPosition(1, hit.point);

        int LayerMask = 1 << 5;
        int LayerMask1 = 1 << 8;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 500, LayerMask))
        {
            mirilla.SetActive(true);
            mirilla.transform.position = hit.point + hit.normal*0.1f;
            mirilla.transform.rotation = hit.transform.rotation;
            Debug.Log("Did Hit");
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 500, LayerMask1))
        {
            mirilla.SetActive(true);
            mirilla.transform.position = hit.point + hit.normal * 0.1f;
            mirilla.transform.rotation = hit.transform.rotation;
            Debug.Log("Did Hit");
        }
        else
        {
            mirilla.SetActive(false);
            Debug.Log("Did not Hit");
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
