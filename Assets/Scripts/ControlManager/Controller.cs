using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using System.Linq;



public class Controller : MonoBehaviour
{
    
    //TRIGGERS ARE AXIS 3, -1 for left and 1 for right

    /// <summary>
    /// The list of all currently connected controllers
    /// </summary>
    public static List<Controller> controllerList { get; private set; } = new List<Controller>();
    /// <summary>
    /// Controller numbering starts at 1
    /// <para>0 is reserved for keyboard and mouse</para>
    /// </summary>
    public int controllerNum = 1;
    /// <summary>
    /// Keys are the Actions enum in ControlManager, values are the current string
    /// </summary>
    private Dictionary<Actions, string> _currentBindings = new Dictionary<Actions, string>();
    /// <summary>
    /// The current binding name. is "Default" by default
    /// </summary>
    public string BindingName = "Default";
    public float deadZone = 0.2f;

    #region InternalVariables
    /// <summary>
    /// The last values for the triggers, for GetActionDown
    /// </summary>
    private Vector2 lastTriggers = Vector2.zero;
    
    #endregion
    [SerializeField] 
    public Vector2 leftStick;
    public Vector2 rightStick;
    public Vector2 dPad;
    public Vector2 triggers;
    public bool aDown;
    public bool fireHeld;
    
    // Start is called before the first frame update
    void Start()
    {
        _SetBinding();
    }

    // Update is called once per frame
    void Update()
    {
        leftStick = GetStick(sticks.leftStick);
        rightStick = GetStick(sticks.rightStick);
        dPad = GetStick(sticks.dPad);
        triggers = GetStick(sticks.triggers);
        aDown = GetAction(Actions.Mash);
        fireHeld = GetAction(Actions.Fire);
        if (GetActionDown(Actions.Fire))
        {
            print("Firing!");
        }
        //Handle controller end of frame actions
        if (controllerNum > 0)
        {
            StartCoroutine(SetLastTriggers());
        }
    }

    #region ExternalFunctions
    /// <summary>
    /// The function to get a controller's given stick value
    /// Left, Right, dPad, triggers
    /// <para>Triggers x is left trigger, y is right</para>
    /// </summary>
    /// <param name="stick">Which stick values to get</param>
    /// <returns>Returns the combined Vector2 of the stick's directions</returns>
    public Vector2 GetStick(sticks stick)
    {
        if (stick == sticks.triggers)
        {
            float ltrigger = Input.GetAxis($"leftTrigger_{controllerNum.ToString()}");
            float rtrigger = Input.GetAxis($"rightTrigger_{controllerNum.ToString()}");
            return new Vector2(ltrigger, rtrigger);
        }
        //Gets the horizontal and vertical components of the given stick
        string direction = "Vertical";
        string axisName = $"{stick}{direction}_{controllerNum.ToString()}";
        float vert = Input.GetAxis(axisName);
        direction = "Horizontal";
        direction = "Horizontal";
        axisName = $"{stick}{direction}_{controllerNum.ToString()}";
        float horiz = Input.GetAxis(axisName);
        if (Math.Abs(horiz) <= deadZone)
            horiz = 0;
        if (Math.Abs(vert) <= deadZone)
            vert = 0;
        
        Vector2 output = new Vector2(horiz, vert);

        return output;
    }
    /// <summary>
    /// Gets whether the given Action is being held down
    /// </summary>
    /// <param name="action">The action to query </param>
    /// <returns>Returns Input.GetKey for the given Action</returns>
    public bool GetAction(Actions action)
    {
        string binding = _currentBindings[action];
        //Gets the keycode if it exists
        KeyCode key = GetBinding(binding);
        if (key != KeyCode.None)
        {
            return Input.GetKey(key);
        }
        else
        {
            //left trigger
            if (binding == "lt")
            {
                string ltString = $"leftTrigger_{controllerNum}";
                if (Input.GetAxis(ltString) == 0)
                    return false;
                return true;
            }

            if (binding == "rt")
            {
                string rtString = $"rightTrigger_{controllerNum}";
                if (Input.GetAxis(rtString) == 0)
                    return false;
                return true;
            }
                
            return false;
        }
        //Multiple actions can map to the same button
        //return Input.GetKey(_currentBindings[action]);
    }
    /// <summary>
    /// Gets whether the given Action started being held this frame
    /// </summary>
    /// <param name="action">The action to query </param>
    /// <returns>Returns Input.GetKeyDown for the given Action</returns>
    public bool GetActionDown(Actions action)
    {
        string binding = _currentBindings[action];
        //Gets the keycode if it exists
        KeyCode key = GetBinding(binding);
        if (key != KeyCode.None)
        {
            return Input.GetKeyDown(key);
        }
        else
        {
            //Return if the triggers started being held down this time
            Vector2 triggers = GetStick(sticks.triggers);
            if (binding == "lt")
            {
                //if the trigger started being held down this frame
                return (lastTriggers.x == 0f && triggers.x == 1f);
            }
            if (binding == "rt")
            {
                //if the trigger started being held down this frame
                return (lastTriggers.y <= 0.5f && triggers.y >= 0.5f);
            }
        }
        //Multiple actions can map to the same button
        return Input.GetKeyDown(_currentBindings[action]);
    }
    #endregion

    #region InternalFunctions

    /// <summary>
    /// Sets the _currentBindings dict to the binding file at the BindingName path
    /// </summary>
    private void _SetBinding()
    {
        _currentBindings = new Dictionary<Actions, string>();
        if (controllerNum == 0)
        {
            BindingName = "DefaultKeyboard";
        }
        string path = $"ControllerProfiles/{BindingName}";
        TextAsset bindingText = Resources.Load<TextAsset>(path);
        foreach (string line in bindingText.text.Split('\n'))
        {
            //skip empty lines
            if (string.IsNullOrEmpty(line.Trim()))
                continue;
            //skip comments
            if (line.Trim().StartsWith("#"))
                continue;
            string actionString = line.Split(':')[0].Trim();
            string button = line.Split(':')[1].Trim();
            Actions action = (Actions)Enum.Parse(typeof(Actions), actionString);
            
            _currentBindings.Add(action, button);
        }
    }
    /// <summary>
    /// A helper function to get the KeyCode from a binding string
    /// </summary>
    /// <param name="bindingString"></param>
    /// <returns>Returns the proper key code if it exists, None otherwise</returns>
    private KeyCode GetBinding(string bindingString)
    {
        KeyCode binding = KeyCode.None;
        //triggers are always None
        if (bindingString == "rt" || bindingString == "lt")
        {
            return binding;
        }
        
        else if (controllerNum > 0)
        {
            string input = $"Joystick{controllerNum}Button{bindingString}";
            try
            {
                binding = (KeyCode) Enum.Parse(typeof(KeyCode), input);
                return binding;
            }
            catch (ArgumentException)
            {
                binding = KeyCode.None;
            }
        }

        return binding;
    }
    IEnumerator SetLastTriggers()
    {
        yield return new WaitForEndOfFrame();
        lastTriggers = GetStick(sticks.triggers);
    }

    #endregion

}
