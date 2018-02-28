using HoloToolkit.Unity.InputModule;
using UnityEngine;

//creator: rico evers

public class Interact : MonoBehaviour, IInputClickHandler, ISpeechHandler
{

    [SerializeField] private string function = "triggerAnimation";
    [SerializeField] private GazeManager _gazeManager;

	public void OnInputClicked(InputClickedEventData eventData)
	{
		_gazeManager.HitObject.SendMessage(function);
	}


	public void OnSpeechKeywordRecognized(SpeechEventData eventData)
	{
		if (eventData.RecognizedText.ToLower().Contains("start"))
		{
			_gazeManager.HitObject.SendMessage(function);
		}
	}
}
