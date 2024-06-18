using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairRay : MonoBehaviour
{
    public RaycastHit hit;
    private Vector3 hmdWorld;
    [SerializeField] private Vector3 hmdParent;
    [SerializeField] private GameObject crosshair;
    private SpriteRenderer crosshairColor;
    public float skillDistance;
    private GameObject cross;

    public SkillsManager skillsManager;
    private bool onCrosshair = false;
    //private LineRenderer line;

    private void Start()
    {
        cross = Instantiate(crosshair);
        skillDistance = 50f;
        //line = GetComponent<LineRenderer>();
        crosshairColor = cross.GetComponent<SpriteRenderer>();
        //cross.gameObject.SetActive(false);
    }
    //public void StartShot()
    //{
    //    StartCoroutine(ShotUpdate());
    //}
    //private IEnumerator ShotUpdate()
    //{
    //    onCrosshair = true;
    //    cross.gameObject.SetActive(true);
    //    while (onCrosshair)
    //    {
    //        Shot();
    //        yield return null;
    //    }
    //}

    private void Update()
    {
        Shot();
    }
    //public void StopShot()
    //{
    //    onCrosshair = false;
    //    cross.gameObject.SetActive(false);
    //}
    private void Shot()
    {
        hmdWorld = hmdParent + transform.position;
        //Rayast(광선의 시작 지점, 광선이 뻗어나갈 방향 , 충돌 정보(out hit), 광선의 사정거리)
        if (Physics.Raycast(hmdWorld, transform.forward, out hit, skillDistance))
        {
            SetCrosshairRotation(hit);
            cross.transform.position = hit.point;
            //line.SetPosition(1, transform.InverseTransformPoint(hit.point));
            crosshairColor.color = Color.green;
        }
        else
        {
            hit.point = hmdWorld + transform.forward * skillDistance;
            cross.transform.position = hit.point;
            SetCrosshairRotation(hit);
            crosshairColor.color = Color.white;
        }
    }

    private void SetCrosshairRotation(RaycastHit _hit)
    {
        //바닥, 벽일경우
        if (_hit.transform.gameObject.CompareTag("wall"))
        {
            cross.transform.rotation = Quaternion.LookRotation(_hit.normal);
        }
        else if (_hit.transform.gameObject.CompareTag("Enemy"))
        {
            cross.transform.rotation = Quaternion.LookRotation(_hit.point - hmdWorld);
        }
    }
}
