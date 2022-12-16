// SrtumDev
// YouTube https://www.youtube.com/channel/UCsAcfm0AVVZwLiJ3D451R3g/featured
// Discord https://discord.gg/GtzqG7pgNJ
// GitHub https://github.com/StrumDev

using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded { get; private set; }

    private void OnTriggerStay(Collider other) => isGrounded = true;
    private void OnTriggerExit(Collider other) => isGrounded = false;
}
