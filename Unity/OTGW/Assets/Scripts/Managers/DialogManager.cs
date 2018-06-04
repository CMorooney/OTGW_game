using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Random = System.Random;
using IEnumerator = System.Collections.IEnumerator;

public class DialogManager : MonoBehaviour
{
	public Text NameText;
	public Text DialogText;
	public Animator Animator; 

	Queue<string> Sentences;
	Random Random = new Random();

	void Start()
	{
		Sentences = new Queue<string>();
	}
    
    public void RequestRockFact()
	{
		int randomIndex = Random.Next(0, StaticData.RockFacts.Count);

		var rockFact = StaticData.RockFacts[randomIndex];
        
		var rockFactDialog = new Dialog
		{
			Sentences = new [] { rockFact },
			SpeakingCharacterName = GameConstants.GregName
		};

		StartDialog(rockFactDialog);
	}

	public void StartDialog(Dialog dialog)
	{
		Animator.SetBool("IsOpen", true);

		Sentences.Clear();

		NameText.text = dialog.SpeakingCharacterName;

		foreach(var sentence in dialog.Sentences)
		{
			Sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (Sentences.Count <= 0)
		{
			EndDialog();
			return;
		}

		var sentenceToDisplay = Sentences.Dequeue();

		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentenceToDisplay));
	}

	IEnumerator TypeSentence(string sentence)
	{
		DialogText.text = string.Empty;

		foreach(var letter in sentence)
		{
			DialogText.text += letter;
			yield return null;
		}
	}

    void EndDialog()
	{
		Animator.SetBool("IsOpen", false);
	}
}
