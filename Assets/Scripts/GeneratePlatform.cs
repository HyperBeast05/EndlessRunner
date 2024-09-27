using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] m_platform;
    private MeshRenderer m_platformMeshRend;

    private GameObject playerCapsule;
    private void Awake()
    {
        playerCapsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
       playerCapsule.transform.position= Vector3.zero;
        for (int i = 0; i < 20; i++)
        {
            int randomPlatform = Random.Range(0, m_platform.Length);
            GameObject platform = Instantiate(m_platform[randomPlatform],playerCapsule.transform.position,playerCapsule.transform.rotation);           

            if (platform.CompareTag("PlatformTSection"))
            {
                Debug.Log("platformtsection");
                int randomTurn = Random.Range(0, 5);
                if (randomTurn == 3)
                {
                    playerCapsule.transform.Rotate(0, 90, 0);
                }
                else
                {

                    playerCapsule.transform.Rotate(0, -90, 0);
                }
            }
            Vector3 newPosition = playerCapsule.transform.position;
            //platform.transform.Translate(new Vector3(0,0,playerCapsule.transform.position.z));
            m_platformMeshRend = platform.GetComponent<MeshRenderer>();
            float height =m_platformMeshRend.bounds.size.z;

            newPosition.z -= height;
            playerCapsule.transform.position = newPosition;
        }
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
