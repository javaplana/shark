using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour
{

    public bool alive = true;
    public bool inputEnabled = false;

    public GameManager gm;

    public float speed = 100.0f;

    void FixedUpdate()
    {
        if (alive && inputEnabled)
        {
            float moveVertical = Input.GetAxis("Vertical");

            transform.Translate(new Vector3(0f, moveVertical, 0f) * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!alive)
            return;

        HealthImpact hi = collision.gameObject.GetComponent<HealthImpact>();

        if (hi == null) { return; }

        if (hi.healthImpact > 0)
        {
            gm.updateScore(hi.healthImpact);
        }
        else
        {
            gm.updateHealth(hi.healthImpact);
        }

        Destroy(collision.gameObject);
    }
}
