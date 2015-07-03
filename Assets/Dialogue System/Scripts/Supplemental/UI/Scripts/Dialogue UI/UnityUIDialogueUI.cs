using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PixelCrushers.DialogueSystem {

	/// <summary>
	/// This component implements IDialogueUI using Unity UI. It's based on 
	/// AbstractDialogueUI and compiles the Unity UI versions of the controls defined in 
	/// UnityUISubtitleControls, UnityUIResponseMenuControls, UnityUIAlertControls, etc.
	///
	/// To use this component, build a UI layout (or use a pre-built one in the Prefabs folder)
	/// and assign the UI control properties. You can save a UnityUIDialogueUI as a prefab and 
	/// assign the prefab or an instance to the DialogueManager.
	/// 
	/// The required controls are:
	/// - NPC subtitle line
	/// - PC subtitle line
	/// - Response menu buttons
	/// 
	/// The other control properties are optional. This component will activate and deactivate
	/// controls as they are needed in the conversation.
	/// </summary>
	[AddComponentMenu("Dialogue System/UI/Unity UI/Dialogue/Dialogue UI")]
	public class UnityUIDialogueUI : AbstractDialogueUI {
		
		/// <summary>
		/// The UI root.
		/// </summary>
		public UnityUIRoot unityUIRoot;
		
		/// <summary>
		/// The dialogue controls used in conversations.
		/// </summary>
		public UnityUIDialogueControls dialogue;
		
		/// <summary>
		/// QTE (Quick Time Event) indicators.
		/// </summary>
		public Graphic[] qteIndicators;
		
		/// <summary>
		/// The alert message controls.
		/// </summary>
		public UnityUIAlertControls alert;

		/// <summary>
		/// Set <c>true</c> to always keep a control focused; useful for gamepads.
		/// </summary>
		public bool autoFocus = false;

		private UnityUIQTEControls qteControls;
		
		public override AbstractUIRoot UIRoot {
			get { return unityUIRoot; }
		}
		
		public override AbstractDialogueUIControls Dialogue {
			get { return dialogue; }
		}
		
		public override AbstractUIQTEControls QTEs {
			get { return qteControls; }
		}
		
		public override AbstractUIAlertControls Alert {
			get { return alert; }
		}
		
		/// <summary>
		/// Sets up the component.
		/// </summary>
		public override void Awake() {
			base.Awake();
			FindControls();
		}
		
		/// <summary>
		/// Logs warnings if any critical controls are unassigned.
		/// </summary>
		private void FindControls() {
			qteControls = new UnityUIQTEControls(qteIndicators);
			if (DialogueDebug.LogErrors) {
				if (DialogueDebug.LogWarnings) {
					if (dialogue.npcSubtitle.line == null) Debug.LogWarning(string.Format("{0}: UnityUIDialogueUI NPC Subtitle Line needs to be assigned.", DialogueDebug.Prefix));
					if (dialogue.pcSubtitle.line == null) Debug.LogWarning(string.Format("{0}: UnityUIDialogueUI PC Subtitle Line needs to be assigned.", DialogueDebug.Prefix));
					if (dialogue.responseMenu.buttons.Length == 0 && dialogue.responseMenu.buttonTemplate == null) Debug.LogWarning(string.Format("{0}: UnityUIDialogueUI Response buttons need to be assigned.", DialogueDebug.Prefix));
					if (alert.line == null) Debug.LogWarning(string.Format("{0}: UnityUIDialogueUI Alert Line needs to be assigned.", DialogueDebug.Prefix));
				}
			}
		}

		public override void ShowAlert(string message, float duration) {
			base.ShowAlert(message, duration);
			if (autoFocus) alert.AutoFocus();
			Invoke("HideAlert", duration);
		}

		public override void OnContinue() {
			CancelInvoke("HideAlert");
			base.OnContinue();
		}

		public override void ShowSubtitle(Subtitle subtitle) {
			base.ShowSubtitle(subtitle);
			if (autoFocus) {
				if (subtitle.speakerInfo.IsPlayer) {
					dialogue.pcSubtitle.AutoFocus();
				} else {
					dialogue.npcSubtitle.AutoFocus();
				}
			}
			HideResponses();
		}

		public override void ShowResponses (Subtitle subtitle, Response[] responses, float timeout) {
			base.ShowResponses(subtitle, responses, timeout);
			if (autoFocus) dialogue.responseMenu.AutoFocus();
		}

		public override void HideResponses() {
			dialogue.responseMenu.DestroyInstantiatedButtons();
			base.HideResponses();
		}

	}

}
