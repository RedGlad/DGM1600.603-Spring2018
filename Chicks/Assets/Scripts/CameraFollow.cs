using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public float camTurnSpeed, camZoom;
    public Transform player;

    void LateUpdate ()
    {
        var rot = Input.GetAxis("CamHorizontal")* Time.deltaTime * camTurnSpeed;
        var zoom = Input.GetAxis("CamVertical")* Time.deltaTime * camZoom;

        transform.position = player.position;
        transform.Rotate(0,rot,0);
        transform.localScale += new Vector3(zoom,zoom,zoom);
            transform.rotation = player.rotation;
    }
}