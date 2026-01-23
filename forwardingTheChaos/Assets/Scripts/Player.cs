using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;

    void Update()
    {
        float x = 0f;
        float z = 0f;

        if (Input.GetKey(KeyCode.W)) z += 1f;
        if (Input.GetKey(KeyCode.S)) z -= 1f;
        if (Input.GetKey(KeyCode.A)) x -= 1f;
        if (Input.GetKey(KeyCode.D)) x += 1f;

        Vector3 move = new Vector3(x, 0f, z).normalized;
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, move, rotateSpeed * Time.deltaTime);
    }
}
