using UnityEngine;

public class KarmaPoints : MonoBehaviour
{
    private static GameObject prefab;

    public static void ShowPoints(PointsToKarma pointsToKarma)
    {
        if (prefab == null)
        {
            if (pointsToKarma == PointsToKarma.Minus)
            {
                prefab = Instantiate(Resources.Load("Prefab/KarmaPointsPrefab/KarmaMinus"), new Vector2(182f, 297f), Quaternion.identity) as GameObject;
            }
            else
            {
                prefab = Instantiate(Resources.Load("Prefab/KarmaPointsPrefab/KarmaPlus"), new Vector2(182f, 297f), Quaternion.identity) as GameObject;
            }
        }                   
        Destroy(prefab, 0.39f);
    }
}