using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerPosManage : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Camera cam;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject dragonModel;
    void Start()
    {
        if (GameManager.battleWinState != 0)
        {
            CharacterController cc = player.GetComponent<CharacterController>();
            cc.enabled = false;
            player.position = GameManager.lastPlayerLocation;
            player.rotation = GameManager.lastPlayerRotation;
            cc.enabled = true;

            cam.transform.position = GameManager.lastCamLocation;

            GameManager.dialogueActive = false;

            if (GameManager.battleWinState == 1)
            {
                enemy.gameObject.SetActive(false);
                dragonModel.gameObject.SetActive(false);
            }
        }
    }
}
