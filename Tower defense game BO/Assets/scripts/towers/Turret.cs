using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    [SerializeField] private float Range = 2f;
    //[SerializeField] private float FireRate = 1f;
    [SerializeField] private LayerMask TargetLayer;
    [SerializeField] private Transform Rotationpoint;
    [SerializeField] private GameObject ProjectilePrefab;
    [SerializeField] private Transform firingpoint;
    [SerializeField] private float BPS = 1f;

    private Transform Target;
    private float TimeUntilFire;

    [SerializeField] private Button upgradeButton;
    [SerializeField] private GameObject UpgradeUI;
    private int upgradeLevel = 1;

    [SerializeField] private int BaseUpgradeCost = 100;

    public void OpenUpgradeUI()
    {
        UpgradeUI.SetActive(true);
    }

    public void CloseUpgradeUI()
    {
        UpgradeUI.SetActive(false);
    }

    public void UpgradeTower()
    {
        if (CalculateUpgradeCost() > MoneyUpdate.main.money) return;

        MoneyUpdate.main.SpendMoney(CalculateUpgradeCost());

        upgradeLevel++;

        BPS = CalculateShootspeed();

        CloseUpgradeUI();
        Debug.Log("Tower Upgraded to level " + upgradeLevel);
        Debug.Log("New shoot interval: " + BPS);
        Debug.Log("Next upgrade cost: " + CalculateUpgradeCost());
    }

    private int CalculateUpgradeCost()
    {
        return Mathf.RoundToInt(BaseUpgradeCost * Mathf.Pow(upgradeLevel, 0.8f));
    }

    private float CalculateShootspeed()
    {
        float factor = Mathf.Pow(upgradeLevel, 0.2f);
        return BPS / factor;
    }

    private bool CheckTargetInRange()
    {
        if (Target == null) return false;
        return Vector2.Distance(Target.position, transform.position) <= Range;
    }

    private void rotateToTarget()
    {
        if (Target == null || Rotationpoint == null) return;

        float angle = Mathf.Atan2(
            Target.position.y - transform.position.y,
            Target.position.x - transform.position.x
        ) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        Rotationpoint.rotation = targetRotation;
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, Range, Vector2.zero, 0f, TargetLayer);

        if (hits.Length > 0)
        {
            Target = hits[0].transform;
        }
        else
        {
            Target = null;
        }
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, Vector3.forward, Range);
#endif
    }

    private void Shoot()
    {
        if (ProjectilePrefab == null || firingpoint == null || Target == null) return;

        GameObject projectileGameObject = Instantiate(ProjectilePrefab, firingpoint.position, firingpoint.rotation);
        projectile projectile = projectileGameObject.GetComponent<projectile>();
        projectile.target = Target;
    }

    void Start()
    {
        upgradeButton.onClick.AddListener(UpgradeTower);
    }
    void Update()
    {
        if (Target == null)
        {
            FindTarget();
        }

        if (Target != null)
        {
            rotateToTarget();

            if (!CheckTargetInRange())
            {
                Target = null;
            }
            else
            {
                TimeUntilFire -= Time.deltaTime;
                if (TimeUntilFire <= 0f)
                {
                    Shoot();
                    TimeUntilFire = 1f / BPS;
                }
            }
        }
    }
}