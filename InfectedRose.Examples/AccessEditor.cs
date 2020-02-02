using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Eto.Drawing;
using Eto.Forms;
using InfectedRose.Database;

namespace InfectedRose.Examples
{
    public sealed class AccessEditor : Form
    {
        public AccessDatabase Database { get; set; }
        
        public TableLayout MainTable { get; set; }
        
        public List<DualBinding<string>> Bindings { get; }

        public string Status { get; set; }

        public AccessEditor()
        {
            Bindings = new List<DualBinding<string>>();
            
            Title = "Access Editor";
            
            ClientSize = new Size
            {
                Height = 400,
                Width = 640
            };

            Resizable = true;

            var accessCommand = new AccessDatabaseCommand(this);
            
            var menu = new MenuBar
            {
                Items =
                {
                    new ButtonMenuItem
                    {
                        Text = "File",
                        Items =
                        {
                            accessCommand
                        }
                    }
                }
            };
            
            Menu = menu;

            Status = $"Open a database by using Open/File or {accessCommand.Macro}";
            
            MainTable = new TableLayout
            {
                Spacing = new Size(1, 3), // space between each cell
                Padding = new Padding(10, 10, 10, 10), // space around the table's sides
                Rows =
                {
                    new TableRow(
                        new TableCell(StatusBinding(), true)
                    ),
                    new TableRow(
                        
                    ),
                    new TableRow { ScaleHeight = true }
                }
            };

            Content = MainTable;
        }

        private Label StatusBinding()
        {
            var label = new Label();

            var binding = label.TextBinding.Bind(() => Status);

            Bindings.Add(binding);

            return label;
        }

        public void Update()
        {
            foreach (var binding in Bindings)
            {
                binding.Update();
            }
        }

        public void OpenDatabase(string path)
        {
            Status = "Opening database...";
            
            Console.WriteLine("Opening db");

            Task.Run(async () =>
            {
                try
                {
                    Database = await AccessDatabase.OpenAsync(path);
                    
                    ShowDatabase();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                    Status = "Failed to load database.";
                    
                    return;
                }

                Status = "Database loaded...";
            });
        }

        public void ShowDatabase()
        {
            /*
            Editor = new TableLayout
            {
                Spacing = new Size(2, Database.Count), // space between each cell
                Padding = new Padding(10, 10, 10, 10), // space around the table's sides
            };

            foreach (var table in Database)
            {
                var editor = (TableLayout) Editor;
                
                editor.Rows.Add(new TableRow
                (
                    new TableCell(new Label {Text = table.Name})
                ));
            }
            */
        }
    }
}