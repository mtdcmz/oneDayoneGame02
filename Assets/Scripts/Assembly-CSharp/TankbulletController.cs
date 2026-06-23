using UnityEngine;

public class TankbulletController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public GameObject explosion;

    private void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        if (transform.position.x > 8.2f || transform.position.x < -8.2f ||
            transform.position.y > 5.2f || transform.position.y < -5.2f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Application.LoadLevel("lose");
        }
    }
}