using UnityEngine;
using UnityEngine.InputSystem; // Required for the New Input System

public class GameInput : MonoBehaviour
{
    // This creates a field in the Inspector where you can easily bind your keys
    public InputAction movementAction;

    void Start()
    {
        // The New Input System requires actions to be enabled before they can be read
        movementAction.Enable();
    }

    // This is the method your Player script is calling!
    public Vector3 GetMovementVectorNormalized()
    {
        // Read the 2D input (e.g., WASD gives X and Y)
        Vector2 inputVector = movementAction.ReadValue<Vector2>();

        // Map the 2D input to a 3D Vector (X is Left/Right, Z is Forward/Backward)
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        return moveDir.normalized;
    }
}