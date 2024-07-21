using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueComponent : MonoBehaviour, Iinteractuable
{

    [SerializeField] private Dialogue dialogue;

	public void Interaction()
	{
        DialogueManager.Instance.StartDialogue(dialogue);
    }


}
