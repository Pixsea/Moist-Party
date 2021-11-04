using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using System.Linq;



public class Controller : MonoBehaviour
{
#region PublicVariables
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
    /// The current binding name. is "Default" by default
    /// </summary>
    public string BindingName = "Default";
#endregion
#region PrivateVariables
    /// <summary>
    /// Keys are the Actions enum in ControlManager, values are the current string
    /// </summary>
    private Dictionary<Actions, string> _currentBindings = new Dictionary<Actions, string>();

    /// <summary>
    /// 
    /// </summary>
    private Dictionary<sticks, Vector2> lastStickDirections = new Dictionary<sticks, Vector2>() 
        {{sticks.leftStick, Vector2.zero}, {sticks.rightStick, Vector2.zero}, {sticks.dPad, Vector2.zero}};
#endregion
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
    public bool leftStickUp;
    
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
        leftStickUp = GetStickDirection(sticks.leftStick, Vector2.up);
        
        if (GetActionDown(Actions.Fire))
        {
            print("Firing!");
        }
        //Handle controller end of frame actions
        if (controllerNum > 0)
        {
            StartCoroutine(SetLastDown());
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
    /// Gets whether a stick is held in a particular direction that frame
    /// <para><b>Be aware, Unity registers a direction pressed with a stick only pressed about 10 degrees</b></para>
    /// </summary>
    /// <param name="stick">Which stick to get the input from
    /// <para>sticks.triggers will always return false</para></param>
    /// <param name="direction">The queried direction.
    /// <para>Uses Vector2.left, Vector2.right, Vector2.up, and Vector2.down</para></param>
    /// <returns>Returns if the stick is held in the given direction that frame</returns>
    public bool GetStickDirection(sticks stick, Vector2 direction)
    {
        //You cannot get the direction from triggers
        if (stick == sticks.triggers)
            return false;
        //Get the input from GetStick
        Vector2 input = GetStick(stick);
        //Then, we floor to int to eliminate half pushed values
        Vector2Int intInput = Vector2Int.FloorToInt(input);
        input = intInput;
        //45 degrees is not considered valid
        if (Math.Abs(input.x) == Math.Abs(input.y))
            return false;
        //The horizontal directions
        if (direction.x != 0)
        {
            //If the horiz input is 0 or less than the vertical input, return false
            if (input.x == 0 || Math.Abs(input.x) < Math.Abs(input.y))
                return false;
        }
        //The vertical directions
        if (direction.y != 0)
        {
            //If the vertical is 0 or less than the horizontal
            if (input.y == 0 || Math.Abs(input.y) < Math.Abs(input.x))
                return false;
        }
        //Once all invalid inputs have been checked for, return if the input matches the direction
        return (input == direction);
    }

    /// <summary>
    /// Moral equivalent of GetKeyDown, but for a stick and a direction
    /// Gets whether or a stick began being held in a direction that frame. Last value is set in
    /// <see cref="SetLastDown"/>
    /// </summary>
    /// <param name="stick">Which stick to get the input from
    /// <para>sticks.triggers will always return false</para></param>
    /// <param name="direction">The queried direction.
    /// <para>Uses Vector2.left, Vector2.right, Vector2.up, and Vector2.down</para></param>
    /// <returns>Returns if the stick began being held in the given direction that frame</returns>
    public bool GetStickDirectionDown(sticks stick, Vector2 direction)
    {
        //If the stick is not being held, always false
        if (GetStickDirection(stick, direction) == false)
            return false;
        //You cannot get the direction from triggers
        if (stick == sticks.triggers)
            return false;
        //Get the input from GetStick
        Vector2 input = GetStick(stick);
        //Then, we round to int to eliminate half pushed values
        Vector2Int intInput = Vector2Int.FloorToInt(input);
        input = intInput;
        //45 degrees is not considered valid
        if (Math.Abs(input.x) == Math.Abs(input.y))
            return false;
        return (lastStickDirections[stick] != input);
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
    /// <summary>
    /// Waits until the end of frame, and then sets all the last frame variables for GetButtonDown functions.
    /// Currently implemented:
    /// <list type="bullet">
    ///<item>triggers</item>
    /// <item>sticks</item>
    /// </list>
    /// </summary>
    /// <returns>yield returns WaitForEndOfFrame so that it's the last thing to run in any frame</returns>
    IEnumerator SetLastDown()
    {
        yield return new WaitForEndOfFrame();
        //Set the last triggers
        lastTriggers = GetStick(sticks.triggers);
        //Set each of the last sticks
        foreach (sticks stick in Enum.GetValues(typeof(sticks)))
        {
            Vector2 dir = GetStick(stick);
            //The direction needs to be floored
            dir = Vector2Int.FloorToInt(dir);
            lastStickDirections[stick] = dir;
        }
    }

    #endregion

}
