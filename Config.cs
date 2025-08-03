using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AotForms
{
    internal static class Config
    {   
        public static bool CrosshairEnabled = false;
        public static Color CrosshairColor = Color.White;
        public static float CrosshairSize = 15f; // Size in pixels
        public static float CrosshairThickness = 2f; // Line thickness
        public static float CrosshairRotationSpeed = 2f; // Default speed

        internal static int AimBotSmooth = 20;
        internal static bool AimBot = false;
        internal static Keys AimbotKey = Keys.LButton; // Tecla padrão do aimbot
        internal static int AimBotMaxDistance = 100; // Distância máxima do aimbot
        internal static bool IgnoreKnocked = false;
        internal static bool UpdateEntities = false;
        internal static bool NoRecoil = false;
        internal static bool NoCache = false;
        internal static bool Speed = false;
        public static string AimTargetPart { get; set; } = "Head"; // Valor padrão
        internal static bool ESPLine = false;
        internal static int ESPLineGlow = 2;
        internal static bool SniperSwitch = false;
        internal static bool SniperDelay = false;
        internal static Color ESPLineColor = Color.White;
        public static float AimFov = 200f;
        internal static bool StreamMode = false;
        internal static Color NameCheat = Color.Cyan;
        internal static bool ESPBox = false;
        internal static bool ESPFillBox = false;
        internal static bool ESPHeartBox = false;
        internal static Color ESPBoxColor = Color.White;
        internal static bool ESPName = false;
        internal static Color ESPNameColor = Color.White;
        internal static bool ESPHealth = false;
        internal static Color ESPHealthColor = Color.Green;
        internal static bool ESPSkeleton = false;  
        internal static Color ESPSkeletonColor = Color.White;
        public static bool FOVEnabled = false;
        //public static float FOVRadius = 50f;
        public static Color FOVColor = Color.White;
        public static LinePosition ESPLinePosition = LinePosition.Top; 
  

    }

    public enum LinePosition
    {
        Top,
        Center,
        Bottom
    }
   
}
