using UnityEngine;

[RequireComponent(typeof (CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public PlayerInput input;

    public float Speed = 5f;
    public float RunSpeed = 9f;
    public float Gravity = -16f;
    public float JumpStrength = 2f;

    private CharacterController character;
    private Vector3 velocity;

    private bool isRun;
    
    private void Start() 
    {
        input.OnRun = (b) => isRun = b;
        input.OnJump = Jump;
        character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float localSpeed = isRun ? RunSpeed : Speed;

        Vector2 localInput = new Vector2(input.Horizontal * localSpeed, input.Vertical * localSpeed);

        Vector3 move = transform.right * localInput.x + transform.forward * localInput.y;

        velocity.x = move.x;
        velocity.z = move.z;
    }

    private void FixedUpdate()
    {
        character.Move(velocity * Time.fixedDeltaTime);
        
        if (!character.isGrounded)
            velocity.y += Gravity * Time.fixedDeltaTime;
        else
            velocity.y = -2;
    }
    
    private void Jump()
    {
        if (character.isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpStrength * -2 * Gravity);
        }
    }
}