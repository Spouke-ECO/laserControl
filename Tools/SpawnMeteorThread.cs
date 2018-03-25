﻿using Eco.Gameplay.Disasters;
using Eco.Gameplay.Systems.Chat;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LaserControl.Tools
{
    public class SpawnMeteorThread
    {
        public static void spawn()
        {
            Thread.Sleep(45 * 1000);

            Console.WriteLine(LaserControl.prefix + "Trying to spawn a new meteor !");


            MethodInfo methodInfo = null;
            foreach (MethodInfo met in typeof(DisasterPlugin).GetMethods(BindingFlags.Static | BindingFlags.NonPublic))
            {

                if (met.Name.Contains("SpawnMeteor"))
                {
                    ParameterInfo[] parameters = met.GetParameters();
                    methodInfo = met;
                    break;

                }

            }

            if (methodInfo != null)
            {
                object result = null;
                ParameterInfo[] parameters = methodInfo.GetParameters();

                if (parameters.Length == 0)
                {
                    result = methodInfo.Invoke(null, null);
                }
            }
            else
            {
                Console.WriteLine(LaserControl.prefix + "Error while create the new meteor, method not find");
            }


            ChatManager.ServerMessageToAll(Text.Info(Text.Size(2f, $"A new meteor spawned !")), false, Eco.Shared.Services.DefaultChatTags.Meteor, Eco.Shared.Services.ChatCategory.Info);

        }
    }
}