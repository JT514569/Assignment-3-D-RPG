using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [Serializable]
public class DialogueOBJ
{
    public string[] Dialogues;
    public string CharacterName;
    public int questNumber;
}

public class NPC
{
    public bool hasTalked;    
}



    public class DialogueObject : MonoBehaviour
    {
        public PlayerData data;

        public TextMeshProUGUI nameText;
        public TextMeshProUGUI DialogueText;
        public RigidbodyFirstPersonController rigid;


        private int currentDialogueNum = 0;
        private DialogueOBJ curDialogue = null;

        [Header("Dialogue objects")]

        public DialogueOBJ dialogue1;
        public DialogueOBJ dialogue105;

        [Header("NPCs")]

        public NPC npc1;


        private void OnEnable()
        {
            switch (data.DialogueNumber)
            {
                case 1:
                    PlayDialogue(dialogue1);
                    curDialogue = dialogue1;
                    break;
                case 1.5f:
                    PlayDialogue(dialogue105);
                    curDialogue = dialogue105;
                    break;
            }
        }

        void PlayDialogue(DialogueOBJ tempobj)
        {
            nameText.text = tempobj.CharacterName;
            if (currentDialogueNum < tempobj.Dialogues.Length)
            {
                DialogueText.text = tempobj.Dialogues[currentDialogueNum];
            }
            else
            {
                rigid.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                switch (data.DialogueNumber)
                {
                    case 1:
                        npc1.hasTalked = true;
                        break;
                }
                data.DialogueNumber = 0;
                currentDialogueNum = 0;
                data.questNumber = curDialogue.questNumber;
                curDialogue = null;
                this.gameObject.SetActive(false);
            }
        }

        public void next()
        {
            if (curDialogue != null)
            {
                currentDialogueNum++;
                PlayDialogue(curDialogue);
            }
        }


    }
}