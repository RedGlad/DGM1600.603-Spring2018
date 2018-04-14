using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public float camTurnSpeed, camZoom;
    public Transform player;

    void LateUpdate ()
    {
        // Always follow player position and rotation, even when not parented
        transform.position = player.position;
        transform.rotation = player.rotation;

        // Use I, K, and Right Stick to zoom toward player
        var zoom = Input.GetAxis("CamVertical")* Time.deltaTime * camZoom;
        transform.localScale += new Vector3(zoom,zoom,zoom);

        // Use J, L, and Right Stick to orbit player (Not used)
        // var rot = Input.GetAxis("CamHorizontal")* Time.deltaTime * camTurnSpeed;
        // transform.Rotate(0,rot,0);
    }
}