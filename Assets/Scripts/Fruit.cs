using UnityEngine;

public class Fruit : MonoBehaviour
{
    public float fallSpeed = 3f;

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < -6f)
        {
            GameManager.instance.AddScore(-1);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}
