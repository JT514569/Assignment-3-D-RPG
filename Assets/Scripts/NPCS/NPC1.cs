using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{

    public class NPC1 : MonoBehaviour
    {
        public GameObject TriggerText;
        public GameObject DialogueObject;
        public RigidbodyFirstPersonController rigid;
        public bool hasTalked = false;

        private void OnTriggerStay(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                TriggerText.SetActive(true);

                 //Detect when the E arrow key is pressed down
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("E key was pressed.");
                    if(!hasTalked)
                    {
                        other.gameObject.GetComponent<PlayerData>().DialogueNumber = 1;
                        DialogueObject.SetActive(true);
                        rigid.enabled = false;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        TriggerText.SetActive(false);
                    }
                    else
                    {
                        other.gameObject.GetComponent<PlayerData>().DialogueNumber = 1.5f;
                        DialogueObject.SetActive(true);
                        rigid.enabled = false;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        TriggerText.SetActive(false);
                    }
                }


                //Detect when the E arrow key has been released
                if (Input.GetKeyUp(KeyCode.E))
                {
                    Debug.Log("E key was released.");
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            TriggerText.SetActive(false);
            DialogueObject.SetActive(false);
        }
    }
    
}
