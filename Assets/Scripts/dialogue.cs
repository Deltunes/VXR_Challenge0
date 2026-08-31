using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dialogue : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] Camera cam;

    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] string[] lines;
    [SerializeField] AudioSource talkSound;
    public float textSpeed;

    private int index;
    private string pauselessLine;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.dialogueActive = true;
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            pauselessLine = string.Empty;
            foreach (char c in lines[index].ToCharArray())
            {
                if (c != '^')
                {
                    pauselessLine += c;
                }
            }

            if (textComponent.text == pauselessLine)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = pauselessLine;
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            if (c == '^')
            {
                yield return new WaitForSeconds(textSpeed * 4.0f);
            }
            else
            {
                textComponent.text += c;
                talkSound.Play();
                yield return new WaitForSeconds(textSpeed);
            }
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            GameManager.lastPlayerLocation = playerPos.position;
            GameManager.lastPlayerRotation = playerPos.rotation;
            GameManager.lastCamLocation = cam.transform.position;
            SceneManager.LoadScene("Battle");
        }
    }
}
