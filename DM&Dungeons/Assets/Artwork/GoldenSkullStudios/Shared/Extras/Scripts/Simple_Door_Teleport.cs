using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_Door_Teleport : MonoBehaviour
{
    //
    [SerializeField] GameObject thisMap;
    [SerializeField] Transform thisTeleportTarget;
    //
    [SerializeField] Simple_Door_Teleport targetDoor;

    [SerializeField] KeyCode teleportKey = KeyCode.E;

    private bool canTeleport = false;
    private Collider2D collisionObject;
    //
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if( canTeleport )
        {
            DoTeleport();
        }
    }

    private void DoTeleport()
    {
        if (Input.GetKeyDown(teleportKey))
        {
            //check if this object has the doorAnimationScript
            Simple_Door_Script doorAnimationScript = this.GetComponent<Simple_Door_Script>();
            if (doorAnimationScript != null)
                doorAnimationScript.StopDoorCoroutines();
            //deactivate this map, activate the target map
            thisMap.SetActive(false);
            targetDoor.thisMap.SetActive(true);
            //if there is a position to teleport to - it goes here and we'll teleport the player there
            if (targetDoor.thisTeleportTarget != null)
            {
                Vector3 newPos = targetDoor.thisTeleportTarget.position;
                //we make sure that even if the teleport has been moved by accident
                newPos.z = 0;
                if (collisionObject == null)
                    GameObject.FindGameObjectWithTag("Player").transform.position = newPos;
                else
                    collisionObject.gameObject.transform.position = newPos;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canTeleport = true;
        collisionObject = collision;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTeleport = false;
        collisionObject = null;
    }
}
