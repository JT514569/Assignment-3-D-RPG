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

        private void OnTriggerStay(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                TriggerText.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    DialogueObject.SetActive(true);
                    other.gameObject.GetComponent<PlayerData>().DialogueNumber = 1;
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