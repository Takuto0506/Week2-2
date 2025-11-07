using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float screenHalfWidthInWorldUnits;

    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        transform.position += Vector3.right * inputX * moveSpeed * Time.deltaTime;

        // âÊñ äOÇ…èoÇ»Ç¢ÇÊÇ§Ç…
        float clampedX = Mathf.Clamp(transform.position.x, -screenHalfWidthInWorldUnits, screenHalfWidthInWorldUnits);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
