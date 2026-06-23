using UnityEngine;

public class TankController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private void Start()
    {
        moveSpeed += Random.Range(0f, 1f) * moveSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < -10f)
        {
            TankCreate.currentTankNumber--;
            TankCreate.sumTankNumber--;
            Destroy(gameObject);
        }
    }
}