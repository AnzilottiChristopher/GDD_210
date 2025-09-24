using UnityEngine;

public class TargetScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        Destroy(gameObject);
        ScoreManager.scoreManager.AddScore(1);
        ShootScript.ResetCrosshair();
    }
}
