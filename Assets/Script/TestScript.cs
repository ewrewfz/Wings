using UnityEngine;
using Oculus.Interaction.PoseDetection;
using System.Collections;

public class TestScript : MonoBehaviour
{
    public ShapeRecognizerActiveState poseHand;
    public GameObject child;
    public GameObject SkillPrefabs;
    private GameObject ShootSkill;
    public float offsetDistance = 2f; // �߻� ��ġ������ �Ÿ��� �����ϴ� ����
    [SerializeField] private float skillDuration = 2f;
    public float shootForce = 20f; // �߻��� �� ���� ���� ũ��

    private void Start()
    {
        // �ڽ� ������Ʈ ����
        child = GameObject.FindWithTag("R_Hand").transform.GetChild(0).gameObject;
        StartCoroutine(ShootSkillRoutine());
    }

    private IEnumerator ShootSkillRoutine()
    {
        while (true)
        {
            if (poseHand)
            {
                Shoot(child.transform.position);
                yield return new WaitForSeconds(skillDuration);
            }
            else
            {
                yield return null;
            }
        }
    }

    void Shoot(Vector3 _sPos)
    {
        // �ڽ� ������Ʈ�� forward ������ ����Ͽ� �߻� ��ġ ���
        Vector3 shootDirection = child.transform.forward;

        // ��ų�� �߻��ϴ� ��ġ�� ���
        Vector3 shootPosition = _sPos + shootDirection * offsetDistance;

        // ��ų�� �߻��մϴ�.
        ShootSkill = Instantiate(SkillPrefabs, shootPosition, Quaternion.identity);

        // �߻�� ��ų�� Rigidbody ������Ʈ�� ���� ��� Ư�� �������� ���� ���մϴ�.
        Rigidbody skillRigidbody = ShootSkill.GetComponent<Rigidbody>();
        if (skillRigidbody != null)
        {
            skillRigidbody.AddForce(shootDirection * shootForce, ForceMode.Impulse);
        }
    }
}
