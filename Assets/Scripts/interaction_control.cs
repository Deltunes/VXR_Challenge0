using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class interaction_control : MonoBehaviour
{
    [SerializeField]
    Transform playerRayPos;

    [SerializeField]
    TextMeshProUGUI interact_text;

    [SerializeField]
    float interact_dist = 5.0f;

    IInteractable currentTargetedInteractable;

    public void Update()
    {
        UpdateCurrentInteractable();

        UpdateInteractionText();

        CheckForInteractionInput();
    }

    void UpdateCurrentInteractable()
    {
        Physics.Raycast(playerRayPos.position, playerRayPos.forward, out var hit, interact_dist);

        currentTargetedInteractable = hit.collider?.GetComponent<IInteractable>();
    }

    void UpdateInteractionText()
    {
        if (currentTargetedInteractable != null)
        {
            interact_text.text = currentTargetedInteractable.interact_message;
        }
        else
        {
            interact_text.text = string.Empty;
            return;
        }
    }

    void CheckForInteractionInput()
    {
        if (Input.GetKeyDown(KeyCode.Z) && currentTargetedInteractable != null)
        {
            currentTargetedInteractable.Interact();
        }
    }
}
