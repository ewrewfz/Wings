using Oculus.Interaction.PoseDetection;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ���� ��������
    public ShapeRecognizerActiveState[] poseDetector;

    // ��ų�� ���ӽð�
    [HideInInspector] public float skillDuration = 2f;

    // ��ų �������?
    bool skillLaunched = false;

    // �������� ��� �߰��Ϸ��� ���� ���Ŀ� SDK �� ���� �ű� ��� ��� �����ϸ� �� ����
    public OVRCameraRig cameraRig;

    // ��ų ���� ��ġ ����ִ� ����
    public GameObject handPos;

    [SerializeField] private SkillsManager skillManager;

    // ���� �󸶳� �־����� ��ų ������?
    public float distanceThreshold = 1.0f;
    // ��ų�� �� �������� ������� �������� ������?
    public float skillSpawnDistance = 10.0f;
    // ��ų�� ������ ��
    public float skillForce = 20.0f;
    //��ų�� ��� �ڽ�
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
        Debug.Log("��ų �ߵ�.");
        skillLaunched = true;
        Instantiate(_skill, transform.position, Quaternion.identity);

        StartCoroutine(DestroySkillAfterDuration());
    }


    IEnumerator DestroySkillAfterDuration()
    {
        // ��ų ���� �ð���ŭ ���
        yield return new WaitForSeconds(skillDuration);

        // �ı�
        skillLaunched = false;
    }

}
