using System.Numerics;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody rb;
    public float power = 0.03f;
    public float launchPower = 2f;

    public float posX, posZ;

    void Start()
    {
        posX = transform.position.x;
        posZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        if (inputX > 0)
        {
            rb.AddForce(UnityEngine.Vector3.right * power, ForceMode.VelocityChange);
        }
        else if (inputX < 0)
        {
            rb.AddForce(UnityEngine.Vector3.left * power, ForceMode.VelocityChange);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new UnityEngine.Vector3(posX, transform.position.y, posZ);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Launch"))
        {
            rb.AddForce(UnityEngine.Vector3.left * launchPower, ForceMode.VelocityChange);
            rb.AddForce(UnityEngine.Vector3.up * launchPower, ForceMode.VelocityChange);
        }
    }
}
