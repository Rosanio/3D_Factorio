using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int MapWidth = 16;
    [SerializeField] int MapDepth = 16;
    [SerializeField] GameObject Dirt;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        MeshRenderer CubeRenderer = Dirt.GetComponent<MeshRenderer>();
        float CubeWidth = CubeRenderer.bounds.size.x;
        float CubeDepth = CubeRenderer.bounds.size.z;

        for (int x = 0; x < MapWidth; x++)
        {
            for (int z = 0; z < MapDepth; z++)
            {
                Vector3 CubePosition = new Vector3(CubeWidth * x, 0, CubeDepth * z);
                Instantiate(Dirt, CubePosition, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
