using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed;
    public float lifetime = 5f;
    public Vector3 direction = Vector3.forward;


    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(direction.x, 0f, 0f);
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        lifetime -= Time.deltaTime;
        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }

    }
}
