using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog")]
public class Dialog : ScriptableObject {

    public DialogEntry[] entries;

    public void Initiate() {
        FindObjectOfType<DialogBox>().InitiateDialog(this);
    }

}

[Serializable]
public class DialogEntry {

    public string name;
    [TextArea] public string sentence;

}