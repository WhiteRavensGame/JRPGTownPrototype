using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PixelCrushers.DialogueSystem {
	
	/// <summary>
	/// Contains all dialogue (conversation) controls for a Unity UI Dialogue UI.
	/// </summary>
	[System.Serializable]
	public class UnityUIDialogueControls : AbstractDialogueUIControls {
		
		/// <summary>
		/// The panel containing the dialogue controls. A panel is optional, but you may want one
		/// so you can include a background image, panel-wide effects, etc.
		/// </summary>
		public Graphic panel;
		
		/// <summary>
		/// The NPC subtitle controls.
		/// </summary>
		public UnityUISubtitleControls npcSubtitle;
		
		/// <summary>
		/// The PC subtitle controls.
		/// </summary>
		public UnityUISubtitleControls pcSubtitle;
		
		/// <summary>
		/// The response menu controls.
		/// </summary>
		public UnityUIResponseMenuControls responseMenu;
		
		public override AbstractUISubtitleControls NPCSubtitle { 
			get { return npcSubtitle; }
		}
		
		public override AbstractUISubtitleControls PCSubtitle {
			get { return pcSubtitle; }
		}
		
		public override AbstractUIResponseMenuControls ResponseMenu {
			get { return responseMenu; }
		}
		
		public override void ShowPanel() {
			if (panel != null) Tools.SetGameObjectActive(panel, true);
		}
		
		public override void SetActive(bool value) {
			base.SetActive(value);
			if (panel != null) Tools.SetGameObjectActive(panel, value);
		}

	}
		
}
