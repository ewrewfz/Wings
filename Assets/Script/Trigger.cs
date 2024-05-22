using UnityEngine;
using Oculus.Interaction.PoseDetection;
using System.Collections;
using Unity.VisualScripting;

public class Trigger : MonoBehaviour
{
    // ���� ��������
    public ShapeRecognizerActiveState poseDetector;

    // �ߵ��� ��ų�� ������
    public GameObject skillPrefab;

    // ��ų ���� �ð�
    public float skillDuration = 5f;

    // ��ų ����ϴ��� üũ
    bool skillLaunched = false;

    public OVRCameraRig cameraRig;



    public GameObject handPos;


    GameObject skillInstance;

    public float distanceThreshold = 1.0f;

    public float skillSpawnDistance = 10.0f;

    public float skillForce = 20.0f; // ��ų�� ������ ��

    private void Start()
    {
       
        handPos = GameObject.FindWithTag("R_Hand").transform.gameObject;
        
    }

    void Update()
    {

        // ��� �����ǰ� ��ų�� �ߵ����� ���� ��쿡�� ����
        if (poseDetector.Active && !skillLaunched && IsHandFarEnough())
        {
            Debug.Log("��ų�߻�");
            // ���� �Ǿ���
            LaunchSkill(handPos.transform.position);
        }
    }

    bool IsHandFarEnough()
    {
        // �������� �Ÿ� ����
        float distance = Vector3.Distance(cameraRig.transform.position, transform.position);
        return distance >= distanceThreshold;
    }

    void LaunchSkill( Vector3 spawnPos)
    {
        Debug.Log("��ų�߻� ��");

        // handPos�� ���� forward ������ �������� �߻� ������ ����մϴ�.
        Vector3 localForward = handPos.transform.forward;

        // handPos�� ���� forward ������ �������� �߻� ��ġ�� ����մϴ�.
        Vector3 localShootPosition = localForward * skillSpawnDistance;

        // localShootPosition�� world space�� ��ȯ�Ͽ� ���� �߻� ��ġ�� ����մϴ�.
        Vector3 shootPosition = handPos.transform.TransformPoint(localShootPosition);

        // ��ų �������� �����ϰ� ������ ��ġ�� �����մϴ�.
        skillInstance = Instantiate(skillPrefab, shootPosition, Quaternion.LookRotation(localForward));

        Rigidbody skillRigidbody = skillInstance.GetComponent<Rigidbody>();
        if (skillRigidbody != null)
        {
            // Rigidbody�� �ִٸ� ������ �������� ���� ���մϴ�.
            skillRigidbody.AddForce(localForward * skillForce, ForceMode.Impulse);
        }

        skillLaunched = true;

        // ��ų ��� �ð��� ���� �� ��ų�� �ı��ϴ� �ڷ�ƾ�� �����մϴ�.
        StartCoroutine(DestroySkillAfterDuration());
    }


    IEnumerator DestroySkillAfterDuration()
    {
        // ��ų ���� �ð���ŭ ���
        yield return new WaitForSeconds(skillDuration);

        // �ı�
        skillLaunched = false;
        Destroy(skillInstance);
    }
}
