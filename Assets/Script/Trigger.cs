using UnityEngine;
using Oculus.Interaction.PoseDetection;
using System.Collections;
using Unity.VisualScripting;

public class Trigger : MonoBehaviour
{
    // 포즈 가져오기
    public ShapeRecognizerActiveState poseDetector;

    // 발동할 스킬의 프리펩
    public GameObject skillPrefab;

    // 스킬 지속 시간
    public float skillDuration = 5f;

    // 스킬 사용하는지 체크
    bool skillLaunched = false;

    public OVRCameraRig cameraRig;



    public GameObject handPos;


    GameObject skillInstance;

    public float distanceThreshold = 1.0f;

    public float skillSpawnDistance = 10.0f;

    public float skillForce = 20.0f; // 스킬에 가해질 힘

    private void Start()
    {
       
        handPos = GameObject.FindWithTag("R_Hand").transform.gameObject;
        
    }

    void Update()
    {

        // 포즈가 감지되고 스킬이 발동되지 않은 경우에만 실행
        if (poseDetector.Active && !skillLaunched && IsHandFarEnough())
        {
            Debug.Log("스킬발사");
            // 감지 되었다
            LaunchSkill(handPos.transform.position);
        }
    }

    bool IsHandFarEnough()
    {
        // 스와이프 거리 측정
        float distance = Vector3.Distance(cameraRig.transform.position, transform.position);
        return distance >= distanceThreshold;
    }

    void LaunchSkill( Vector3 spawnPos)
    {
        Debug.Log("스킬발사 중");

        // handPos의 로컬 forward 방향을 기준으로 발사 방향을 계산합니다.
        Vector3 localForward = handPos.transform.forward;

        // handPos의 로컬 forward 방향을 기준으로 발사 위치를 계산합니다.
        Vector3 localShootPosition = localForward * skillSpawnDistance;

        // localShootPosition을 world space로 변환하여 실제 발사 위치를 계산합니다.
        Vector3 shootPosition = handPos.transform.TransformPoint(localShootPosition);

        // 스킬 프리팹을 생성하고 지정된 위치에 생성합니다.
        skillInstance = Instantiate(skillPrefab, shootPosition, Quaternion.LookRotation(localForward));

        Rigidbody skillRigidbody = skillInstance.GetComponent<Rigidbody>();
        if (skillRigidbody != null)
        {
            // Rigidbody가 있다면 지정된 방향으로 힘을 가합니다.
            skillRigidbody.AddForce(localForward * skillForce, ForceMode.Impulse);
        }

        skillLaunched = true;

        // 스킬 사용 시간이 지난 후 스킬을 파괴하는 코루틴을 시작합니다.
        StartCoroutine(DestroySkillAfterDuration());
    }


    IEnumerator DestroySkillAfterDuration()
    {
        // 스킬 지속 시간만큼 대기
        yield return new WaitForSeconds(skillDuration);

        // 파괴
        skillLaunched = false;
        Destroy(skillInstance);
    }
}
