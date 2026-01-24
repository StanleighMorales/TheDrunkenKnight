using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject nextButton;
    public GameObject dialoguePanel;
    public static bool isDialogueActive = false;

    private int index;

    void Start()
    {
        dialoguePanel.SetActive(false);
        nextButton.SetActive(false);
        textComponent.text = string.Empty;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !isDialogueActive)
        {
            Debug.Log("Starting Dialogue");
            StartDialogue();
        }

        // 2. Only run dialogue input logic if the dialogue is actually open
        if (isDialogueActive)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (textComponent.text == lines[index])
                {
                    // If line is finished, the button or click moves to next
                    NextLine();
                }
                else
                {
                    // If still typing, skip to the end of the line
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                    nextButton.SetActive(true);
                }
            }
        }
    }

    void StartDialogue()
    {
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        index = 0;
        textComponent.text = string.Empty;

        // Setup Cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        nextButton.SetActive(false);
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        nextButton.SetActive(true);
    }

    public void OnNextButtonClick() // For your TMP Button
    {
        NextLine();
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
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
