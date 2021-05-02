using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float[] scores;

    /*[SerializeField] TextMeshProUGUI[] scoreTexts;
    public static TextMeshProUGUI[] staticScoreTexts;*/

    public static float lastScore = 0;

    public string scene;

    [SerializeField] GameObject panelScore;
    public static GameObject staticPanelScore;
    [SerializeField] GameObject panelMenu;
    public static GameObject staticPanelMenu;

    static GameManager _instance;
    public static GameManager managerInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
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


        /*for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (staticScoreTexts[i] != null)
            {
                staticScoreTexts[i] = scoreTexts[i];
            }           
        }*/

        if (staticPanelMenu != null)
        {
            staticPanelMenu = panelMenu;
        }
        if (staticPanelScore != null)
        {
            staticPanelScore = panelScore;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        

        if (FindObjectOfType<GameplayManager>() != null)
        {
            lastScore = FindObjectOfType<GameplayManager>().points;
            print(lastScore);
        }
        /*
        if (lastScore > scores[0])
        {
            scores[0] = lastScore;
            staticScoreTexts[0].text = scores[0].ToString();
        }
        else if (lastScore > scores[1])
        {
            scores[1] = lastScore;
            staticScoreTexts[1].text = scores[1].ToString();
        }
        else if (lastScore > scores[2])
        {
            scores[2] = lastScore;
            staticScoreTexts[2].text = scores[2].ToString();
        }
        else if (lastScore > scores[3])
        {
            scores[3] = lastScore;
            staticScoreTexts[3].text = scores[3].ToString();
        }
        else if (lastScore > scores[4])
        {
            scores[4] = lastScore;
            staticScoreTexts[4].text = scores[4].ToString();
        }*/
    }

    public void ChangeScene(Collision other)
    {
        SceneManager.LoadScene(scene);
    }

    public void PanelScore()
    {
        staticPanelMenu.SetActive(false);
        staticPanelScore.SetActive(true);
    }

    public void PanelMenu()
    {
        staticPanelMenu.SetActive(true);
        staticPanelScore.SetActive(false);
    }
}
