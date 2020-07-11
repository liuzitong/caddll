using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Geometry;
using System.Windows.Forms;
using Autodesk.AutoCAD.Windows;
using Application = Autodesk.AutoCAD.ApplicationServices.Core.Application;


[assembly: ExtensionApplication(typeof(cadDll.Init))]
[assembly: CommandClass(typeof(cadDll.Commands))]
namespace cadDll
{
    public static class GlobalVarible
    {
        public static readonly Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
        public static PaletteSet ps;
    }
    public class Init : IExtensionApplication
    {
       
        public void Initialize()
        {
            UserControl2 userControl2 = new UserControl2();
            PaletteSet ps = new PaletteSet("面板");
            ps.Size = new System.Drawing.Size(userControl2.Width, userControl2.Height);
            ps.Style = PaletteSetStyles.ShowCloseButton;
            ps.Add("用户控件", userControl2);
            ps.Visible = true;

            GlobalVarible.ed.WriteMessage("helloWorld.");
        }

        public void Terminate()
        {
            GlobalVarible.ed.WriteMessage("bye world.");
        }
    }

    public class Commands
    {
        [CommandMethod("Hello")]
        public void Hello()
        {
            GlobalVarible.ed.WriteMessage("hello world.This is cad dll test.");
        }
  
    }
}
