using UnityEngine;

public class DestroyItself : MonoBehaviour
{
    public float destroyTime = 1f;

    private void Update()
    {
        destroyTime -= Time.deltaTime;
        if (destroyTime < 0f)
        {
            Destroy(gameObject);
        }
    }
}