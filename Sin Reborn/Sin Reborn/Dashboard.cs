/*
 * "To the dreams of my childhood ~
 *                                  Farewell"
 *                                  
 * XenusVale presents:
 * 
 *      Final Fantasy X: Sin Reborn
 */

using System;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Sin_Reborn
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        #region Global Variable Declaration

        public static double statMultiplier = 1.0;

        public static double apMultiplier = 1.0;

        public static int ffxEntryPointAddress = 0x00;

        public static int[] apGainHolder =
            { 0, 0, 0, 0, 0, 0, 0, 0,
              0, 0, 0, 0, 0, 0, 0, 0,
              0, 0 };

        public static bool wasInCombat = false;

        public static bool firstPass = true;

        public static bool gameHasBeenOn = false;

        public static bool scalingDifficultyEnabled = false;

        #endregion

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.Location = Properties.Settings.Default.dashboardLocation;
            nightmareRadioButton.Checked = Properties.Settings.Default.nightmareRadioButton;
            chimeraRadioButton.Checked = Properties.Settings.Default.chimeraRadioButton;
            customRadioButton.Checked = Properties.Settings.Default.customRadioButton;
            statNumericUpDown.Value = Properties.Settings.Default.statMultiplierNumeric;
            apNumericUpDown.Value = Properties.Settings.Default.apMultiplierNumeric;
            scalingDifficultyCheckBox.Checked = Properties.Settings.Default.scalingCheckBox;
        }

        private void Dashboard_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) //Minimize to system tray
            {
                this.Hide();
            }
        }

        private void TrayNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Dashboard_FormClosing(object sender, EventArgs e)
        {
            Properties.Settings.Default.dashboardLocation = this.Location;
            Properties.Settings.Default.Save();
        }

        private void NightmareRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            FieldUpdater();
        }

        private void ChimeraRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            FieldUpdater();
        }

        private void CustomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            FieldUpdater();
        }

        private void StatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.statMultiplierNumeric = statNumericUpDown.Value;
            Properties.Settings.Default.Save();
            FieldUpdater();
        }

        private void APNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.apMultiplierNumeric = (decimal)apNumericUpDown.Value;
            Properties.Settings.Default.Save();
            FieldUpdater();
        }

        private void ScalingDifficultyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.scalingCheckBox = scalingDifficultyCheckBox.Checked;
            Properties.Settings.Default.Save();
            FieldUpdater();
        }

        private void Dashboard_MouseMove(object sender, MouseEventArgs e)
        {
            IWin32Window invisibleWindow = this;
            Point mouseLocationCentered = new Point((e.Location.X + 8), (e.Location.Y + 49));

            if (scalingDifficultyCheckBox.Bounds.Contains(e.Location)) //Display the Scaling Difficulty tooltip while the control is disabled
            {
                toolTips.Show("Increases the Stat Multiplier at predetermined checkpoints." +
                    " By 0.1 in Besaid, 0.1 in Kilika, 0.1 during Operation Mi'ihen, 0.1 in Guadosalam," +
                    " and 0.2 in the Calm Lands.", invisibleWindow, mouseLocationCentered);
            }
            else
            {
                toolTips.Hide(invisibleWindow);
            }
        }

        public void FieldUpdater()
        {
            if (nightmareRadioButton.Checked)
            {
                nightmareRadioButton.ForeColor = Color.White;
                chimeraRadioButton.ForeColor = Color.DimGray;
                if (customRadioButton.ForeColor == Color.White)
                {
                    ReverseCustom();
                }

                Properties.Settings.Default.nightmareRadioButton = true;
                Properties.Settings.Default.chimeraRadioButton = false;
                Properties.Settings.Default.customRadioButton = false;
                Properties.Settings.Default.Save();

                firstPass = true;
                scalingDifficultyEnabled = true;
                statMultiplier = 1.6;
                apMultiplier = 0.6;
            }
            else if (chimeraRadioButton.Checked)
            {
                chimeraRadioButton.ForeColor = Color.White;
                nightmareRadioButton.ForeColor = Color.DimGray;
                if (customRadioButton.ForeColor == Color.White)
                {
                    ReverseCustom();
                }

                Properties.Settings.Default.chimeraRadioButton = true;
                Properties.Settings.Default.nightmareRadioButton = false;
                Properties.Settings.Default.customRadioButton = false;
                Properties.Settings.Default.Save();

                firstPass = true;
                scalingDifficultyEnabled = true;
                statMultiplier = 1.3;
                apMultiplier = 0.8;
            }
            else
            {
                nightmareRadioButton.ForeColor = Color.DimGray;
                chimeraRadioButton.ForeColor = Color.DimGray;
                if (customRadioButton.ForeColor == Color.DimGray)
                {
                    ReverseCustom();
                }

                Properties.Settings.Default.customRadioButton = true;
                Properties.Settings.Default.nightmareRadioButton = false;
                Properties.Settings.Default.chimeraRadioButton = false;
                Properties.Settings.Default.Save();

                firstPass = true;
                scalingDifficultyEnabled = scalingDifficultyCheckBox.Checked;
                statMultiplier = (double)statNumericUpDown.Value;
                apMultiplier = (double)apNumericUpDown.Value;
            }
        }

        public void ReverseCustom()
        {
            if (customRadioButton.ForeColor == Color.White)
            {
                customRadioButton.ForeColor = Color.DimGray;
                statMultiplierLabel.ForeColor = Color.DimGray;
                apMultiplierLabel.ForeColor = Color.DimGray;
            }
            else
            {
                customRadioButton.ForeColor = Color.White;
                statMultiplierLabel.ForeColor = Color.White;
                apMultiplierLabel.ForeColor = Color.White;
            }

            statNumericUpDown.Enabled = !statNumericUpDown.Enabled;
            apNumericUpDown.Enabled = !apNumericUpDown.Enabled;
            scalingDifficultyCheckBox.Enabled = !scalingDifficultyCheckBox.Enabled;
        }

        private void RunMods_Tick(object sender, EventArgs e)
        {
            if ((Process.GetProcessesByName("FFX").Length > 0) && (ffxEntryPointAddress == 0x00))
            {
                gameHasBeenOn = true;
                Process[] ffxProcess = Process.GetProcessesByName("FFX");

                try
                {
                    foreach (ProcessModule ffxProcessModule in ffxProcess[0].Modules)
                    {
                        if (ffxProcessModule.ModuleName.Equals("FFX.exe"))
                        {
                            ffxEntryPointAddress = (int)(ffxProcessModule.BaseAddress);
                        }
                    }
                }
                catch
                {
                    Environment.Exit(0);
                }
            }
            else if ((Process.GetProcessesByName("FFX").Length <= 0) && (gameHasBeenOn))
            {
                Environment.Exit(0);
            }

            if ((nightmareRadioButton.Checked || chimeraRadioButton.Checked || customRadioButton.Checked) && gameHasBeenOn)
            {
                Sin_Reborn sin = new Sin_Reborn();
                sin.DifficultyMod();
            }
        }
    }

    class Memory
    {
        [DllImport("kernel32.dll")]
        public static extern int OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, int size, int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, int size, int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        public static extern Int32 CloseHandle(IntPtr hProcess);

        public static Process ffx = Process.GetProcessesByName("FFX").FirstOrDefault();

        public static uint Initialization()
        {
            uint delete = 0x00010000;
            uint read = 0x00020000;
            uint writeDAC = 0x00040000;
            uint writeOwner = 0x00080000;
            uint sync = 0x00100000;
            uint end = 0xFFF;
            uint fullControl = (delete | read | writeDAC | writeOwner | sync | end);

            return fullControl;
        }

        public static int ReadInt32(IntPtr address)
        {
            uint fullControl = Initialization();

            IntPtr authorization = (IntPtr)OpenProcess(fullControl, false, Memory.ffx.Id);

            byte[] bytesToBeReadBuffer = new byte[4];
            ReadProcessMemory(authorization, address, bytesToBeReadBuffer, bytesToBeReadBuffer.Length, 0);

            int valueToBeReturned = BitConverter.ToInt32(bytesToBeReadBuffer, 0);

            CloseHandle(authorization);

            return valueToBeReturned;
        }

        public static byte[] ReadByteArray(IntPtr address, int numOfBytesToBeRead)
        {
            uint fullControl = Initialization();

            IntPtr authorization = (IntPtr)OpenProcess(fullControl, false, Memory.ffx.Id);

            byte[] bytesToBeReadBuffer = new byte[numOfBytesToBeRead];
            ReadProcessMemory(authorization, address, bytesToBeReadBuffer, numOfBytesToBeRead, 0);

            CloseHandle(authorization);

            return bytesToBeReadBuffer;
        }

        public static void WriteInt32(IntPtr address, int valueToBeWritten)
        {
            uint fullControl = Initialization();

            IntPtr authorization = (IntPtr)OpenProcess(fullControl, false, Memory.ffx.Id);

            byte[] bytesToBeWritten = BitConverter.GetBytes(valueToBeWritten);
            WriteProcessMemory(authorization, address, bytesToBeWritten, bytesToBeWritten.Length, 0);

            CloseHandle(authorization);
        }

        public static void WriteByteArray(IntPtr address, byte[] bytesToBeWritten)
        {
            uint fullControl = Initialization();

            IntPtr authorization = (IntPtr)OpenProcess(fullControl, false, Memory.ffx.Id);

            WriteProcessMemory(authorization, address, bytesToBeWritten, bytesToBeWritten.Length, 0);

            CloseHandle(authorization);
        }
    }

    public class Functions
    {
        static public void StatChange(int enemyDifficulty, int cHP, int cMP, int mHP, int mMP, int stats)
        {
            int finalAddress = enemyDifficulty + cHP; //Change the current health pool
            int enemyValue = Memory.ReadInt32((IntPtr)finalAddress);
            enemyValue = (int)(enemyValue * Dashboard.statMultiplier);
            Memory.WriteInt32((IntPtr)finalAddress, enemyValue);

            finalAddress = enemyDifficulty + cMP; //Change the current mana pool
            enemyValue = Memory.ReadInt32((IntPtr)finalAddress);
            enemyValue = (int)(enemyValue * Dashboard.statMultiplier);
            Memory.WriteInt32((IntPtr)finalAddress, enemyValue);

            finalAddress = enemyDifficulty + mHP; //Change the max health pool
            enemyValue = Memory.ReadInt32((IntPtr)finalAddress);
            enemyValue = (int)(enemyValue * Dashboard.statMultiplier);
            Memory.WriteInt32((IntPtr)finalAddress, enemyValue);

            finalAddress = enemyDifficulty + mMP; //Change the max mana pool
            enemyValue = Memory.ReadInt32((IntPtr)finalAddress);
            enemyValue = (int)(enemyValue * Dashboard.statMultiplier);
            Memory.WriteInt32((IntPtr)finalAddress, enemyValue);

            finalAddress = enemyDifficulty + stats;
            byte[] allTheStats = Memory.ReadByteArray((IntPtr)finalAddress, 8);

            for (int i = 0; i < 8; i++) //Change the 6 desired stats
            {
                if ((!(i == 5)) && (!(i == 6)))
                {
                    int verifyStat = (int)(allTheStats[i] * Dashboard.statMultiplier);

                    if (verifyStat > 255) //If the stat is over 255, set it to the maximum (255)
                    {
                        allTheStats[i] = 255;
                    }
                    else if (verifyStat < 1) //If the stat is below 1, set it to 1
                    {
                        allTheStats[i] = 1;
                    }
                    else
                    {
                        allTheStats[i] = (byte)verifyStat;
                    }
                }
            }

            Memory.WriteByteArray((IntPtr)finalAddress, allTheStats);
        }
    }

    class Sin_Reborn
    {
        public void DifficultyMod()
        {
            int basecHP = 0x5D0;
            int basecMP = 0x5D4;
            int basemHP = 0x594;
            int basemMP = 0x598;
            int baseStats = 0x5A8;
            int[] apRefresh =
                { 0, 0, 0, 0, 0, 0, 0, 0,
                  0, 0, 0, 0, 0, 0, 0, 0,
                  0, 0 };
            int enemyAddress = (Dashboard.ffxEntryPointAddress + 0xD34460);
            int apGainAddress = (Dashboard.ffxEntryPointAddress + 0x1F10F20);

            int combatIdentifier = Memory.ReadInt32((IntPtr)enemyAddress);
            int combatIdentifierDelay = Memory.ReadInt32((IntPtr)(combatIdentifier + 0x5D0)); //Prevents the code from running before the enemies appear
            int storyProgress = Memory.ReadInt32((IntPtr)(Dashboard.ffxEntryPointAddress + 0x84949C));

            if (Dashboard.firstPass && Dashboard.scalingDifficultyEnabled) //Increase the difficulty based on story progression
            {
                if (storyProgress >= 2385) //In the Calm Lands
                {
                    Dashboard.statMultiplier += 0.6;
                }
                else if (storyProgress >= 1096) //In Guadosalam
                {
                    Dashboard.statMultiplier += 0.4;
                }
                else if (storyProgress >= 815) //During operation Mi'ihen
                {
                    Dashboard.statMultiplier += 0.3;
                }
                else if (storyProgress >= 302) //After Kilika sending
                {
                    Dashboard.statMultiplier += 0.2;
                }
                else if (storyProgress >= 215) //After Kimahri fight in Besaid
                {
                    Dashboard.statMultiplier += 0.1;
                }

                Dashboard.firstPass = false; //Do not allow the Stat Multiplier to be affected by this change more than once
            }

            if ((combatIdentifier > 0) && (combatIdentifierDelay > 0) && (!Dashboard.wasInCombat))
            {
                for (int i = 0; i < 8; i++)
                {
                    Functions.StatChange(combatIdentifier, basecHP, basecMP, basemHP, basemMP, baseStats);
                    basecHP += 0xF90;
                    basecMP += 0xF90;
                    basemHP += 0xF90;
                    basemMP += 0xF90;
                    baseStats += 0xF90;
                }

                Dashboard.wasInCombat = true;
            }

            apRefresh[0] = Memory.ReadInt32((IntPtr)apGainAddress); //Check what amount of Ability Points (AP) is yet to be given to the player in combat

            if ((apRefresh[0] > Dashboard.apGainHolder[0]) && (combatIdentifier > 0))
            {
                for (int n = 0; n < 18; n++) //Change the 18 AP holders
                {
                    apRefresh[n] = Memory.ReadInt32((IntPtr)(apGainAddress + (0x04 * n)));
                    apRefresh[n] = (int)(Dashboard.apGainHolder[n] + ((apRefresh[n] - Dashboard.apGainHolder[n]) * Dashboard.apMultiplier));
                    Memory.WriteInt32((IntPtr)(apGainAddress + (0x04 * n)), apRefresh[n]);
                    Dashboard.apGainHolder[n] = apRefresh[n];
                }
            }

            if ((combatIdentifier == 0) && Dashboard.wasInCombat)
            {
                for (int n = 0; n < 18; n++) //Reset the byte arrays that represent the 18 AP holders
                {
                    apRefresh[n] = 0;
                    Dashboard.apGainHolder[n] = 0;
                }

                Dashboard.wasInCombat = false;
            }
        }
    }
}

/*
 * The Reborn Project
 */
