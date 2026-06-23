using UnityEngine;

public class playerBullet : MonoBehaviour
{
    public GameObject explosion_land;
    public GameObject explosion_tank;

    private void Update()
    {
        if (transform.position.y < -3.75)
        {
            Instantiate(explosion_land, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "tank")
        {
            TankCreate.score += 10;
            TankCreate.currentTankNumber--;
            TankCreate.sumTankNumber--;
            Instantiate(explosion_tank, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}