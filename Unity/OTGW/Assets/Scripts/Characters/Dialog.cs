using UnityEngine;

[System.Serializable]
public class Dialog
{
	[TextArea(3, 10)]
	public string[] Sentences;
    
	public string SpeakingCharacterName;
}
