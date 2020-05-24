using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    public float Speed;

    // Start is called before the first frame update
    private void Update()
    {
        Move();
    }

    // Update is called once per frame
    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float clamped = Mathf.Clamp01(Vector3.SqrMagnitude(new Vector3(horizontal, 0, vertical)));
        Vector3 translation = new Vector3(transform.right.x * horizontal, 0, transform.forward.z * vertical);
        transform.position += translation.normalized * clamped * Time.deltaTime * Speed;
    }
}
