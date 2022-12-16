// SrtumDev
// YouTube https://www.youtube.com/channel/UCsAcfm0AVVZwLiJ3D451R3g/featured
// Discord https://discord.gg/GtzqG7pgNJ
// GitHub https://github.com/StrumDev

using UnityEngine;

public class PlayerLock : MonoBehaviour
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
