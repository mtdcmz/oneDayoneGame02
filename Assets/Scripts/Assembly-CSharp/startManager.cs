using UnityEngine;

public class startManager : staticManager
{
    public void toGame()
    {
        Application.LoadLevel("game");
    }

    public void toTip()
    {
        Application.LoadLevel("tip");
    }
}