using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject youLoseScreen;

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        OffPlatform();


    }

    private void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(moveX, 0f, moveZ).normalized;

        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }
    private void OffPlatform()
    {
        if (transform.position.x > 6.7)
        {
            transform.position = new Vector3(-6.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -6.7)
        {
            transform.position = new Vector3(6.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.z > 6.7)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -6.5f);
        }
        if (transform.position.z < -6.7)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 6.5f);
        }

    }
    private void KillPlayer()
    {
        Debug.Log("Hit");
        gameObject.SetActive(false); // example: disable the player
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            KillPlayer();
        }
        if (youLoseScreen != null)
        {
            youLoseScreen.SetActive(true);
        }
        Time.timeScale = 0f;
    }
}
