using UnityEngine;

public class staticManager : MonoBehaviour
{
    public static bool[] scene = new bool[9];
    public static int levelname;

    private void Start()
    {
        int num = PlayerPrefs.GetInt("level");
        if (num == 0) num = 1;

        for (int i = 0; i < num; i++)
            scene[i] = true;

        for (int j = num; j < 9; j++)
            scene[j] = false;
    }
}