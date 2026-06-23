using UnityEngine;
using UnityEngine.UI;

public class gameManager : staticManager
{
    public Color can = Color.white;
    public Color cannot = Color.gray;

    public void chooseScene(int G_scene)
    {
        if (staticManager.scene[G_scene - 1])
        {
            staticManager.levelname = G_scene;
            Application.LoadLevel(G_scene.ToString());
        }
    }

    public void backScene(string name)
    {
        Application.LoadLevel(name);
    }

    public void next()
    {
        if (staticManager.levelname < 9)
        {
            staticManager.levelname++;
            Application.LoadLevel(staticManager.levelname.ToString());
        }
        else
        {
            Application.LoadLevel("game");
        }
    }

    public void retry()
    {
        Application.LoadLevel(staticManager.levelname.ToString());
    }

    private void Start()
    {
        if (staticManager.levelname != 9 && !staticManager.scene[staticManager.levelname] && Application.loadedLevelName == "win")
        {
            staticManager.scene[staticManager.levelname] = true;
            PlayerPrefs.SetInt("level", staticManager.levelname + 1);
        }
    }

    private void Update()
    {
        if (Application.loadedLevelName != "game") return;

        for (int i = 0; i < 9; i++)
        {
            GameObject obj = GameObject.Find((i + 1).ToString());
            if (!staticManager.scene[i])
                obj.GetComponent<Image>().color = cannot;
            else
                obj.GetComponent<Image>().color = can;
        }
    }
}