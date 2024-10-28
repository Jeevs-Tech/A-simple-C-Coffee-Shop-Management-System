using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Simple_CoffeShop_System
{
    public partial class Coffee : Form
    {
        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;

        public Coffee()
        {
            InitializeComponent();

            // Initialize dataGridView1 columns
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Type";
            dataGridView1.Columns[3].Name = "Quantity";
            dataGridView1.Columns[4].Name = "Payment";

            // Initialize PrintDocument and PrintPreviewDialog
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            // Initialize the PrintPreviewDialog
            printPreviewDialog = new PrintPreviewDialog
            {
                Document = printDocument,
                ClientSize = new Size(600, 800),
                UseAntiAlias = true,
                StartPosition = FormStartPosition.CenterScreen
            };
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Save button clicked.");

                // Ensure the ComboBox and Quantity are not null or empty
                if (name_combo.SelectedItem != null && type_combo.SelectedItem != null && !string.IsNullOrEmpty(quantity_combo.Text))
                {
                    float price = 0;
                    string name = name_combo.SelectedItem.ToString();
                    string type = type_combo.SelectedItem.ToString();
                    int quantity = int.Parse(quantity_combo.Text);

                    // Price calculation logic
                    if (name == "Coffee")
                    {
                        price = type == "Hot" ? 100 : type == "Ice" ? 90 : 95;
                    }
                    else if (name == "Doot pati")
                    {
                        price = type == "Hot" ? 110 : type == "Ice" ? 96 : 80;
                    }
                    else if (name == "Green Tea")
                    {
                        price = type == "Hot" ? 120 : type == "Ice" ? 115 : 90;
                    }
                    else if (name == "Normal tea")
                    {
                        price = type == "Hot" ? 100 : type == "Ice" ? 90 : 95;
                    }
                    else
                    {
                        MessageBox.Show("Please select a valid item name.");
                        return;
                    }

                    payment_textbox.Text = (quantity * price).ToString();

                    // Add data to dataGridView1
                    dataGridView1.Rows.Add(id_textbox.Text, name, type, quantity, payment_textbox.Text);
                }
                else
                {
                    MessageBox.Show("Please select an item name, type, and enter a quantity.");
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"A null reference error occurred: {ex.Message}");
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Please enter a valid quantity: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Clear input fields
            id_textbox.Text = "";
            name_combo.SelectedIndex = -1;     // Clear the selected item for name_combo
            type_combo.SelectedIndex = -1;     // Clear the selected item for type_combo
            quantity_combo.SelectedIndex = -1; // Clear the selected item for quantity_combo
            payment_textbox.Text = "";
            dataGridView1.Rows.Clear();

        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            // Check if there's anything to print
            if (dataGridView1.Rows.Count > 0)
            {
                // Show the print preview dialog
                printPreviewDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("There are no items to print.");
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Set up the font and starting position
            Font font = new Font("Arial", 12);
            float startY = 10;
            float offsetY = 25;

            // Print a header
            e.Graphics.DrawString("Coffee Shop Receipt", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 10, startY);
            startY += offsetY;

            // Iterate through dataGridView1 rows and print each row's content
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string id = row.Cells[0].Value?.ToString() ?? "";
                string name = row.Cells[1].Value?.ToString() ?? "";
                string type = row.Cells[2].Value?.ToString() ?? "";
                string quantity = row.Cells[3].Value?.ToString() ?? "";
                string payment = row.Cells[4].Value?.ToString() ?? "";

                string line = $"ID: {id}, Name: {name}, Type: {type}, Quantity: {quantity}, Payment: {payment}";
                e.Graphics.DrawString(line, font, Brushes.Black, 10, startY);
                startY += offsetY;
            }
        }
    }
}
