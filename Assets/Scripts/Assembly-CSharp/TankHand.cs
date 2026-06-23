using UnityEngine;

public class TankHand : staticManager
{
    private Vector3 tarPos;
    private Vector3 objPos;
    private Vector3 direction;
    private Transform target;
    public GameObject bullet;
    private GameObject createBallPosition;
    public float shotTime = 1f;
    private float bulletShotTime;

    private void Start()
    {
        createBallPosition = GameObject.Find("createBallPosition");
        GameObject playerObj = GameObject.Find("player");
        if (playerObj != null)
            target = playerObj.transform;
        else
            Debug.LogError("未找到名为 'player' 的对象！");
    }

    private void Update()
    {
        if (target == null || createBallPosition == null)
            return;

        tarPos = target.position;
        objPos = transform.position;
        direction = tarPos - objPos;
        direction.z = 0f;

        if (transform.rotation.z < 0.6 && transform.rotation.z > -0.6)
            transform.up = direction;

        bulletShotTime -= Time.deltaTime;
        if (bulletShotTime < 0f)
        {
            Instantiate(bullet, createBallPosition.transform.position, transform.rotation);
            bulletShotTime = shotTime;
        }
    }
}