using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AotForms
{
    internal static class Aimbot
    {
        internal static void Work()
        {
            while (true)
            {
                if (!Config.AimBot)
                {
                    Thread.Sleep(1);
                    continue;
                }

                if ((WinAPI.GetAsyncKeyState(Config.AimbotKey) & 0x8000) == 0)
                {
                    Thread.Sleep(1);
                    continue;
                }

                Entity target = null;
                float distance = float.MaxValue;

                if (Core.Width == -1 || Core.Height == -1) continue;
                if (!Core.HaveMatrix) continue;

                var screenCenter = new Vector2(Core.Width / 2f, Core.Height / 2f);

                foreach (var entity in Core.Entities.Values)
                {
                    if (!entity.IsKnown) continue;
                    if (entity.IsDead) continue;

                    if (Config.IgnoreKnocked)
                    {
                        if (entity.IsKnocked) continue;
                    }

                    // Use the selected part of the body for targeting
                    Vector3 targetPosition = Config.AimTargetPart switch
                    {
                        "Head" => entity.Head,
                        "Neck" => entity.Neck,
                        "Hip" => entity.Hip,
                        _ => entity.Head
                    };

                    var target2D = W2S.WorldToScreen(Core.CameraMatrix, targetPosition, Core.Width, Core.Height);

                    if (target2D.X < 1 || target2D.Y < 1) continue;

                    var playerDistance = Vector3.Distance(Core.LocalMainCamera, targetPosition);

                    if (playerDistance > Config.AimBotMaxDistance) continue;

                    var x = target2D.X - screenCenter.X;
                    var y = target2D.Y - screenCenter.Y;
                    var crosshairDist = (float)Math.Sqrt(x * x + y * y);

                    if (crosshairDist >= distance || crosshairDist == float.MaxValue)
                    {
                        continue;
                    }

                    if (crosshairDist > Config.AimFov)
                    {
                        continue;
                    }

                    distance = crosshairDist;
                    target = entity;
                }

                if (target != null)
                {
                    var playerLook = MathUtils.GetRotationToLocation(target.Head, 0.1f, Core.LocalMainCamera);

                    InternalMemory.Write(Core.LocalPlayer + Offsets.AimRotation, playerLook);
                    Thread.Sleep(Config.AimBotSmooth);
                }
            }
        }
    }
}
