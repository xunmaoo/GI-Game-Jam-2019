using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject NameTag;
    public int indexDialogue;
    public int lengthDialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            NameTag.GetComponent<TextMesh>().color = Color.white;

            if (Input.GetKeyDown(KeyCode.E))
            {
                Dialogue.index = indexDialogue;
                Dialogue.index_start = indexDialogue;
                Dialogue.conversationLength = lengthDialogue;
                PlayerMovement.playerLocked = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        NameTag.GetComponent<TextMesh>().color = Color.yellow;
    }
}
