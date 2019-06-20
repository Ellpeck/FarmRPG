using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour {

    public InteractEvent onInteract;
    public Dialog initiatedDialog;

    public void Interact(Character character) {
        this.onInteract.Invoke(character);
        if (this.initiatedDialog)
            this.initiatedDialog.Initiate();
    }

}

[Serializable]
public class InteractEvent : UnityEvent<Character> {

}