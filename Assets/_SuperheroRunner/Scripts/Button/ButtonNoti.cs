using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNoti : MonoBehaviour
{
    // //[SerializeField] private NotiType notiType;
    // [SerializeField] private GameObject noti;
    //
    // private void Start()
    // {
    //     EventController.diamondTotalChanged += CheckNoti;
    //     EventController.LoginLeaderBoard += CheckNoti;
    // }
    //
    // private void OnEnable()
    // {
    //     CheckNoti();
    // }
    //
    // public void CheckNoti()
    // {
    //     bool hasNoti = false;
    //
    //     switch (notiType)
    //     {
    //         case NotiType.Universe:
    //             hasNoti = ResourcesController.Universe.HasNotiUniverse;
    //             break;
    //         case NotiType.World:
    //             hasNoti = ResourcesController.Universe.HasNotiWorld;
    //             break;
    //         case NotiType.Build:
    //             hasNoti = ResourcesController.Universe.HasNotiBuild;
    //             break;
    //         case NotiType.Skin:
    //             hasNoti = ResourcesController.Hero.HasNoti;
    //             break;
    //         case NotiType.Daily:
    //             hasNoti = ResourcesController.DailyReward.HasNoti;
    //             break;
    //         case NotiType.Achievement:
    //             hasNoti = ResourcesController.Achievement.HasNoti;
    //             break;
    //         case NotiType.DailyQuest:
    //             hasNoti = ResourcesController.DailyQuest.HasNoti;
    //             break;
    //         case NotiType.Facebook:
    //             hasNoti = Data.JoinFbProgress < 2;
    //             break;
    //         case NotiType.Leaderboard:
    //             hasNoti = Data.PlayerId == "";
    //             break;
    //         case NotiType.AchievementDailyQuest:
    //             hasNoti = ResourcesController.Achievement.HasNoti || ResourcesController.DailyQuest.HasNoti;
    //             break;
    //     }
    //
    //     if (noti != null)
    //     {
    //         noti.SetActive(hasNoti);
    //     }
    // }
    //
    // private void OnDestroy()
    // {
    //     EventController.diamondTotalChanged -= CheckNoti;
    // }
}
