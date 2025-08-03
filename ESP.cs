using ImGuiNET;
using System;
using System.Drawing;
using System.Numerics;
using System.Linq;
using System.Threading.Tasks;
using static AotForms.WinAPI;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Vortice.Direct3D11;
using static AotForms.Config;
using System.Text;
using System.Text.Json;
using System;
using System.Drawing.Imaging;
using static System.Net.Mime.MediaTypeNames;
using Memory;
using SharpGen.Runtime;
using Vortice.DXGI;
using System.Windows.Forms;
namespace AotForms
{
    internal class ESP : ClickableTransparentOverlay.Overlay
    {
        IntPtr hWnd;
        IntPtr HDPlayer;
        private const short DefaultMaxHealth = 200;
        private Vector4 lineColor = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        private Vector4 fovColor = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        private Vector4 boxColor = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        private Vector4 skeletonColor = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        private Vector4 crossColor = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        private CX memoryfast = new CX();
        private IEnumerable<long> speedResult;
        private IEnumerable<long> wallResult;
        private IEnumerable<long> cameraResult;
        internal static float GlowRadius = 20f;
        internal static float FeatherAmount = 2f;

        
        private bool hotkeyStarted = false;

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);
        private async void loadSpeed()

        {
            string[] pocessname = { "HD-Player" };
            bool success = memoryfast.SetProcess(pocessname);

            if (!success)
            {
                return;
            }

            speedResult = await memoryfast.AoBScan("01 00 00 00 02 2B 07 3D");
            Console.Beep(2000, 600);

        }
        private async void speedOn()
        {
            foreach (long id in speedResult)
            {
                memoryfast.AobReplace(id, "01 00 00 00 02 2B 70 3D");
            }
            Console.Beep(2000, 600);
        }
        private async void speedOff()
        {
            foreach (long id in speedResult)
            {
                memoryfast.AobReplace(id, "01 00 00 00 02 2B 07 3D");
            }
            Console.Beep(2000, 600);
        }
        private async void loadWall()

        {
            string[] pocessname = { "HD-Player" };
            bool success = memoryfast.SetProcess(pocessname);

            if (!success)
            {
                return;
            }

            wallResult = await memoryfast.AoBScan("3f ae 47 81 3f 00 1a b7 ee dc 3a 9f ed 30 00 4f e2 43 2a b0 ee ef 0a 60 f4 43 6a f0 ee 1c 00 8a e2 43 5a f0 ee 8f 0a 48 f4 43 2a f0 ee 43 7a b0");
            Console.Beep(2000, 600);

        }
        private async void wallOn()
        {
            foreach (long id in wallResult)
            {
                memoryfast.AobReplace(id, "bf");
            }
            Console.Beep(2000, 600);
        }
        private async void wallOff()
        {
            foreach (long id in wallResult)
            {
                memoryfast.AobReplace(id, "3f ae 47 81 3f 00 1a b7 ee dc 3a 9f ed 30 00 4f e2 43 2a b0 ee ef 0a 60 f4 43 6a f0 ee 1c 00 8a e2 43 5a f0 ee 8f 0a 48 f4 43 2a f0 ee 43 7a b0");
            }
            Console.Beep(2000, 600);
        }
        private async void sniperScope()

        {
            string[] pocessname = { "HD-Player" };
            bool success = memoryfast.SetProcess(pocessname);

            if (!success)
            {
                return;
            }

            IEnumerable<long> result = await memoryfast.AoBScan("CC 3D 06 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 33 33 13 40 00 00 B0 3F 00 00");

            foreach (long id in result)
            {
                memoryfast.AobReplace(id, "CC 3D 06 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 33 33 13 40 00 00 B0 3F 00 00");
            }
            Console.Beep(2000, 600);

        }
        private async void sniper()

        {
            string[] pocessname = { "HD-Player" };
            bool success = memoryfast.SetProcess(pocessname);

            if (!success)
            {
                return;
            }

            IEnumerable<long> result = await memoryfast.AoBScan("00 00 00 00 3F 00 00 80 3E 00 00 00 00 04 00 00 00 00 00 80 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 8F C2 35 3F 9A 99 99 3F 00 00 80 3F 00 00 00 00 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 80 3F 00 00 80 3F");

            foreach (long id in result)
            {
                memoryfast.AobReplace(id, "00 00 00 00 3C 00 00 F5 3C 00 00 00 00 04 00 00 00 00 00 80 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 8F C2 35 3F 9A 99 99 3F 00 00 80 3F 00 00 00 00 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 80 3F 00 00 80 3F");
            }
            Console.Beep(2000,600);  
        }

        private async void sniperDelayFix()

        {
            string[] pocessname = { "HD-Player" };
            bool success = memoryfast.SetProcess(pocessname);

            if (!success)
            {
                return;
            }

            IEnumerable<long> result = await memoryfast.AoBScan("3F 00 00 80 3E 00 00 00 00 04 00 00 00 00 00 80 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F");

            foreach (long id in result)
            {
                memoryfast.AobReplace(id, "1A 00 00 80 1A 00 00 00 00 04 00 00 00 00 00 80 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F");
            }
            Console.Beep(2000, 600);
        }

        private async void loadCamera()
        {
            string[] pocessname = { "HD-Player" };
            bool success = memoryfast.SetProcess(pocessname);

            if (!success)
            {
                return;
            }

            // 👇 Replace this with actual camera AOB if you have it
            cameraResult = await memoryfast.AoBScan("00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 80 BF 00");
            Console.Beep(2500, 600);
        }

        private async void cameraOn()
        {
            foreach (long id in cameraResult)
            {
                memoryfast.AobReplace(id, " 00 00 00 00 00 80 40 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 80 74"); // Replace with your modified camera effect
            }
            Console.Beep(2000, 300);
        }

        private async void cameraOff()
        {
            foreach (long id in cameraResult)
            {
                memoryfast.AobReplace(id, " 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 80 BF 00"); // Use actual original pattern here
            }
            Console.Beep(1200, 300);
        }
        private async void CheckHotkeysLoop()
        {
            while (true)
            {
                if ((GetAsyncKeyState(Keys.F1) & 0x8000) != 0) // If '1' key is pressed
                {
                    speedOn();
                    await Task.Delay(300); // prevent spamming
                }

                if ((GetAsyncKeyState(Keys.F2) & 0x8000) != 0) // If '2' key is pressed
                {
                    speedOff();
                    await Task.Delay(300); // prevent spamming
                }

                await Task.Delay(50); // Check keys every 50ms
            }
        }


        private void UpdateEntities()
        {

            foreach (var entity in Core.Entities.Values)
            {
                if (entity.IsTeam != Bool3.False) continue;

                TreeNode entityNode = new TreeNode(entity.Name);

                entityNode.Nodes.Add(new TreeNode($"IsKnown: {entity.IsKnown}"));
                entityNode.Nodes.Add(new TreeNode($"IsTeam: {entity.IsTeam}"));
                entityNode.Nodes.Add(new TreeNode($"Head: {entity.Head}"));
                entityNode.Nodes.Add(new TreeNode($"Root: {entity.Root}"));
                entityNode.Nodes.Add(new TreeNode($"Health: {entity.Health}"));
                entityNode.Nodes.Add(new TreeNode($"IsDead: {entity.IsDead}"));
                entityNode.Nodes.Add(new TreeNode($"IsKnocked: {entity.IsKnocked}"));


            }
            Thread.Sleep(1000);
        }
        private void NoCache()
        {

            InternalMemory.Cache = new();
            Core.Entities = new();
            Thread.Sleep(1000);
        }

        protected override unsafe void Render()
        {
            RenderImgui();
            
            if (!hotkeyStarted)
            {
                hotkeyStarted = true;
                CheckHotkeysLoop();
            }

            if (!Core.HaveMatrix) return;
            CreateHandle();


            if (Config.FOVEnabled)
            {
                DrawFOVCircle(Config.AimFov);
            }
            string text = "</>Dev: SKY ";
            var windowWidth = Core.Width;
            var windowHeight = Core.Height;
            var textSize = ImGui.CalcTextSize(text);
            var textPosX = (windowWidth - textSize.X) / 2;
            var textPosY = 80;
            uint textColor = ImGui.ColorConvertFloat4ToU32(new Vector4(1.0f, 1.0f, 1.0f, 1.0f));
            uint shadowColor = ImGui.ColorConvertFloat4ToU32(new Vector4(0.0f, 0.0f, 0.0f, 0.5f));

            var drawList = ImGui.GetForegroundDrawList();

            // Draw the text multiple times to simulate bold effect
            var offsets = new[] { new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1) };
            foreach (var offset in offsets)
            {
                drawList.AddText(new Vector2(textPosX + offset.X, textPosY + offset.Y), shadowColor, text);

            }
            drawList.AddText(new Vector2(textPosX, textPosY), textColor, text);
            var tmp = Core.Entities;

            string windowName = "Overlay";
            hWnd = FindWindow(null!, windowName);
            HDPlayer = FindWindow("BlueStacksApp", null!);

            if (hWnd != IntPtr.Zero)
            {
                long extendedStyle = GetWindowLong(hWnd, GWL_EXSTYLE);
                SetWindowLong(hWnd, GWL_EXSTYLE, (extendedStyle | WS_EX_TOOLWINDOW) & ~WS_EX_APPWINDOW);
            }
            else
            {

            }
            int enemyCount = 0;
            foreach (var entity in tmp.Values)
            {
                if (entity.IsDead || !entity.IsKnown) continue;

                var dist = Vector3.Distance(Core.LocalMainCamera, entity.Head);
                if (dist > 200) continue;

                var headScreenPos = W2S.WorldToScreen(Core.CameraMatrix, entity.Head, Core.Width, Core.Height);
                enemyCount++;
                var bottomScreenPos = W2S.WorldToScreen(Core.CameraMatrix, entity.Root, Core.Width, Core.Height);

                if (headScreenPos.X < 1 || headScreenPos.Y < 1 || bottomScreenPos.X < 1 || bottomScreenPos.Y < 1) continue;

                float CornerHeight = Math.Abs(headScreenPos.Y - bottomScreenPos.Y);
                float CornerWidth = CornerHeight * 0.65f;


                if (Config.ESPLine)
                {
                    Vector2 lineStart;

                    // Determine line start position based on LinePosition
                    switch (Config.ESPLinePosition)
                    {
                        case LinePosition.Top:
                            lineStart = new Vector2(Core.Width / 2f, 10f); // Top position
                            break;
                        case LinePosition.Center:
                            lineStart = new Vector2(Core.Width / 2f, Core.Height / 2f); // Center position
                            break;
                        case LinePosition.Bottom:
                            lineStart = new Vector2(Core.Width / 2f, Core.Height - 10f); // Bottom position
                            break;
                        default:
                            lineStart = new Vector2(Core.Width / 2f, Core.Height / 2f); // Default to center
                            break;
                    }


                    DrawGlowingBall(lineStart, Config.ESPLineColor, 3f);







                    //ImGui.GetBackgroundDrawList().AddLine(
                    //    lineStart,
                    //    headScreenPos,
                    //    ColorToUint32(Config.ESPLineColor),
                    //    1f
                    //);
                    DrawGlowLine(lineStart, headScreenPos, ColorToUint32(Config.ESPLineColor), 1f, GlowRadius, FeatherAmount);
                }


                if (Config.ESPBox)
                {


                    uint boxColor = ColorToUint32(Config.ESPBoxColor);
                    DrawCorneredBox(headScreenPos.X - (CornerWidth / 2), headScreenPos.Y, CornerWidth, CornerHeight, boxColor, 1f);

                }




                var nameText = string.IsNullOrWhiteSpace(entity.Name) ? "BOT" : entity.Name;
                var namePosition = new Vector2(headScreenPos.X - (CornerWidth / 2), headScreenPos.Y - 30);
                var nameSize = ImGui.CalcTextSize($"      {MathF.Round(dist)}M" + nameText);
                Vector2 fixedNameSize = new Vector2(95, 16);


                if (entity.Name == "")
                    entity.Name = "Bot";
                if (headScreenPos.X >= 0 && headScreenPos.Y >= 0 && headScreenPos.X <= Core.Width && headScreenPos.Y <= Core.Height)
                {
                    Vector2 namePos = new Vector2(headScreenPos.X - fixedNameSize.X / 2, headScreenPos.Y - fixedNameSize.Y - 15);



                    Vector2 textSizeName = ImGui.CalcTextSize(entity.Name);

                    Vector2 textSizeDistance = ImGui.CalcTextSize($" ({MathF.Round(Vector3.Distance(Core.LocalMainCamera, entity.Head))}m)");

                    Vector2 textPosName = new Vector2(namePos.X + 5, namePos.Y + (fixedNameSize.Y - textSizeName.Y) / 2);
                    Vector2 textPosDistance = new Vector2(namePos.X + fixedNameSize.X - textSizeDistance.X + 5, namePos.Y + (fixedNameSize.Y - textSizeDistance.Y) / 2);



                    if (Config.ESPName)
                    {
                        ImGui.GetForegroundDrawList().AddRectFilled(namePos, namePos + new Vector2(fixedNameSize.X, fixedNameSize.Y), ImGui.ColorConvertFloat4ToU32(new Vector4(0, 0, 0, 0.7f)), 3f);
                        ImGui.GetForegroundDrawList().AddText(textPosName, ColorToUint32(Config.ESPNameColor), entity.Name);
                        ImGui.GetForegroundDrawList().AddText(textPosDistance, ColorToUint32(Config.ESPNameColor), $" {MathF.Round(Vector3.Distance(Core.LocalMainCamera, entity.Head))}m");
                    }


                    var vList = ImGui.GetForegroundDrawList();

                    if (Config.ESPHealth)
                    {
                        Vector2 healthBarPosRight = new Vector2(headScreenPos.X + (CornerWidth / 2) + 5, headScreenPos.Y);

                        float healthPercentage = entity.Health > 1000 ? 1f :
                            entity.Health < 0 ? 1f :
                            (float)entity.Health / (entity.Health > 230 ? 500 : 200);

                        float healthBarWidth = 3;  // Thinner health bar
                        float healthBarFullHeight = CornerHeight;

                        uint healthBarColor;
                        if (entity.IsKnocked)
                        {
                            healthBarColor = ColorToUint32(Color.Red); // Full red when knocked
                        }
                        else
                        {
                            if (healthPercentage > 0.8f)
                                healthBarColor = ColorToUint32(Color.Lime); // Bright lime green
                            else if (healthPercentage > 0.4f)
                                healthBarColor = ColorToUint32(Color.Yellow); // Bright yellow
                            else
                                healthBarColor = ColorToUint32(Color.Red); // Bright red
                        }

                        // Draw the outline (black) with rounded corners
                        vList.AddRect(new Vector2(healthBarPosRight.X - 1, healthBarPosRight.Y - 1),
                                      new Vector2(healthBarPosRight.X + healthBarWidth + 1, healthBarPosRight.Y + healthBarFullHeight + 1),
                                      0xFF000000, // Black color for the outline
                                      1.0f);      // Radius for rounded corners

                        // Draw the background bar with radius
                        vList.AddRectFilled(new Vector2(healthBarPosRight.X, healthBarPosRight.Y),
                                            new Vector2(healthBarPosRight.X + healthBarWidth, healthBarPosRight.Y + healthBarFullHeight),
                                            0x90000000, // Semi-transparent black for background
                                            1.0f);      // Radius for rounded corners

                        // Draw the health bar with radius
                        vList.AddRectFilled(new Vector2(healthBarPosRight.X, healthBarPosRight.Y + healthBarFullHeight * (1 - healthPercentage)),
                                            new Vector2(healthBarPosRight.X + healthBarWidth, healthBarPosRight.Y + healthBarFullHeight),
                                            healthBarColor,
                                            1.0f);      // Radius for rounded corners

                    }


                    if (Config.ESPSkeleton)
                    {
                        DrawSkeleton(entity);
                    }

                    string totalPlayersText = $"Enemy: {enemyCount}";
                    var totalPlayersTextSize = ImGui.CalcTextSize(totalPlayersText);
                    var totalPlayersTextPosX = (windowWidth - totalPlayersTextSize.X) / 2;
                    var totalPlayersTextPosY = textPosY + textSize.Y + 20; // 

                    // Draw shadow for "Total Players" text
                    foreach (var offset in offsets)
                    {
                        drawList.AddText(new Vector2(totalPlayersTextPosX + offset.X, totalPlayersTextPosY + offset.Y), shadowColor, totalPlayersText);
                    }

                    // Draw the main "Total Players" text on top
                    drawList.AddText(new Vector2(totalPlayersTextPosX, totalPlayersTextPosY), textColor, totalPlayersText);

                }

                DrawShurikenCrosshair();

            }
        }
        public void DrawGlowLine(Vector2 start, Vector2 end, uint color, float thickness, float glowRadius, float feather)
        {
            var drawList = ImGui.GetBackgroundDrawList();
            Vector4 colorVec = ImGui.ColorConvertU32ToFloat4(color);

            // Outer glow layers
            for (float i = glowRadius; i > 0; i -= feather)
            {
                // Calculate alpha for the outer layers based on the current radius and feathering
                float alpha = colorVec.W * (i / glowRadius) * 0.02f; // Adjust glow strength with 0.6f factor
                uint glowColor = ImGui.ColorConvertFloat4ToU32(new Vector4(colorVec.X, colorVec.Y, colorVec.Z, alpha));

                // Draw each outer layer with increasing thickness to create a soft glow effect
                drawList.AddLine(start, end, glowColor, thickness + i);
            }

            // Main line at the center
            drawList.AddLine(start, end, color, thickness);
        }
        private void DrawLine(ImDrawListPtr drawList, Vector2 startPos, Vector2 endPos, uint color)
        {
            if (startPos.X > 0 && startPos.Y > 0 && endPos.X > 0 && endPos.Y > 0)
            {
                drawList.AddLine(startPos, endPos, color, 1.5f); // Adjust thickness as needed
            }
        }
        private void DrawSkeleton(Entity entity)
        {
            var drawList = ImGui.GetForegroundDrawList();
            uint lineColor = ColorToUint32(Config.ESPSkeletonColor); // Color for the skeleton lines
            uint circleColor = ColorToUint32(Color.Red); // Color for the circle around the head

            // Convert entity positions to screen space
            var headScreenPos = W2S.WorldToScreen(Core.CameraMatrix, entity.Head, Core.Width, Core.Height);
            var leftWristScreenPos = W2S.WorldToScreen(Core.CameraMatrix, entity.RightWrist, Core.Width, Core.Height); // Adjust as per actual mapping
            var spineScreenPos = W2S.WorldToScreen(Core.CameraMatrix, entity.Spine, Core.Width, Core.Height);
            var hipScreenPos = W2S.WorldToScreen(Core.CameraMatrix, entity.Hip, Core.Width, Core.Height); // Adjust as per actual mapping
            var rootScreenPos = W2S.WorldToScreen(Core.CameraMatrix, entity.Root, Core.Width, Core.Height);
            var rightCalfScreenPos = W2S.WorldToScreen(Core.CameraMatrix, entity.RightCalf, Core.Width, Core.Height);
            var leftCalfScreenPos = W2S.WorldToScreen(Core.CameraMatrix, entity.LeftCalf, Core.Width, Core.Height);
            var rightFootScreenPos = W2S.WorldToScreen(Core.CameraMatrix, entity.RightFoot, Core.Width, Core.Height);
            var leftFootScreenPos = W2S.WorldToScreen(Core.CameraMatrix, entity.LeftFoot, Core.Width, Core.Height);
            var rightWristScreenPos = W2S.WorldToScreen(Core.CameraMatrix, entity.RightWrist, Core.Width, Core.Height);
            var leftHandScreenPos = W2S.WorldToScreen(Core.CameraMatrix, entity.LeftHand, Core.Width, Core.Height);
            var leftShoulderScreenPos = W2S.WorldToScreen(Core.CameraMatrix, entity.LeftSholder, Core.Width, Core.Height);
            var rightShoulderScreenPos = W2S.WorldToScreen(Core.CameraMatrix, entity.RightSholder, Core.Width, Core.Height);
            var rightWristJointScreenPos = W2S.WorldToScreen(Core.CameraMatrix, entity.RightWristJoint, Core.Width, Core.Height);
            var leftWristJointScreenPos = W2S.WorldToScreen(Core.CameraMatrix, entity.LeftWristJoint, Core.Width, Core.Height);
            var leftElbowScreenPos = W2S.WorldToScreen(Core.CameraMatrix, entity.LeftElbow, Core.Width, Core.Height);
            var rightElbowScreenPos = W2S.WorldToScreen(Core.CameraMatrix, entity.RightElbow, Core.Width, Core.Height); // Adjust if needed

            // Draw skeleton lines


            DrawLine(drawList, spineScreenPos, rightShoulderScreenPos, lineColor); // Spine to Right Shoulder
            DrawLine(drawList, spineScreenPos, hipScreenPos, lineColor);// Spine to hip


            DrawLine(drawList, spineScreenPos, leftShoulderScreenPos, lineColor); // Spine to Left Shoulder
            DrawLine(drawList, leftShoulderScreenPos, rightElbowScreenPos, lineColor); // Left Shoulder to Left Elbow
            DrawLine(drawList, leftElbowScreenPos, rightWristJointScreenPos, lineColor); // Left Elbow to Left Wrist Joint
            // Left Wrist Joint to Left Wrist

            DrawLine(drawList, rightShoulderScreenPos, leftElbowScreenPos, lineColor); // Right Shoulder to Left Elbow
                                                                                       //  DrawLine(drawList, rightElbowScreenPos, leftWristJointScreenPos, lineColor); // Right Elbow to Left Wrist Joint
                                                                                       // Right Wrist Joint to Left Wrist

            DrawLine(drawList, hipScreenPos, rightFootScreenPos, lineColor);// Hip to Right Calf
            DrawLine(drawList, hipScreenPos, leftFootScreenPos, lineColor);// Hip to Left Calf


            // Draw a small circle around the head
            float distance = entity.Distance; // Assume entity.Distance is the distance to the player in game units

            // Calculate the circle radius based on distance (e.g., closer = larger, farther = smaller)
            float baseRadius = 50.0f; // Adjust this base value as needed
            float circleRadius = baseRadius / distance;

            // Draw the circle on the head if the head is visible on screen
            if (headScreenPos.X > 0 && headScreenPos.Y > 0)
            {
                drawList.AddCircle(headScreenPos, circleRadius, circleColor, 30); // 30 segments for the circle
            }

            // Add additional code here to draw the rest of the skeleton using the updated bone positions
        }
        public void DrawHealthBarK(short health, short maxHealth, float X, float Y, float height, float width)
        {
            var vList = ImGui.GetForegroundDrawList();

            // Prevent division by zero and ensure healthPercentage is between 0 and 1
            if (maxHealth <= 0) maxHealth = 100; // Fallback to a default max health
            float healthPercentage = Math.Clamp((float)health / maxHealth, 0f, 1f);
            float healthWidth = width * healthPercentage;

            // Determine the color based on health percentage
            Color healthColor;


            if (healthPercentage < 0.3f)
            {
                healthColor = Color.FromArgb((int)(1f * 255), 255, 0, 0); // Red for health < 20%
            }
            else if (healthPercentage < 0.8f)
            {
                healthColor = Color.FromArgb((int)(1f * 255), 255, 0, 0); // Yellow for health < 70%
            }
            else
            {
                healthColor = Color.FromArgb((int)(1f * 255), 255, 0, 0); // Green for health >= 70%
            }

            // Draw the full health bar background (unfilled part)
            vList.AddRectFilled(new Vector2(X, Y - height), new Vector2(X + width, Y), ColorToUint32(Color.FromArgb((int)(1f * 255), 99, 0, 0))); // Background for health bar

            // Draw the health portion representing current health
            vList.AddRectFilled(new Vector2(X, Y - height), new Vector2(X + healthWidth, Y), ColorToUint32(healthColor)); // Health portion

            // Draw the black outline around the health bar
            vList.AddRect(new Vector2(X, Y - height), new Vector2(X + width, Y), ColorToUint32(Color.Black), 1f); // Black outline
        }
        public void DrawHealthBar(short health, short maxHealth, float X, float Y, float height)
        {
            var vList = ImGui.GetForegroundDrawList();
            float healthPercentage = (float)health / maxHealth;
            float barHeight = height * healthPercentage;

            vList.AddRectFilled(new Vector2(X - 5, Y - 5), new Vector2(X + 120, Y + 20), ColorToUint32(Color.Black));

            vList.AddRectFilled(new Vector2(X - 5, Y), new Vector2(X + height, Y + 4), ColorToUint32(Color.White));
            vList.AddRectFilled(new Vector2(X + (height - barHeight), Y), new Vector2(X + height, Y + 4), ColorToUint32(Color.Red));
        }
        public void DrawGlowingBall(Vector2 position, Color color, float radius)
        {
            var drawList = ImGui.GetForegroundDrawList();
            uint ballColor = ColorToUint32(color);

            // Outer glow layers
            for (int i = 0; i < 5; i++)
            {
                float glowRadius = radius + (i * 2); // Increase radius for glow layers
                float alpha = 1.0f - (i * 0.2f);    // Gradually reduce alpha for each layer

                drawList.AddCircleFilled(
                    position,
                    glowRadius,
                    ImGui.ColorConvertFloat4ToU32(new Vector4(color.R / 255f, color.G / 255f, color.B / 255f, alpha)),
                    50 // Number of segments for smooth circle
                );
            }

            // Inner solid circle
            drawList.AddCircleFilled(position, radius, ballColor, 50);
        }

        
        public void DrawCorneredBox(float X, float Y, float W, float H, uint color, float thickness)
        {
            var vList = ImGui.GetForegroundDrawList();

            float lineW = W / 3;
            float lineH = H / 3;

            vList.AddLine(new Vector2(X, Y - thickness / 2), new Vector2(X, Y + lineH), color, thickness);
            vList.AddLine(new Vector2(X - thickness / 2, Y), new Vector2(X + lineW, Y), color, thickness);
            vList.AddLine(new Vector2(X + W - lineW, Y), new Vector2(X + W + thickness / 2, Y), color, thickness);
            vList.AddLine(new Vector2(X + W, Y - thickness / 2), new Vector2(X + W, Y + lineH), color, thickness);
            vList.AddLine(new Vector2(X, Y + H - lineH), new Vector2(X, Y + H + thickness / 2), color, thickness);
            vList.AddLine(new Vector2(X - thickness / 2, Y + H), new Vector2(X + lineW, Y + H), color, thickness);
            vList.AddLine(new Vector2(X + W - lineW, Y + H), new Vector2(X + W + thickness / 2, Y + H), color, thickness);
            vList.AddLine(new Vector2(X + W, Y + H - lineH), new Vector2(X + W, Y + H + thickness / 2), color, thickness);
        }

     
        static uint ColorToUint32(Color color)
        {
            return ImGui.ColorConvertFloat4ToU32(new Vector4(
                color.R / 255.0f,
                color.G / 255.0f,
                color.B / 255.0f,
                color.A / 255.0f));
        }

        void CreateHandle()
        {
            if (Config.StreamMode)
            {
                SetWindowDisplayAffinity(hWnd, WDA_EXCLUDEFROMCAPTURE);
            }
            else
            {
                SetWindowDisplayAffinity(hWnd, WDA_NONE);
            }
            RECT rect;
            GetWindowRect(Core.Handle, out rect);
            int x = rect.Left;
            int y = rect.Top;
            int width = rect.Right - rect.Left;
            int height = rect.Bottom - rect.Top;
            ImGui.SetWindowSize(new Vector2(width, height));
            ImGui.SetWindowPos(new Vector2(x, y));
            Size = new Size(width, height);
            Position = new Point(x, y);

            Core.Width = width;
            Core.Height = height;
        }

        // Função para desenhar o círculo de FOV
        public void DrawFOVCircle(float radius)
        {
            var drawList = ImGui.GetForegroundDrawList();
            var center = new Vector2(Core.Width / 2f, Core.Height / 2f);
            uint color = ColorToUint32(Config.FOVColor);

            drawList.AddCircle(center, radius, color, 0, 1f); // Desenha o círculo com borda
        }

        private float rotationAngle = 0f; // Rotation angle variable

        private void DrawShurikenCrosshair()
        {
            if (!Config.CrosshairEnabled) return;

            var drawList = ImGui.GetBackgroundDrawList();
            Vector2 center = new Vector2(Core.Width / 2f, Core.Height / 2f);
            float radius = Config.CrosshairSize;
            uint color = ColorToUint32(Config.CrosshairColor);

            // Number of blades
            int bladeCount = 4;
            float angleStep = 360f / bladeCount;

            // Draw each blade
            for (int i = 0; i < bladeCount; i++)
            {
                float angle = rotationAngle + i * angleStep;
                float angleInRadians = MathF.PI / 180f * angle;

                // Calculate the blade's points
                Vector2 point1 = new Vector2(
                    center.X + MathF.Cos(angleInRadians) * radius,
                    center.Y + MathF.Sin(angleInRadians) * radius
                );

                Vector2 point2 = new Vector2(
                    center.X + MathF.Cos(angleInRadians + MathF.PI / 6) * (radius / 2),
                    center.Y + MathF.Sin(angleInRadians + MathF.PI / 6) * (radius / 2)
                );

                Vector2 point3 = new Vector2(
                    center.X + MathF.Cos(angleInRadians - MathF.PI / 6) * (radius / 2),
                    center.Y + MathF.Sin(angleInRadians - MathF.PI / 6) * (radius / 2)
                );

                // Draw the blade
                drawList.AddTriangleFilled(point1, point2, point3, color);
            }

            // Increment rotation angle for animation
            rotationAngle += Config.CrosshairRotationSpeed;
            if (rotationAngle >= 360f) rotationAngle -= 360f;
        }
        public static uint AdjustAlpha(uint color, float alpha)
        {
            // Decompose the RGBA components
            byte r = (byte)(color >> 24);
            byte g = (byte)(color >> 16);
            byte b = (byte)(color >> 8);
            byte a = (byte)(color);

            // Scale and clamp alpha to 0-255
            a = (byte)Math.Clamp(alpha * 255f, 0, 255);

            // Apply an optional tint effect (e.g., make the color slightly warmer)
            float tintFactor = 1.1f; // Slightly increase red and green components
            r = (byte)Math.Clamp(r * tintFactor, 0, 255);
            g = (byte)Math.Clamp(g * tintFactor, 0, 255);

            // Introduce a brightness factor for dynamic adjustments
            float brightnessFactor = 1.05f; // Slightly brighten the color
            r = (byte)Math.Clamp(r * brightnessFactor, 0, 255);
            g = (byte)Math.Clamp(g * brightnessFactor, 0, 255);
            b = (byte)Math.Clamp(b * brightnessFactor, 0, 255);

            // Reassemble the color with adjusted alpha and optional effects
            return (uint)((r << 24) | (g << 16) | (b << 8) | a);
        }
        public void DrawFullBox(float X, float Y, float W, float H, uint color, float alpha)
        {
            var vList = ImGui.GetForegroundDrawList();


            vList.AddRectFilled(new Vector2(X, Y), new Vector2(X + W, Y + H), color & 0x00FFFFFF | ((uint)(alpha * 255) << 24));
        }






        private void RenderImgui()
        {
            ImGuiStylePtr style = ImGui.GetStyle();

            style.WindowBorderSize = 1f; 
            style.WindowRounding = 8f;  
            style.Colors[(int)ImGuiCol.Border] = new Vector4(83 / 255f, 195 / 255f, 189 / 255f, 1f); 
            style.Colors[(int)ImGuiCol.TitleBgActive] = new Vector4(83 / 255f, 195 / 255f, 189 / 255f, 1f); 
            style.Colors[(int)ImGuiCol.Text] = new Vector4(1, 1, 1, 1f);
            style.Colors[(int)ImGuiCol.Tab] = new Vector4(83 / 255f, 195 / 255f, 189 / 255f, 1f);
            style.Colors[(int)ImGuiCol.TabHovered] = new Vector4(0 / 255f, 255 / 255f, 255 / 255f, 1f);
            style.Colors[(int)ImGuiCol.TabActive] = new Vector4(0 / 255f, 255 / 255f, 255 / 255f, 1f);
            style.Colors[(int)ImGuiCol.FrameBg] = new Vector4(83 / 255f, 195 / 255f, 189 / 255f, 1f);
            style.Colors[(int)ImGuiCol.FrameBgHovered] = new Vector4(0 / 255f, 255 / 255f, 255 / 255f, 1f);
            style.Colors[(int)ImGuiCol.FrameBgActive] = new Vector4(0 / 255f, 255 / 255f, 255 / 255f, 1f);
            style.Colors[(int)ImGuiCol.CheckMark] = new Vector4(0 / 255f, 0 / 255f, 0 / 255f, 1f);
            style.Colors[(int)ImGuiCol.SliderGrab] = new Vector4(0 / 255f, 128 / 255f, 0 / 255f, 1f);       
            style.Colors[(int)ImGuiCol.SliderGrabActive] = new Vector4(0 / 255f, 150 / 255f, 0 / 255f, 1f);
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(83 / 255f, 195 / 255f, 189 / 255f, 1f));
            ImGui.PushStyleColor(ImGuiCol.ButtonHovered, new Vector4(0 / 255f, 255 / 255f, 255 / 255f, 1f));
            ImGui.PushStyleColor(ImGuiCol.ButtonActive, new Vector4(0 / 255f, 255 / 255f, 255 / 255f, 1f));
            

            ImGui.SetNextWindowSize(new Vector2(500, 400));
            ImGui.Begin("SKY Internal");

            if (ImGui.BeginTabBar("#MainTabBar"))
            {

                if (ImGui.BeginTabItem("Aim Hacks"))
                {

                    ImGui.Checkbox("Aimbot", ref Config.AimBot);
                 

                    ImGui.Checkbox("Ignore Knocked", ref Config.IgnoreKnocked);

                    ImGui.Checkbox("No Recoil", ref Config.NoRecoil);

                  


                    ImGui.Checkbox("Aimfov Circle", ref Config.FOVEnabled);
                    ImGui.SameLine();
                    ImGui.ColorEdit4("Aimfov Color", ref fovColor, ImGuiColorEditFlags.PickerMask | ImGuiColorEditFlags.NoInputs);
                    {
                        Config.FOVColor = Color.FromArgb(
                                                (int)(fovColor.W * 255),
                                                (int)(fovColor.X * 255),
                                                (int)(fovColor.Y * 255),
                                                (int)(fovColor.Z * 255)
                                                            );
                    }



                    ImGui.SliderFloat("AimFov Size", ref Config.AimFov, 0, 1000);

                    ImGui.SliderInt("Smoothness", ref AimBotSmooth, 0, 50);

                    ImGui.EndTabItem();

                }
                if (ImGui.BeginTabItem("Extra"))
                {
                    ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2(8, 6));
                    ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, 2.0f);
                    ImGui.NewLine();
                   if (ImGui.Button("Sniper Switch"))
                    {
                        sniper();
                    }
                    ImGui.NewLine();
                    if (ImGui.Button("Sniper Scope"))
                    {
                        sniperScope();
                    }
                    ImGui.NewLine();
                    if (ImGui.Button("All gun switch"))
                    {
                        sniperDelayFix();
                    }

                    ImGui.NewLine();
                    if (ImGui.Button("Load Speed"))
                    {
                        loadSpeed();
                    }

                    ImGui.SameLine();


                    if (ImGui.Button("Speed On"))
                    {
                        speedOn();
                    }
                    ImGui.SameLine();
                    if (ImGui.Button("Speed Off"))
                    {
                        speedOff();
                    }
                    ImGui.NewLine();

                    if (ImGui.Button("Load Wallhack"))
                    {
                        loadWall();
                    }
                    ImGui.SameLine();
                    if (ImGui.Button("Wallhack On"))
                    {
                        wallOn();
                    }
                    ImGui.SameLine();
                    if (ImGui.Button("Wallhack Off"))
                    {
                        wallOff();
                    }
                    ImGui.NewLine();
                    if (ImGui.Button("Camera Load"))
                    {
                        loadCamera();
                    }
                    ImGui.SameLine();
                    if (ImGui.Button("Camera On"))
                    {
                        cameraOn();
                    }
                    ImGui.SameLine();
                    if (ImGui.Button("Camera Off"))
                    {
                        cameraOff();
                    }

                    ImGui.PopStyleVar(2);
                    ImGui.EndTabItem();

                }

                if (ImGui.BeginTabItem("Visuals"))
                {

                    ImGui.Checkbox("ESP Line", ref Config.ESPLine);
                    ImGui.SameLine();
                    ImGui.ColorEdit4("ESP Line Color", ref lineColor, ImGuiColorEditFlags.PickerMask | ImGuiColorEditFlags.NoInputs);
                    {
                        Config.ESPLineColor = Color.FromArgb(
                                                (int)(lineColor.W * 255), 
                                                (int)(lineColor.X * 255),  
                                                (int)(lineColor.Y * 255),  
                                                (int)(lineColor.Z * 255)   
                                                            );
                    }

                    string[] linePositions = Enum.GetNames(typeof(LinePosition));
                    int selectedPosition = (int)Config.ESPLinePosition;

                    if (ImGui.BeginCombo("ESP Line Position", linePositions[selectedPosition]))
                    {
                        for (int i = 0; i < linePositions.Length; i++)
                        {
                            bool isSelected = (selectedPosition == i);
                            if (ImGui.Selectable(linePositions[i], isSelected))
                            {
                                selectedPosition = i;
                                Config.ESPLinePosition = (LinePosition)selectedPosition; 
                            }

                            if (isSelected)
                                ImGui.SetItemDefaultFocus();
                        }
                        ImGui.EndCombo();
                    }
                    

                    
                   

                    ImGui.Checkbox("ESP  Box", ref Config.ESPBox);
                    ImGui.SameLine();
                    ImGui.ColorEdit4("ESP  Box Color", ref boxColor, ImGuiColorEditFlags.PickerMask | ImGuiColorEditFlags.NoInputs);
                    {
                        Config.ESPBoxColor = Color.FromArgb(
                                                (int)(boxColor.W * 255),
                                                (int)(boxColor.X * 255),
                                                (int)(boxColor.Y * 255),
                                                (int)(boxColor.Z * 255)
                                                            );
                    }
                    ImGui.Checkbox("ESP Name", ref Config.ESPName);
                    ImGui.Checkbox("ESP Health", ref Config.ESPHealth);
                    ImGui.Checkbox("ESP Skeleton ", ref Config.ESPSkeleton);
                    ImGui.SameLine();
                    ImGui.ColorEdit4("ESP  Skeleton Color", ref skeletonColor, ImGuiColorEditFlags.PickerMask | ImGuiColorEditFlags.NoInputs);
                    {
                        Config.ESPSkeletonColor = Color.FromArgb(
                                                (int)(skeletonColor.W * 255),
                                                (int)(skeletonColor.X * 255),
                                                (int)(skeletonColor.Y * 255),
                                                (int)(skeletonColor.Z * 255)
                                                            );
                    }
                    ImGui.Checkbox("ESP Crosshair", ref Config.CrosshairEnabled);
                    ImGui.SameLine();
                    ImGui.ColorEdit4("ESP Crosshair Color", ref crossColor, ImGuiColorEditFlags.PickerMask | ImGuiColorEditFlags.NoInputs);
                    {
                        Config.CrosshairColor = Color.FromArgb(
                                                (int)(crossColor.W * 255),
                                                (int)(crossColor.X * 255),
                                                (int)(crossColor.Y * 255),
                                                (int)(crossColor.Z * 255)
                                                            );
                    }

                    if (ImGui.Button("Refresh ESP"))
                    {
                        NoCache();
                    }

                    if (ImGui.Button("Update Entities"))
                    {
                        UpdateEntities();
                    }

                    ImGui.SliderFloat("Crosshair Size", ref Config.CrosshairSize, 0, 100);
                    ImGui.SliderFloat("Crosshair Rotation Speed", ref Config.CrosshairRotationSpeed, 0, 100);

                    ImGui.EndTabItem();

                }


                if (ImGui.BeginTabItem("Settings"))
                {
                    ImGui.Checkbox("Stream Mode", ref Config.StreamMode);
                    bool close = false;
                    ImGui.Checkbox("Close Panel", ref close);
                    {
                        if(close)
                        {
                            KillProcess("HD-Adb");
                            Task.Delay(2000);
                            KillProcess("HD-Player");
                            Task.Delay(1000);
                            Environment.Exit(0);
                        }
                    }


                    ImGui.EndTabItem();

                }


                ImGui.EndTabBar();

            }


            ImGui.End();
        }


        public void KillProcess(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            foreach (var process in processes)
            {
                process.Kill();
                process.WaitForExit();
            }
        }


    }

   
}