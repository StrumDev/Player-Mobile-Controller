// SrtumDev
// YouTube https://www.youtube.com/channel/UCsAcfm0AVVZwLiJ3D451R3g/featured
// Discord https://discord.gg/GtzqG7pgNJ
// GitHub https://github.com/StrumDev
using UnityEngine;

[RequireComponent(typeof (CharacterController))]
public class PlayerMuvment : MonoBehaviour
{
    public float Speed = 5;
    public float Gravity = -16f;
    public float JumpStrength = 2f;
    public FloatingJoystick FloatingJoystick;

    private CharacterController character;
    private Vector3 velocity;
    
    private void Start() 
    {
        character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector2 input = new Vector2(FloatingJoystick.Horizontal * Speed, FloatingJoystick.Vertical * Speed);

        Vector3 move = transform.right * input.x + transform.forward * input.y;

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
