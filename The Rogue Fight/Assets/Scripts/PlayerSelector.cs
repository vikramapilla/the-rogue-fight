using UnityEngine;
using TMPro;


// Purpose: Character Selection for the Fight
// Component: Player Character Selection

public class PlayerSelector : MonoBehaviour
{
    #region Editor Variables

    [SerializeField] private EnumHelper.Player _inputType;  // to determine player input type
    [SerializeField] private TMP_Text _selectionText; // text display of the character name

    #endregion

    #region Class Variables

    private InputManager _playerInput;      // InputManager variable to set controls

    private int _characterID;               // current selected character
    private int _characterCount;            // total available characters
    
    #endregion

    private void Awake()
    {
        // initialize a random character from the available
        _characterCount = transform.childCount;
        _characterID = Random.Range(0, _characterCount);

        _playerInput = new InputManager(_inputType);
    }

    private void Start()
    {
        // disable all the characters
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.SetActive(false);
        }

        // enable only the selected character at the Awake()
        EnableCharacter();
    }

    private void Update()
    {
        ChangeCharacter();
    }

    private void ChangeCharacter()
    {
        // switch character to the left
        if (Input.GetKeyDown(_playerInput.Left))
        {
            DisableCharacter();

            _characterID--;

            // ensure characterID doesn't go below 0
            if (_characterID < 0)
            {
                _characterID = _characterCount - 1;
            }

            EnableCharacter();
        }

        // switch character to the right
        if (Input.GetKeyDown(_playerInput.Right))
        {
            DisableCharacter();

            _characterID++;

            _characterID = _characterID % _characterCount;

            EnableCharacter();
        }
    }

    private void EnableCharacter()
    {
        GameObject child;

        child = transform.GetChild(_characterID).gameObject;
        child.SetActive(true);

        // display the current selected character name
        _selectionText.text = child.name;
    }

    private void DisableCharacter()
    {
        GameObject child;

        child = transform.GetChild(_characterID).gameObject;
        child.SetActive(false);
    }

}
