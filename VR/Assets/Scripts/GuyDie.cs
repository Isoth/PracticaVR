using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyDie : MonoBehaviour
{

    Animator anim;

    public float minStayTime = 3f;
    public float maxStayTime = 5f;
    public float pointsHit = 0f;
    public float pointsMiss = 5f;

    private float timeZero = 0f;
    private float waitTime = 0f;

    public delegate void ShootEventHandler();
    public event ShootEventHandler OnShoot;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if(anim == null)
        {
            Debug.Log("No encuentra animator");
        }
        timeZero = Time.realtimeSinceStartup;
        waitTime = Random.Range(minStayTime, maxStayTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.realtimeSinceStartup > (timeZero + waitTime))
        {
            anim.SetTrigger("EndNow");
            GameplayManager.GetInstance().points += this.pointsMiss;
            this.enabled = false;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            anim.SetTrigger("EndNow");
            GameplayManager.GetInstance().points += this.pointsHit;
            Destroy(this.gameObject);
            this.enabled = false;
        }
    }
}
