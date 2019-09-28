using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FindPlayer : MonoBehaviour
{
    private CinemachineStateDrivenCamera c_VirtualCamera;
    [SerializeField] GameObject PlayerLain;

    private void Awake()
    {
        c_VirtualCamera = GetComponent<CinemachineStateDrivenCamera>();
        Debug.Log("passed camera awake test");
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerLain == null)
        {
            PlayerLain = GameObject.FindWithTag("Player");
            if ((PlayerLain != null)&&(c_VirtualCamera != null))
            {
                Transform Target = PlayerLain.transform;
               // c_VirtualCamera.LookAt = Target;
                c_VirtualCamera.Follow = Target;
            }
        }
    }
}
