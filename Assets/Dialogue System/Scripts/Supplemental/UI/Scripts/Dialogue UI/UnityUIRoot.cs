﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace PixelCrushers.DialogueSystem {

	/// <summary>
	/// Unity UI UIRoot wrapper for AbstractUIRoot.
	/// </summary>
	[System.Serializable]
	public class UnityUIRoot : AbstractUIRoot {
		
		//private UIRoot uiRoot;

		//private bool deactivateWhenHidden = true;
		
		//public NGUIUIRoot(UIRoot uiRoot, bool deactivateWhenHidden) {
		//	this.uiRoot = uiRoot;
		//	this.deactivateWhenHidden = deactivateWhenHidden;
		//}
		
		/// <summary>
		/// Shows the root.
		/// </summary>
		public override void Show() {
		//	if (deactivateWhenHidden && uiRoot != null) uiRoot.gameObject.SetActive(true);
		}
		
		/// <summary>
		/// Hides the root.
		/// </summary>
		public override void Hide() {
		//	if (deactivateWhenHidden && uiRoot != null) uiRoot.gameObject.SetActive(false);
		}
		
	}

}
