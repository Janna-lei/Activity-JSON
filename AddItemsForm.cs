using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GroceryApp
{
    public partial class AddItemsForm : Form
    {   
        
        private TextBox txtItem;
        private Button btnAdd, btnSave;
        private ListBox listBoxAddedItems;
        private List<string> items = new List<string>();
        private string filePath = "shoppinglist.json";

        public AddItemsForm()
        {
            this.Text = "Add Grocery Items"; // 👈 Title of the form

            txtItem = new TextBox() { Top = 10, Left = 10, Width = 200 };
            btnAdd = new Button() { Text = "Add", Top = 10, Left = 220 };
            listBoxAddedItems = new ListBox() { Top = 50, Left = 10, Width = 300, Height = 150 };
            btnSave = new Button() { Text = "Save", Top = 210, Left = 10 };

            btnAdd.Click += BtnAdd_Click;
            btnSave.Click += BtnSave_Click;

            Controls.Add(txtItem);
            Controls.Add(btnAdd);
            Controls.Add(listBoxAddedItems);
            Controls.Add(btnSave);
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtItem.Text.Trim() == "") return;

            if (items.Count >= 5)
            {
                MessageBox.Show("Maximum of 5 items allowed!");
                return;
            }

            items.Add(txtItem.Text.Trim());
            listBoxAddedItems.DataSource = null;
            listBoxAddedItems.DataSource = new List<string>(items);
            txtItem.Clear();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(items, Formatting.Indented));
            MessageBox.Show("Items saved.");
            this.Close();
        }
    }
}
