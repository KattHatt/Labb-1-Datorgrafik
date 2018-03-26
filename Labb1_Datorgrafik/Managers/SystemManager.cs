﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Labb1_Datorgrafik
{
    class SystemManager
    {
        private Dictionary<Type, object> systems;
        private static SystemManager systemManagerInstance;

        static SystemManager()
        {
            systemManagerInstance = new SystemManager();
        }

        private SystemManager()
        {
            systems = new Dictionary<Type, object>();
        }

        public static SystemManager GetInstance()
        {
            return systemManagerInstance;
        }

        public T GetSystem<T>()
        {
            object system;
            systems.TryGetValue(typeof(T), out system);
            return (T)system;
        }

        public void Update<T>(GameTime gameTime)
        {
            object system;
            systems.TryGetValue(typeof(T), out system);
            ((ISystem)system)?.Update(gameTime);
        }

        public void AddSystem(object system)
        {
            systems.Add(system.GetType(), system);
        }

        public void RemoveSystem(object system)
        {
            if (systems.ContainsKey(system.GetType()))
                systems.Remove(system.GetType());
        }
    }
}
