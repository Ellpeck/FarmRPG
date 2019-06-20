using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogBox : MonoBehaviour {

    public GameObject mainBox;
    public TextMeshProUGUI nameField;
    public TextMeshProUGUI textField;

    private Dialog activeDialog;
    private int activeEntry;

    public void InitiateDialog(Dialog dialog) {
        this.activeDialog = dialog;
        this.activeEntry = 0;

        PlayerController.PauseMovement = true;
        this.mainBox.SetActive(true);
        this.PopulateEntry(0);
        
        this.StartCoroutine(this.HandleDialog());
    }

    private IEnumerator HandleDialog() {
        while (this.activeDialog) {
            yield return null;
            
            if (Input.GetButtonDown("Interact")) {
                this.activeEntry++;
                if (this.activeDialog.entries.Length <= this.activeEntry) {
                    this.activeDialog = null;
                    this.mainBox.SetActive(false);
                    PlayerController.PauseMovement = false;
                } else {
                    this.PopulateEntry(this.activeEntry);
                }
            }
        }
    }

    private void PopulateEntry(int entryNumber) {
        var entry = this.activeDialog.entries[entryNumber];
        this.nameField.text = entry.name;
        this.textField.text = entry.sentence;
    }

}