using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_Door_Script : MonoBehaviour
{
    [SerializeField] private float stateChangeDelay = 0.2f;
    //The different states the door can have
    public enum DoorState { Open, SemiOpen, Closed, Locked };
    [SerializeField] private DoorState default_doorstate = DoorState.Closed;

    //GameObjects that contain the set-up for each doorstate
    [SerializeField] private GameObject closed_StateObject;
    [SerializeField] private GameObject semiOpen_StateObject;
    [SerializeField] private GameObject open_StateObject;

    //Managing the door states
    private void UpdateState(DoorState _doorState )
    {
        switch(_doorState)
        {
            case DoorState.Closed:
                closed_StateObject.SetActive(true);
                semiOpen_StateObject.SetActive(false);
                open_StateObject.SetActive(false);
                break;
            case DoorState.SemiOpen:
                closed_StateObject.SetActive(false);
                semiOpen_StateObject.SetActive(true);
                open_StateObject.SetActive(false);
                break;
            case DoorState.Open:
                closed_StateObject.SetActive(false);
                semiOpen_StateObject.SetActive(false);
                open_StateObject.SetActive(true);
                break;
            case DoorState.Locked:
                closed_StateObject.SetActive(true);
                semiOpen_StateObject.SetActive(false);
                open_StateObject.SetActive(false);
                break;
        }
    }

    //
    void Start()
    {
        UpdateState(default_doorstate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( default_doorstate != DoorState.Open && default_doorstate != DoorState.Locked )
        {
            if (this.gameObject.activeInHierarchy)
                StartCoroutine(WaitToOpenDoor());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (default_doorstate != DoorState.Open && default_doorstate != DoorState.Locked)
        {
            if( this.gameObject.activeInHierarchy )
                StartCoroutine(WaitToCloseDoor());
        }
    }

    public void StopDoorCoroutines()
    {
        StopCoroutine((WaitToCloseDoor()));
        StopCoroutine((WaitToOpenDoor()));
    }

    IEnumerator WaitToOpenDoor()
    {
        UpdateState(DoorState.SemiOpen);
        yield return new WaitForSeconds(stateChangeDelay);
        UpdateState(DoorState.Open);
    }

    IEnumerator WaitToCloseDoor()
    {
        UpdateState(DoorState.SemiOpen);
        yield return new WaitForSeconds(stateChangeDelay);
        UpdateState(DoorState.Closed);
    }
}
