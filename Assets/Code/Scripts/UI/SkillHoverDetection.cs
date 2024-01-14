using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillHoverDetection : MonoBehaviour, IPointerEnterHandler
{
    public SkillHoverInformation skillHoverInformation;
    public int id;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ChangeSkillInfo(id);
    }

    public void ChangeSkillInfo(int id)
    {
        skillHoverInformation.ChangeSkillInformation(id);
    }
}
