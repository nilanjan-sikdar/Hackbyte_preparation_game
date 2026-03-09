using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput; // FIXED: Now references your actual script

    private bool isWalking;

    void Update()
    {
        Vector3 move = gameInput.GetMovementVectorNormalized();

        float playerSize = 0.7f; // Adjust this value based on your player's actual size (e.g., radius or half-width)
        float playerHeight = 2f; // Adjust this value based on your player's actual height (e.g., from feet to head)
        float moveDistance = moveSpeed * Time.deltaTime;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerSize, move, moveDistance);
        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(move.x, 0f, 0f).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerSize, moveDirX, moveDistance);

            if (canMove)
            {
                move = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0f, 0f, move.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerSize, moveDirZ, moveDistance);
                if (canMove)
                {
                    move = moveDirZ;
                }
                else
                {

                }
            }
        }
        if (canMove)
        {
            transform.Translate(move * moveDistance, Space.World);
        }
        isWalking = move != Vector3.zero;

        float rotateSpeed = 10f;

        // Safety check to prevent Unity console errors when standing still
        if (move != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, move, rotateSpeed * Time.deltaTime);
        }
    }
    public bool IsWalking()
    {
        return isWalking;
    }
}