using UnityEngine;
using UnityEngine.UI;

public class TankCreate : MonoBehaviour
{
    public GameObject tank;
    public static int score;
    public static int currentTankNumber;
    public static int sumTankNumber;

    private GameObject textScore;
    private GameObject tankNumber;
    private int levelname;
    private Vector3 CreatePosiotion = new Vector3(0f, -3.2f, 0f);

    private void Start()
    {
        if (!int.TryParse(Application.loadedLevelName, out levelname))
        {
            Debug.LogError("场景名不是数字：" + Application.loadedLevelName);
            return;
        }

        sumTankNumber = 10 * levelname;
        currentTankNumber = 0;

        textScore = GameObject.Find("score");
        if (textScore == null) Debug.LogError("找不到 'score'");

        tankNumber = GameObject.Find("tankNumber");
        if (tankNumber == null) Debug.LogError("找不到 'tankNumber'");

        score = PlayerPrefs.GetInt("score");
        winJudge();
    }

    private void Update()
    {
        if (textScore != null)
            textScore.GetComponent<Text>().text = "SCORE:" + score;

        if (currentTankNumber <= 0)
            createTank(levelname);

        winJudge();
    }

    private void createTank(int number)
    {
        if (number < 4)
        {
            CreatePosiotion.x = Random.Range(9f, 10f);
            Instantiate(tank, CreatePosiotion, transform.rotation);
            currentTankNumber = 1;
        }
        else if (number < 7)
        {
            CreatePosiotion.x = Random.Range(9f, 10f);
            Instantiate(tank, CreatePosiotion, transform.rotation);
            CreatePosiotion.x = Random.Range(9f, 13f);
            Instantiate(tank, CreatePosiotion, transform.rotation);
            currentTankNumber = 2;
        }
        else
        {
            CreatePosiotion.x = Random.Range(9f, 10f);
            Instantiate(tank, CreatePosiotion, transform.rotation);
            CreatePosiotion.x = Random.Range(12f, 13f);
            Instantiate(tank, CreatePosiotion, transform.rotation);
            CreatePosiotion.x = Random.Range(10f, 16f);
            Instantiate(tank, CreatePosiotion, transform.rotation);
            currentTankNumber = 3;
        }
    }

    private void winJudge()
    {
        if (tankNumber == null) return;

        switch (levelname)
        {
            case 1:
                tankNumber.GetComponent<Text>().text = "坦克X一倍速度:" + sumTankNumber;
                break;
            case 2:
                tankNumber.GetComponent<Text>().text = "坦克X二倍速度:" + sumTankNumber;
                break;
            case 3:
                tankNumber.GetComponent<Text>().text = "坦克X三倍速度:" + sumTankNumber;
                break;
            case 4:
                tankNumber.GetComponent<Text>().text = "坦克X四倍速度:" + sumTankNumber;
                break;
            case 5:
                tankNumber.GetComponent<Text>().text = "坦克X五倍速度:" + sumTankNumber;
                break;
            case 6:
                tankNumber.GetComponent<Text>().text = "坦克X六倍速度:" + sumTankNumber;
                break;
            case 7:
                tankNumber.GetComponent<Text>().text = "坦克X七倍速度:" + sumTankNumber;
                break;
            case 8:
                tankNumber.GetComponent<Text>().text = "坦克X八倍速度:" + sumTankNumber;
                break;
            case 9:
                tankNumber.GetComponent<Text>().text = "终极挑战X九倍速度:" + sumTankNumber;
                break;
        }

        if (sumTankNumber <= 0)
            Application.LoadLevel("win");
    }
}