using UnityEngine;

[CreateAssetMenu(fileName = "Resource Building", menuName = "Regio/Entities/ResourceBuilding", order = 3)]
public class ResourceBuilding : Building
{
    public ResourceTypeVariable resourceType;
    public IntVariable amountGeneratedPersecond;
}