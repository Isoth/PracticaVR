using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{

    private static GameplayManager instance;

    public TextMeshProUGUI textPuntos;
    public TextMeshProUGUI textTiempo;

    public float targetTime = 60.0f;
    public float intTargetTime;

    public float points = 0f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        intTargetTime = (int)targetTime;
        textPuntos.text = points.ToString();
        textTiempo.text = intTargetTime.ToString();

        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }

    }

    public static GameplayManager GetInstance()
    {
        return instance;
    }

    void timerEnded()
    {
        SceneManager.LoadScene("Menu");
    }
}
