using UnityEngine;

[RequireComponent(typeof (CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public PlayerInput input;

    public float Speed = 5;
    public float Gravity = -16f;
    public float JumpStrength = 2f;

    private CharacterController character;
    private Vector3 velocity;
    
    private void Start() 
    {
        input.OnJump = JumpEvent;
        character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector2 localInput = new Vector2(input.Horizontal * Speed, input.Vertical * Speed);

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
    
    public void JumpEvent()
    {
        if (character.isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpStrength * -2 * Gravity);
        }
    }
}