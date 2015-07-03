using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

namespace PixelCrushers.DialogueSystem {

	/// <summary>
	/// This component hooks up the elements of a Unity UI quest template.
	/// Add it to your quest template and assign the properties.
	/// </summary>
	public class UnityUIQuestTemplate : MonoBehaviour	{

		public Button heading;

		public Text description;

		public Text entryDescription;

		public Button trackButton;

		public Button abandonButton;

		public bool ArePropertiesAssigned {
			get {
				return (heading != null) &&
					(description != null) && (entryDescription != null) &&
					(trackButton != null) && (abandonButton != null);
			}
		}

	}

}
