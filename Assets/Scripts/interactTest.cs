using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interactTest : MonoBehaviour, IInteractable
{
    public string interact_message => objectInteractMessage;
    [SerializeField] dialogue dialogueBox;

    [SerializeField]
    string objectInteractMessage;

    public void Interact()
    {
        printOnInteract();
    }

    void printOnInteract()
    {
        dialogueBox.gameObject.SetActive(true);
        
    }
}
