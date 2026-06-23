using UnityEngine;

public class backgroundController : MonoBehaviour
{
    public float moveSpeed = 2f;

    private void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if (transform.position.x <= -16f)
        {
            transform.position = new Vector3(16f, transform.position.y, transform.position.z);
        }
    }
}