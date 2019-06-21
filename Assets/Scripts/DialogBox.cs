using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogBox : MonoBehaviour {

    public GameObject mainBox;
    public TextMeshProUGUI nameField;
    public TextMeshProUGUI textField;
    public float textSpeed;

    private Dialog activeDialog;
    private int activeEntry;
    private int letterCounter;
    private bool shouldInteract;

    public void InitiateDialog(Dialog dialog) {
        this.activeDialog = dialog;
        this.activeEntry = 0;

        PlayerController.PauseMovement = true;
        this.mainBox.SetActive(true);
        this.PopulateEntry(0);

        this.StartCoroutine(this.HandleDialog());
    }

    private void Update() {
        if (this.activeDialog && Input.GetButtonDown("Interact"))
            this.shouldInteract = true;
    }

    private IEnumerator HandleDialog() {
        while (this.activeDialog) {
            yield return null;

            var entry = this.activeDialog.entries[this.activeEntry];
            if (this.letterCounter >= entry.sentence.Length) {
                if (this.shouldInteract) {
                    this.shouldInteract = false;
                    this.activeEntry++;
                    if (this.activeDialog.entries.Length <= this.activeEntry) {
                        this.activeDialog = null;
                        this.mainBox.SetActive(false);
                        PlayerController.PauseMovement = false;
                    } else {
                        this.PopulateEntry(this.activeEntry);
                    }
                }
            } else {
                if (this.shouldInteract) {
                    this.shouldInteract = false;
                    this.letterCounter = entry.sentence.Length;
                } else {
                    this.letterCounter++;
                }
                this.textField.maxVisibleCharacters = this.letterCounter;
                yield return new WaitForSeconds(this.textSpeed);
            }
        }
    }

    private void PopulateEntry(int entryNumber) {
        var entry = this.activeDialog.entries[entryNumber];
        this.nameField.text = entry.name;
        this.textField.text = entry.sentence;
        this.textField.maxVisibleCharacters = 0;
        this.letterCounter = 0;
    }

}