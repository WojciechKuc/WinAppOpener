using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace LuaOpener
{
    public partial class Form1 : Form
    {
        Thread t = null;
        bool tCloser = false;
        public Form1()
        {
            InitializeComponent();
            t = new Thread(new ThreadStart(StatusChecker));
            t.IsBackground = true;
            t.Start();

             
        }

        private void StatusChecker()
        {
            
            while (!tCloser)
            {
                GetNotepadStatus();                
                GetCmdStatus();                
                GetPaintStatus();
                GetCalcStatus();
                GetWMPStatus();
                Thread.Sleep(1); 
            }
        }

      
        //metody do uruchamiania poszczegolnych skryptow
        
        static void EmbeddedResourceNotepadScriptLoader()
        {
            Script script = new Script();
            script.Options.ScriptLoader = new EmbeddedResourcesScriptLoader();
            script.DoFile("Scripts/Notepad.lua");
        }
        
        static void EmbeddedResourceCmdScriptLoader()
        {
            Script script = new Script();
            script.Options.ScriptLoader = new EmbeddedResourcesScriptLoader();
            script.DoFile("Scripts/Cmd.lua");
        }
        static void EmbeddedResourcePaintScriptLoader()
        {
            Script script = new Script();
            script.Options.ScriptLoader = new EmbeddedResourcesScriptLoader();
            script.DoFile("Scripts/Paint.lua");
        }
        static void EmbeddedResourceCalcScriptLoader()
        {
            Script script = new Script();
            script.Options.ScriptLoader = new EmbeddedResourcesScriptLoader();
            script.DoFile("Scripts/Calc.lua");
        }
        static void EmbeddedResourceWMPScriptLoader()
        {
            Script script = new Script();
            script.Options.ScriptLoader = new EmbeddedResourcesScriptLoader();
            script.DoFile("Scripts/WMP.lua");
        }
        

        public void GetNotepadStatus()
        {
            // Sprawdza czy kombinacja klawiszy shift+control+z jest wcisnieta
            var isShiftKeyDown = InputSimulator.IsKeyDown(VirtualKeyCode.SHIFT);
            var isCtrlKeyDown = InputSimulator.IsKeyDown(VirtualKeyCode.CONTROL);
            var isZKeyDown = InputSimulator.IsKeyDown(VirtualKeyCode.VK_Z);
            if (isShiftKeyDown & isCtrlKeyDown & isZKeyDown)
            {
                EmbeddedResourceNotepadScriptLoader();
                Application.Restart();
            }
        }
        public void GetCmdStatus()
        {
            // Sprawdza czy kombinacja klawiszy shift+control+x jest wcisnieta
            var isShiftKeyDown = InputSimulator.IsKeyDown(VirtualKeyCode.SHIFT);
            var isCtrlKeyDown = InputSimulator.IsKeyDown(VirtualKeyCode.CONTROL);
            var isXKeyDown = InputSimulator.IsKeyDown(VirtualKeyCode.VK_X);
            if (isShiftKeyDown & isCtrlKeyDown & isXKeyDown)
            {
                EmbeddedResourceCmdScriptLoader();
                Application.Restart();
            }
        }
        public void GetPaintStatus()
        {
            // Sprawdza czy kombinacja klawiszy shift+control+v jest wcisnieta
            var isShiftKeyDown = InputSimulator.IsKeyDown(VirtualKeyCode.SHIFT);
            var isCtrlKeyDown = InputSimulator.IsKeyDown(VirtualKeyCode.CONTROL);
            var isVKeyDown = InputSimulator.IsKeyDown(VirtualKeyCode.VK_V);
            if (isShiftKeyDown & isCtrlKeyDown & isVKeyDown)
            {
                EmbeddedResourcePaintScriptLoader();
                Application.Restart();
            }
        }

        public void GetCalcStatus()
        {
            // Sprawdza czy kombinacja klawiszy shift+control+ jest wcisnieta
            var isShiftKeyDown = InputSimulator.IsKeyDown(VirtualKeyCode.SHIFT);
            var isCtrlKeyDown = InputSimulator.IsKeyDown(VirtualKeyCode.CONTROL);
            var isUKeyDown = InputSimulator.IsKeyDown(VirtualKeyCode.VK_U);
            if (isShiftKeyDown & isCtrlKeyDown & isUKeyDown)
            {
                EmbeddedResourceCalcScriptLoader();
                Application.Restart();
            }
        }

        public void GetWMPStatus()
        {
            // Sprawdza czy kombinacja klawiszy shift+control+y jest wcisnieta
            var isShiftKeyDown = InputSimulator.IsKeyDown(VirtualKeyCode.SHIFT);
            var isCtrlKeyDown = InputSimulator.IsKeyDown(VirtualKeyCode.CONTROL);
            var isYKeyDown = InputSimulator.IsKeyDown(VirtualKeyCode.VK_Y);
            if (isShiftKeyDown & isCtrlKeyDown & isYKeyDown)
            {
                EmbeddedResourceWMPScriptLoader();
                Application.Restart();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            tCloser = true;
        }
        //wyłączenie aplikacji z menu kontekstowego
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tCloser = true;
            Application.Exit();
        }

        //ukrycie ikony z pasku startu
        
        private void Form1_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;  
            }
        }

       
    }
}
