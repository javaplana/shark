using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthImpact : MonoBehaviour
{
    public int healthImpact = -3;

    public float xSpeed = -4f;

    private void Update()
    {
        transform.Translate(new Vector3(xSpeed * Time.deltaTime, 0f, 0f));
        if (transform.position.x < -11)
        {
            Destroy(this.gameObject);
        }
    }
}
