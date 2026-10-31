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
    private NPC _target;

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

        if((_target != null) && _target.CanSee())
        {
            textPanel.SetActive(true);
        } else {
            textPanel.SetActive(false);
        }


    }

    public void SetTarget(NPC npc)
    {

            _target = npc;
            textPanel.transform.Find("Portrait").GetComponent<Image>().sprite = npc.person.portrait;
            textPanel.transform.Find("Body").GetComponent<TMP_Text>().text = npc.person.chatter;
            textPanel.transform.Find("Title").GetComponent<TMP_Text>().text = npc.person.longname;
    }
}
