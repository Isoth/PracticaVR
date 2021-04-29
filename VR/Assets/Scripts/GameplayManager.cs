using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayManager : MonoBehaviour
{

    private static GameplayManager instance;

    private float timeZero;
    public float playingTime = 60f;
    public TextMeshProUGUI textPuntos;
    public TextMeshProUGUI textTiempo;

    public float points = 0f;

    // Start is called before the first frame update
    void Start()
    {
        timeZero = Time.realtimeSinceStartup;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup > (playingTime + timeZero));
        {
            Application.Quit();
        }
        textPuntos.text = points.ToString();
        textTiempo.text = Time.realtimeSinceStartup.ToString();
    }

    public static GameplayManager GetInstance()
    {
        return instance;
    }
}
