using UnityEngine;
using Oculus.Interaction.PoseDetection;
using System.Collections;

public class TestScript : MonoBehaviour
{
    public ShapeRecognizerActiveState poseHand;
    public GameObject child;
    public GameObject SkillPrefabs;
    private GameObject ShootSkill;
    public float offsetDistance = 2f; // 발사 위치에서의 거리를 조절하는 변수
    [SerializeField] private float skillDuration = 2f;
    public float shootForce = 20f; // 발사할 때 가할 힘의 크기

    private void Start()
    {
        // 자식 오브젝트 설정
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
        // 자식 오브젝트의 forward 방향을 고려하여 발사 위치 계산
        Vector3 shootDirection = child.transform.forward;

        // 스킬을 발사하는 위치를 계산
        Vector3 shootPosition = _sPos + shootDirection * offsetDistance;

        // 스킬을 발사합니다.
        ShootSkill = Instantiate(SkillPrefabs, shootPosition, Quaternion.identity);

        // 발사된 스킬에 Rigidbody 컴포넌트가 있을 경우 특정 방향으로 힘을 가합니다.
        Rigidbody skillRigidbody = ShootSkill.GetComponent<Rigidbody>();
        if (skillRigidbody != null)
        {
            skillRigidbody.AddForce(shootDirection * shootForce, ForceMode.Impulse);
        }
    }
}
