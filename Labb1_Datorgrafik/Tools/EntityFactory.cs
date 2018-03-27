﻿using Labb1_Datorgrafik.Components;
using Labb1_Datorgrafik.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Labb1_Datorgrafik.Tools
{
    public static class EntityFactory
    {
        public static int CreateCamera(GraphicsDevice gd)
        {
            ComponentManager cm = ComponentManager.GetInstance();

            int cam = cm.AddEntityWithComponents( new IComponent[] { new CameraComponent(gd), new TransformComponent() });
            TransformComponent transform = cm.GetComponentForEntity<TransformComponent>(cam);
            CameraComponent camComp = cm.GetComponentForEntity<CameraComponent>(cam);
            Matrix.CreateLookAt(ref transform.Position, ref camComp.Target, ref camComp.UpVector, out camComp.ViewMatrix);

            return cam;
        }
    }
}
