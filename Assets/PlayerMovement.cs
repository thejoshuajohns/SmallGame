using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f) * speed * Time.deltaTime;

        transform.Translate(movement);

        if (transform.position.x > 9f)
        {
            transform.position = new Vector3(9f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -9f)
        {
            transform.position = new Vector3(-9f, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Object.FindFirstObjectByType<GameController>().LoseGame();

            Destroy(gameObject);
        }
    }
}
