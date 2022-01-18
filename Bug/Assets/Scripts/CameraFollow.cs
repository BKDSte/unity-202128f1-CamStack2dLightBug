using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    private PlayerMover thisPlayerMover;
    public enum CameraMovementType
    {
        Static,
        FollowPlayerPrecisly,
        FollowPlayerWithLerp,
        FollowPlayerWithMoveTowards
    }
    public CameraMovementType thisCameraMovementType = CameraMovementType.FollowPlayerWithLerp;
    public enum UpdateType
    {
        Update,
        LateUpdate,
        FixedUpdate
    }
    public UpdateType thisUpdateType = UpdateType.Update;
    public float FollowSpeed = 4;
    private float currentFollowSpeed;

    private void Awake()
    {
        thisPlayerMover = Target.gameObject.GetComponent<PlayerMover>();
    }

    void FixedUpdate()
    {
        if (thisUpdateType == UpdateType.FixedUpdate)
        {
            switch (thisCameraMovementType)
            {
                case CameraMovementType.Static:
                    // do nothing
                    break;
                case CameraMovementType.FollowPlayerPrecisly:
                    transform.position = new Vector3(Target.position.x, Target.position.y, transform.position.z);
                    break;               
                case CameraMovementType.FollowPlayerWithLerp:
                    currentFollowSpeed = FollowSpeed;
                    transform.position = new Vector3(Mathf.Lerp(transform.position.x, Target.position.x, Time.fixedDeltaTime * currentFollowSpeed),
                                                     Mathf.Lerp(transform.position.y, Target.position.y, Time.fixedDeltaTime * currentFollowSpeed),
                                                     transform.position.z);
                    break;
                case CameraMovementType.FollowPlayerWithMoveTowards:
                    currentFollowSpeed = FollowSpeed * 2;
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(Target.position.x, Target.position.y, transform.position.z), Time.fixedDeltaTime * currentFollowSpeed);
                    break;
            }
        }
    }

    void Update()
    {
        if (thisUpdateType == UpdateType.Update)
        {
            switch (thisCameraMovementType)
            {
                case CameraMovementType.Static:
                    break;
                case CameraMovementType.FollowPlayerPrecisly:
                    transform.position = new Vector3(Target.position.x, Target.position.y, transform.position.z);
                    break;                
                case CameraMovementType.FollowPlayerWithLerp:
                    currentFollowSpeed = FollowSpeed;
                    transform.position = new Vector3(Mathf.Lerp(transform.position.x, Target.position.x, Time.deltaTime * currentFollowSpeed),
                                                     Mathf.Lerp(transform.position.y, Target.position.y, Time.deltaTime * currentFollowSpeed),
                                                     transform.position.z);
                    break;
                case CameraMovementType.FollowPlayerWithMoveTowards:
                    currentFollowSpeed = FollowSpeed * 2;
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(Target.position.x, Target.position.y, transform.position.z), Time.deltaTime * currentFollowSpeed);
                    break;
            }
        }
    }

    void LateUpdate()
    {
        if (thisUpdateType == UpdateType.LateUpdate)
        {
            switch (thisCameraMovementType)
            {
                case CameraMovementType.Static:
                    break;
                case CameraMovementType.FollowPlayerPrecisly:
                    transform.position = new Vector3(Target.position.x, Target.position.y, transform.position.z);
                    break;                
                case CameraMovementType.FollowPlayerWithLerp:
                    currentFollowSpeed = FollowSpeed;
                    transform.position = new Vector3(Mathf.Lerp(transform.position.x, Target.position.x, Time.deltaTime * currentFollowSpeed),
                                                     Mathf.Lerp(transform.position.y, Target.position.y, Time.deltaTime * currentFollowSpeed),
                                                     transform.position.z);
                    break;
                case CameraMovementType.FollowPlayerWithMoveTowards:
                    currentFollowSpeed = FollowSpeed * 2;
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(Target.position.x, Target.position.y, transform.position.z), Time.deltaTime * currentFollowSpeed);
                    break;
            }
        }
    }
}