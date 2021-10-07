using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MultiInput
{
    public class ControlManager : MonoBehaviour
    {
        /// <summary>
        /// The HashSet of all keys that were first held down that frame
        /// </summary>
        public HashSet<KeyCode> KeysDown { get; private set; } = new HashSet<KeyCode>();

        /// <summary>
        /// The HashSet of all keys that were down that frame
        /// </summary>
        public HashSet<KeyCode> Keys { get; private set; } = new HashSet<KeyCode>();

        // Update is called once per frame
        void Update()
        {
            string held = "";
            ButtonsDown();
            if (string.IsNullOrEmpty(held) == false)
                print(held);
        }
        
        /// <summary>
        /// Gets the list of KeyCodes for all currently held down keys
        /// </summary>
        /// <returns>Returns a list of KeyCodes for all buttons that started being held down that frame</returns>
        private void ButtonsDown()
        {
            //iterate through every key
            foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
            {
                //If the key is held down and not currently in the list
                if (Input.GetKeyDown(key) && KeysDown.Contains(key) == false)
                {
                    KeysDown.Add(key);
                }
                //Remove from the list if not held down and in the list
                else if (KeysDown.Contains(key))
                {
                    KeysDown.Remove(key);
                }
            }
        }
    }

}
