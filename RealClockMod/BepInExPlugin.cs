﻿using BepInEx;
using HarmonyLib;
using System;
using System.Reflection;

namespace RealClockMod
{
    [BepInPlugin("aedenthorn.RealClockMod", "Real Clock Mod", "0.3.1")]
    public partial class BepInExPlugin : BaseUnityPlugin
    {

        private static string debugName = "realclockmod";
        private static int windowId = 343434;

        private void Awake()
        {
            nexusID = Config.Bind<int>("General", "NexusID", 489, "Nexus mod ID for updates");
            toggleClockKey = Config.Bind<string>("General", "ShowClockKey", "delete", "Key used to toggle the clock display. use https://docs.unity3d.com/Manual/ConventionalGameInput.html");
            clockLocationString = Config.Bind<string>("General", "ClockLocationString", "50%,6%", "Location on the screen to show the clock (x,y) or (x%,y%)");

            LoadConfig();

            if (!modEnabled.Value)
                return;

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), null);
        }
        private string GetCurrentTimeString()
        {
            DateTime theTime = DateTime.Now;
            float fraction = (theTime.Hour * 60 * 60 + theTime.Minute * 60 + theTime.Second) / 24 * 60 * 60;

            return GetCurrentTimeString(theTime, fraction);
        }
    }
}