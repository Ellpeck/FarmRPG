using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour {

    public InteractEvent onInteract;

    public void Interact(Character character) {
        this.onInteract.Invoke(character);
    }

}

[Serializable]
public class InteractEvent : UnityEvent<Character> {

}