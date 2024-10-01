using UnityEngine;

public class GeneratePlatform : MonoBehaviour
{
    //[SerializeField] private GameObject[] m_platform;
    private MeshRenderer m_platformMeshRend;

    private GameObject playerCapsule;


    private void Start()
    {
        playerCapsule = new GameObject("capsule");
        playerCapsule.transform.position = Vector3.zero;
        for (int i = 0; i < 20; i++)
        {
            //int randomPlatform = Random.Range(0, m_platform.Length);
            GameObject platform = PlatformPool.Instance.GetPlatform();
            if (platform == null) return;

            platform.SetActive(true);
            platform.transform.SetPositionAndRotation(playerCapsule.transform.position,playerCapsule.transform.rotation);
            if (platform.CompareTag("StairsUp"))
            {
               playerCapsule.transform.Translate(0,5f,0);
            }
            else if (platform.CompareTag("StairsDown"))
            {
                playerCapsule.transform.Translate(0,-5f,0);
                platform.transform.Rotate(0, 180f, 0);
                platform.transform.position = playerCapsule.transform.position;
            }
            else if (platform.CompareTag("PlatformTSection"))
            {
                int randomTurn = Random.Range(0, 5);
                if (randomTurn == 3)                
                    playerCapsule.transform.Rotate(0, 90f, 0);                
                else                
                    playerCapsule.transform.Rotate(0, -90f, 0);
                playerCapsule.transform.Translate(Vector3.forward * -10f);                
               
            }
            playerCapsule.transform.Translate(0, 0, - 10f);

        }
    }
  
    void Update()
    {

    }
}
