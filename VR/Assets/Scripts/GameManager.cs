using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float[] scores;

    [SerializeField] TextMeshProUGUI[] scoreTexts;

    [SerializeField] float lastScore = 0;

    public string scene;

    public static GameObject panelScore;
    public static GameObject panelMenu;

    static GameManager _instance;
    public static GameManager managerInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    void Awake()
    {
        /*scoreTexts[0] = TextMeshProUGUI.Find("");*/
        if(_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                Destroy(this.gameObject);
        }

        panelScore = GameObject.Find("Canvas/Panel Puntuaciones");
        panelMenu = GameObject.Find("Canvas/Panel Inicio");
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<GameplayManager>() != null)
        {
            lastScore = FindObjectOfType<GameplayManager>().points;
        }

        if (lastScore > scores[0])
        {
            scores[0] = lastScore;
            scoreTexts[0].text = scores[0].ToString();
        }
        else if (lastScore > scores[1])
        {
            scores[1] = lastScore;
            scoreTexts[1].text = scores[1].ToString();
        }
        else if (lastScore > scores[2])
        {
            scores[2] = lastScore;
            scoreTexts[2].text = scores[2].ToString();
        }
        else if (lastScore > scores[3])
        {
            scores[3] = lastScore;
            scoreTexts[3].text = scores[3].ToString();
        }
        else if (lastScore > scores[4])
        {
            scores[4] = lastScore;
            scoreTexts[4].text = scores[4].ToString();
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        SceneManager.LoadScene(scene);
    }

    public void PanelScore()
    {
        panelMenu.SetActive(false);
        panelScore.SetActive(true);
    }

    public void PanelMenu()
    {
        panelMenu.SetActive(true);
        panelScore.SetActive(false);
    }
}
