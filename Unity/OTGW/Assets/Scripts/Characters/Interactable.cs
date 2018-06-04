using UnityEngine;

public class Interactable : MonoBehaviour
{
	public Dialog Dialog;

	public void StartDialog()
	{
		var dialogManager = FindObjectOfType<DialogManager>();
		dialogManager.StartDialog(Dialog);
	}
}
