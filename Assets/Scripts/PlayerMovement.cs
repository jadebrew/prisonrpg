using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    InputAction moveAction;
    InputAction jumpAction;
    Rigidbody _rigidbody;
    public float _thrust;

    public GameObject textPanel;

    private void Start()
    {
        //get the right components from the player object
        moveAction = InputSystem.actions.FindAction("Move");
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        //see if moveAction isnt zero and add as force the players rigidbody
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        if (moveValue != Vector2.zero)
        {
            _rigidbody.AddForce(new Vector3(moveValue.x,0,moveValue.y) * _thrust);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var person = other.GetComponent<NPC>().person;
        textPanel.SetActive(true);
        textPanel.transform.Find("Portrait").GetComponent<Image>().sprite = person.portrait;
        textPanel.transform.Find("Body").GetComponent<TMP_Text>().text = person.chatter;
        textPanel.transform.Find("Title").GetComponent<TMP_Text>().text = person.longname;

    }

    private void OnTriggerExit(Collider other)
    {
        textPanel.SetActive(false);
    }
}
