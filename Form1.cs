using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GroceryApp
{
    public partial class Form1 : Form
    {
        
        private ListBox listBoxItems;
        private Button btnAddItems;
        private string filePath = "shoppinglist.json";

        public Form1()
        {
            this.Text = "Shopping List Viewer"; // 👈 Title of the form

            listBoxItems = new ListBox() { Top = 10, Left = 10, Width = 300, Height = 200 };
            btnAddItems = new Button() { Text = "Add Items", Top = 220, Left = 10 };

            btnAddItems.Click += BtnAddItems_Click;

            Controls.Add(listBoxItems);
            Controls.Add(btnAddItems);

            LoadShoppingList();
        }

        private void LoadShoppingList()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var items = JsonConvert.DeserializeObject<List<string>>(json);
                listBoxItems.DataSource = items;
            }
        }

        private void BtnAddItems_Click(object sender, EventArgs e)
        {
            var addForm = new AddItemsForm();
            addForm.ShowDialog();
            LoadShoppingList();
        }
    }
}
