using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float Sensiviti = 0.3f;
    public TouchField TouchField;
    public Transform playerBody;

    private float xRot;

    void Start() { }

    private void LateUpdate()
    {
        Vector2 mou = new Vector2(TouchField.TouchAxis.x * Sensiviti, TouchField.TouchAxis.y * Sensiviti);

        xRot -= mou.y;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

        playerBody.Rotate(Vector3.up * mou.x);
    }
}
