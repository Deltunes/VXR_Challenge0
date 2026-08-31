using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_change : MonoBehaviour
{
    public Camera Camera;
    public Transform new_player_pos;
    public Transform door_cam_pos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController cc = other.GetComponent<CharacterController>();
            cc.enabled = false;
            other.transform.position = new_player_pos.position;
            cc.enabled = true;
            //Camera.transform.position = door_cam_pos.transform.position;
        }
    }
}
