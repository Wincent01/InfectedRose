using System;
using System.IO;
using Eto.Forms;

namespace InfectedRose.Examples
{
    public class AccessDatabaseCommand : Command
    {
        public string Macro = $"{Application.Instance.CommonModifier} + {Keys.O}";
        
        private AccessEditor Editor { get; }

        public AccessDatabaseCommand(AccessEditor editor)
        {
            Editor = editor;
            
            MenuText = "Open...";

            ToolBarText = "Open a Database";

            ToolTip = "Open a Database of Access type";

            Shortcut = Application.Instance.CommonModifier | Keys.O;
        }

        protected override void OnExecuted(EventArgs e)
        {
            base.OnExecuted(e);

            var dialog = new OpenFileDialog();

            dialog.Filters.Add(new FileFilter("*.fdb", ".fdb"));
            dialog.Filters.Add(new FileFilter("*"));

            dialog.ShowDialog(Editor);

            Console.WriteLine(dialog.FileName);

            if (File.Exists(dialog.FileName))
            {
                Editor.OpenDatabase(dialog.FileName);
            }
        }
    }
}