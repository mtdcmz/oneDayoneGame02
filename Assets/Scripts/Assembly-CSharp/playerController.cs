using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public GameObject bullet;

    private void Update()
    {
        if (transform.position.y < 4f && transform.position.y > -4f)
        {
            transform.Translate(0f, moveSpeed * Time.deltaTime * Input.GetAxis("Vertical"), 0f);
        }
        if (transform.position.y >= 4f)
        {
            transform.position = new Vector3(transform.position.x, 3.9f, transform.position.z);
        }
        if (transform.position.y <= -4f)
        {
            transform.position = new Vector3(transform.position.x, -3.9f, transform.position.z);
        }

        if (transform.position.x < 7f && transform.position.x > -7f)
        {
            transform.Translate(moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0f, 0f);
        }
        if (transform.position.x >= 7f)
        {
            transform.position = new Vector3(6.9f, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -7f)
        {
            transform.position = new Vector3(-6.9f, transform.position.y, transform.position.z);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(bullet, transform.position + new Vector3(0f, -0.5f, 0f), transform.rotation);
        }
    }
}