using UnityEngine;

public class RightHandFollow : MonoBehaviour
{
    private GameObject righthandPos;
    private void Start()
    {
        righthandPos = GameObject.FindWithTag("R_Hand").transform.gameObject;
        transform.SetParent(righthandPos.transform);
    }
}
