using Ink.Runtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InkTest : MonoBehaviour
{
    // Start is called before the first frame update

    private Story story;
    [SerializeField] private TextAsset textAsset;
    [SerializeField] private TextMeshProUGUI text;

    void Start()
    {
        story = new Story(textAsset.text);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            text.text = story.Continue();
        }
    }
}
