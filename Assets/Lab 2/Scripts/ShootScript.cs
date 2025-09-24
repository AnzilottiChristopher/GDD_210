using UnityEngine;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour
{
    public float shootRange = 100f;
    public Image crosshair;
    public Color normalColor = Color.black;
    public Color hitColor = Color.red;
    private static ShootScript instance;

    void Awake()
    {
        if (instance != null && instance.crosshair != null)
        {
            instance.crosshair.color = instance.normalColor;
        }
    }
    // Update is called once per frame
    void Update()
    {
        CheckForTarget();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, shootRange))
        {
            Debug.Log("Hit " + hit.transform.name);
            TargetScript target = hit.transform.GetComponent<TargetScript>();
            if (target != null)
            {
                target.TakeDamage(10);
            }
        }
    }
    void CheckForTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, shootRange))
        {
            TargetScript target = hit.transform.GetComponent<TargetScript>();
            if (target != null)
            {
                crosshair.color = hitColor;
                return;
            }
        }
        crosshair.color = normalColor;
    }
    public static void ResetCrosshair()
    {
        if (instance != null && instance.crosshair != null)
        {
            instance.crosshair.color = instance.normalColor;
        }
    }
}
