using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Image faceImage;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject chat;

    //[SerializeField] private Animator animator;

    private Queue<string> sentences;

    private void Awake()
    {
        if(Instance != null && Instance !=this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //animator.SetBool("IsOpen", true);
        chat.SetActive(true);

        nameText.text = dialogue.name;
        faceImage.sprite = dialogue.faceImage;


        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        //animator.SetBool("IsOpen", false);
        chat.SetActive(false);

    }

}
