using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public float camTurnSpeed;
    public GameObject player;

    private Vector3 offset;

    void Start ()
    {
        offset = transform.position - player.transform.position;
    }
    
    void LateUpdate ()
    {
        var rot = Input.GetAxis("CamHorizontal")* Time.deltaTime * camTurnSpeed;

        transform.position = player.transform.position + offset;
        transform.Rotate(0,rot,0);
    }
}