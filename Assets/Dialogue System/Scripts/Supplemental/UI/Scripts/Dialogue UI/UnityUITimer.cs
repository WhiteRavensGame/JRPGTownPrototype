using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

namespace PixelCrushers.DialogueSystem {

	[AddComponentMenu("Dialogue System/UI/Unity UI/Dialogue/Timer")]
	public class UnityUITimer : MonoBehaviour {

		public void StartCountdown(float duration, Action timeoutHandler) {
			StartCoroutine(Countdown(duration, timeoutHandler));
		}
		
		private IEnumerator Countdown(float duration, Action timeoutHandler) {
			Slider slider = GetComponent<Slider>();
			if (slider == null) yield break;
			float startTime = DialogueTime.time;
			float endTime = startTime + duration;
			while (DialogueTime.time < endTime) {
				float elapsed = DialogueTime.time - startTime;
				slider.value = Mathf.Clamp(1 - (elapsed / duration), 0, 1);
				yield return null;
			}
			if (timeoutHandler != null) timeoutHandler();
		}
		
		public void OnDisable() {
			StopAllCoroutines();
		}
			
	}

}
