using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "Regio/Entities/Building", order = 3)]
public class Building : ScriptableObject
{
    public GameObject buildingPrefab;
    public Material[] originalBuildingMaterials;
    public IntVariable metalCost;
    public IntVariable electricityCost;
}
