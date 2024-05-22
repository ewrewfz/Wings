using Oculus.Interaction.PoseDetection;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 포즈 가져오기
    public ShapeRecognizerActiveState[] poseDetector;

    // 스킬의 지속시간
    [HideInInspector] public float skillDuration = 2f;

    // 스킬 사용중임?
    bool skillLaunched = false;

    // 스와이프 기능 추가하려고 넣음 추후에 SDK 더 뜯어보고 거기 기능 사용 가능하면 쓸 예정
    public OVRCameraRig cameraRig;

    // 스킬 나갈 위치 잡아주는 옵젝
    public GameObject handPos;

    [SerializeField] private SkillsManager skillManager;

    // 손이 얼마나 멀어져야 스킬 나갈거?
    public float distanceThreshold = 1.0f;
    // 스킬이 내 기준으로 어느정도 떨어져서 나갈거?
    public float skillSpawnDistance = 10.0f;
    // 스킬에 가해질 힘
    public float skillForce = 20.0f;
    //스킬을 담는 박스
    public GameObject skillBox;

    private void Start()
    {
        handPos = GameObject.FindWithTag("R_Hand").transform.gameObject;
    }

    private void Update()
    {
        //if (poseDetector[0].Active && skillLaunched == false)
        //    useSkill(skillManager.SkillSet[0]);

        //else if (poseDetector[1].Active)
        //    useSkill(skillManager.SkillSet[1]);
        
    }

    public void useSkill(GameObject _skill)
    {
        Debug.Log("스킬 발동.");
        skillLaunched = true;
        Instantiate(_skill, transform.position, Quaternion.identity);

        StartCoroutine(DestroySkillAfterDuration());
    }


    IEnumerator DestroySkillAfterDuration()
    {
        // 스킬 지속 시간만큼 대기
        yield return new WaitForSeconds(skillDuration);

        // 파괴
        skillLaunched = false;
    }

}
