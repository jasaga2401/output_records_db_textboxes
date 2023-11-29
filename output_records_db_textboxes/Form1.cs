using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace output_records_db_textboxes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 900;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string connectionString = "Data Source=Amaze\\SQLEXPRESS;Initial Catalog=email_db;Integrated Security=True"; 
            string query = "SELECT * FROM tbl_user"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // counting the number of records
                    int recordCount = 0;

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    int topPosition = 20; // Adjust the initial position based on your layout

                    while (reader.Read())
                    {
                        
                        int leftPosition = 20; // Adjust the initial position based on your layout

     
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine(reader[i].ToString());

                            TextBox textBox = new TextBox
                            {
                                Name = "textBox" + i.ToString(),
                                Text = reader[i].ToString(),
                                Top = topPosition,
                                Left = leftPosition,
                                TextAlign = HorizontalAlignment.Center,
                                Width = 150,
                                Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Regular)
                        };

                            Console.WriteLine("i: " + i.ToString());

                            if (i % 3 == 0 && i != 0)
                            {
                                textBox.Width = 320;
                            }

                            // Add the textbox to the form
                            this.Controls.Add(textBox);

                            // Update positions for the next textbox
                            //topPosition += 25; // Adjust the vertical spacing based on your layout
                            leftPosition += 160; // Adjust the horizontal spacing based on your layout
                        }

                        recordCount++;
                        topPosition += 40;
                    }

                    Label label1 = new Label();
                    label1.Text = "Total Records: " + recordCount.ToString();
                    label1.Top = 260;
                    label1.Left = 20;

                    // Add the textbox to the form
                    this.Controls.Add(label1);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

        }
    }
}
