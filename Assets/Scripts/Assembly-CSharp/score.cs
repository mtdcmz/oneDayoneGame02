using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    private int currentScore;

    private void Start()
    {
        currentScore = PlayerPrefs.GetInt("score");
    }

    private void Update()
    {
        GetComponent<Text>().text = "SCORE:" + currentScore;
    }
}