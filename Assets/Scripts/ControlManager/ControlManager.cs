using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Left stick, right stick, and the dPad
/// </summary>
public enum sticks
{
    leftStick,
    rightStick,
    dPad,
    triggers
}

/// <summary>
/// All of the in game actions. Buttons are bound to this
/// </summary>
public enum Actions
{
    Mash,
    Fire
}

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
        
        /// <summary>
        /// The list of held down keys, for debug purposes
        /// </summary>
        [SerializeField]
        public List<KeyCode> downList = new List<KeyCode>();

        public Vector2 leftStick;

        // Update is called once per frame
        void Update()
        {
            GetButtonsPressed();
            downList = Keys.ToList();
            leftStick.x = Input.GetAxis("HorizontalTest");
            leftStick.y = Input.GetAxis("VerticalTest");

        }
        
        /// <summary>
        /// Updates the lists of both GetKey and GetKeyDown that frame
        /// </summary>
        private void GetButtonsPressed()
        {
            //iterate through every key
            foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
            {
                //If the key is was first held down this frame and not currently in the list
                if (Input.GetKeyDown(key) && KeysDown.Contains(key) == false)
                {
                    KeysDown.Add(key);
                }
                //Remove from the list if not held down and in the list
                else if (KeysDown.Contains(key) && Input.GetKeyDown(key))
                {
                    KeysDown.Remove(key);
                }
                //If the key is held down and not currently in the list
                if (Input.GetKey(key) && Keys.Contains(key) == false)
                {
                    Keys.Add(key);
                }
                //Remove from the list if not held down and in the list
                else if (Keys.Contains(key) && Input.GetKey(key) == false)
                {
                    Keys.Remove(key);
                }
            }
        }
        
    }

}
