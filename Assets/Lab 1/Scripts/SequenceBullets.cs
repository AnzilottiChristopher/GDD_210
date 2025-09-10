using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SequenceBullets : MonoBehaviour
{
    public bool isLastBullet = false;
    public SequenceBullets nextBullet;
    public float speed = 5f;
    public float resetY = 6f;
    public float stopPos = -7.51f;
    public float startPosZ = 7.51f;
    public bool moving = false;
    public float delay = 0.3f;
    public UnityEvent done;
    public bool nextTriggered = false;

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);

            if (!nextTriggered && transform.position.z <= startPosZ / 3 && nextBullet != null)
            {
                nextTriggered = true;
                StartCoroutine(TriggerNextAfterDelay());
            }
            if (transform.position.z <= stopPos)
            {
                moving = false;
                transform.position = new Vector3(transform.position.x, transform.position.y, startPosZ);
                nextTriggered = false;
                if (isLastBullet)
                {
                    done.Invoke();
                }

            }
        }
    }

    public void Shoot()
    {
        moving = true;
    }
    
    private IEnumerator TriggerNextAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        nextBullet.Shoot();
    }
}
