using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public float camTurnSpeed, camZoom;
    
    public Transform player;

    void LateUpdate ()
    {
        var rot = Input.GetAxis("CamHorizontal")* Time.deltaTime * camTurnSpeed;
        // var rotB = Time.deltaTime * camTurnSpeed;
        var zoom = Input.GetAxis("CamVertical")* Time.deltaTime * camZoom;

        transform.position = player.position;
        transform.Rotate(0,rot,0);
        transform.localScale += new Vector3(zoom,zoom,zoom);
        // if (Input.GetMouseButton(1) == false){
            transform.rotation = player.rotation;
        // }
        // if (transform.rotation.y < player.rotation.y) {
        //     transform.Rotate(0,rotB,0);
        // }
        // if (transform.rotation.y > player.rotation.y) {
        //     transform.Rotate(0,-rotB,0);
        // }
    }
}