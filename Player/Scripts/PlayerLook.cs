using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public PlayerInput input;
    public Transform playerBody;

    private float xRot;

    void Start() { }

    private void LateUpdate()
    {
        Vector2 mou = new Vector2(input.MouseX * input.Sensitivity, input.MouseY * input.Sensitivity);

        xRot -= mou.y;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

        playerBody.Rotate(Vector3.up * mou.x);
    }
}
