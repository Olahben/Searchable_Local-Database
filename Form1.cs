using System.Data;
using System.Data.SqlClient;

namespace Søkbar_Database3
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        HttpClient httpClient;
        Dictionary<string, string> driverPhotos;

        public Form1()
        {
            InitializeComponent();
            string mdfFilePath = SetDataDirectory(); // Call method to set the data directory and get the MDF file path
            connection = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={mdfFilePath};Integrated Security=True;");
            httpClient = new HttpClient();
            driverPhotos = new Dictionary<string, string>();
            AddPredefinedUsers();
            display_data();
        }

        private string SetDataDirectory()
        {
            // Get the path to the Documents folder
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Combine the Documents path with the file name of your MDF file
            string mdfFilePath = Path.Combine(documentsPath, "DB_Server.mdf");

            // Set the data directory to the folder containing the database file
            AppDomain.CurrentDomain.SetData("DataDirectory", mdfFilePath);

            return mdfFilePath; // Return the MDF file path
        }



        private void AddPredefinedUsers()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;

                // Check if the table is empty
                cmd.CommandText = "SELECT COUNT(*) FROM [MyTable]";
                int count = (int)cmd.ExecuteScalar();

                // If the table is empty, insert predefined users
                if (count == 0)
                {
                    cmd.CommandText = @"
                INSERT INTO [MyTable] (Navn, Team, Bil, Alder, Startnummer) VALUES 
                ('Max Verstappen', 'Red Bull Racing', 'RB20', 26, 1),
                ('Sergio Perez', 'Red Bull Racing', 'RB20', 34, 11),
                ('Lewis Hamilton', 'Mercedes', 'W15', 39, 44),
                ('George Russell', 'Mercedes', 'W15', 26, 63),
                ('Charles Leclerc', 'Ferrari', 'SF-24', 26, 16),
                ('Carlos Sainz', 'Ferrari', 'SF-24', 30, 55),
                ('Lando Norris', 'McLaren', 'MCL60', 24, 4),
                ('Oscar Piastri', 'McLaren', 'MCL60', 23, 81),
                ('Fernando Alonso', 'Aston Martin', 'AMR24', 42, 14),
                ('Lance Stroll', 'Aston Martin', 'AMR24', 25, 18),
                ('Pierre Gasly', 'Alpine', 'A524', 28, 10),
                ('Esteban Ocon', 'Alpine', 'A524', 27, 31),
                ('Kevin Magnussen', 'Haas', 'VF-24', 31, 20),
                ('Nico Hulkenberg', 'Haas', 'VF-24', 36, 27),
                ('Valtteri Bottas', 'Kick Sauber', 'C44', 34, 77),
                ('Zhou Guanyu', 'Kick Sauber', 'C44', 25, 24),
                ('Yuki Tsunoda', 'RB', 'AT05', 23, 22),
                ('Daniel Ricciardo', 'RB', 'AT05', 34, 3),
                ('Alexander Albon', 'Williams', 'FW46', 27, 23),
                ('Logan Sargeant', 'Williams', 'FW46', 23, 2)";

                    cmd.ExecuteNonQuery();
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        // Fetch drivers
        // Albin why code so messy?
        private void LoadDriverPhotos()
        {
            driverPhotos.Add("Max Verstappen", "https://www.formula1.com/content/dam/fom-website/drivers/M/MAXVER01_Max_Verstappen/maxver01.png.transform/1col/image.png");
            driverPhotos.Add("Lewis Hamilton", "https://www.formula1.com/content/dam/fom-website/drivers/L/LEWIHAM01_Lewis_Hamilton/lewiham01.png.transform/1col/image.png");
        }

        private async void DisplayDriverPhoto(string driverName)
        {
            if (!driverPhotos.ContainsKey(driverName))
            {
                MessageBox.Show("Utilgjengelig.");
                return;
            }

            string photoUrl = driverPhotos[driverName];

            try
            {
                var response = await httpClient.GetAsync(photoUrl);
                byte[] imageData = await response.Content.ReadAsByteArrayAsync();
                using (var ms = new MemoryStream(imageData))
                {
                    pictureBox1.Image = new Bitmap(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ved nedlastning: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox3.Text, out int alder))
            {
                MessageBox.Show("Alder må være et gyldig int.");
                return;
            }

            if (!int.TryParse(textBox4.Text, out int startnummer))
            {
                MessageBox.Show("Startnummer må være et gyldig int.");
                return;
            }

            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO [MyTable] (Navn, Team, Bil, Alder, Startnummer) VALUES (@Navn, @Team, @Bil, @Alder, @Startnummer)";
                cmd.Parameters.AddWithValue("@Navn", textBox1.Text);
                cmd.Parameters.AddWithValue("@Team", textBox2.Text);
                cmd.Parameters.AddWithValue("@Bil", textBox5.Text);
                cmd.Parameters.AddWithValue("@Alder", alder);
                cmd.Parameters.AddWithValue("@Startnummer", startnummer);

                cmd.ExecuteNonQuery();
                connection.Close();

                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
                display_data();

                MessageBox.Show("Data lagt inn.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public void display_data()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;

                string searchValue = textBox6.Text;
                if (!string.IsNullOrWhiteSpace(searchValue))
                {
                    cmd.CommandText = "SELECT * FROM [MyTable] WHERE Navn LIKE @searchValue OR Team LIKE @searchValue OR Bil LIKE @searchValue";
                    cmd.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM [MyTable]";
                }

                SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
                DataTable dta = new DataTable();
                dataadp.Fill(dta);

                dataGridView1.DataSource = dta;

                // Auto-resize columns to fit content
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                // Set AutoSizeMode for each column to ensure full content visibility
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }



        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            display_data();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            display_data();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Skriv inn et navn å slette.");
                return;
            }

            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "DELETE FROM [MyTable] WHERE Navn = @Navn";
                cmd.Parameters.AddWithValue("@Navn", textBox1.Text);

                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();

                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
                display_data();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data slettet.");
                }
                else
                {
                    MessageBox.Show("Ingen data funnet med det navnet.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox3.Text, out int alder))
            {
                MessageBox.Show("Alder må være et gyldig integer.");
                return;
            }

            if (!int.TryParse(textBox4.Text, out int startnummer))
            {
                MessageBox.Show("Startnummer må være et gyldig integer.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Skriv et navn for å oppdatere.");
                return;
            }

            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "UPDATE [MyTable] SET Team = @Team, Bil = @Bil, Alder = @Alder, Startnummer = @Startnummer WHERE Navn = @Navn";
                cmd.Parameters.AddWithValue("@Navn", textBox1.Text);
                cmd.Parameters.AddWithValue("@Team", textBox2.Text);
                cmd.Parameters.AddWithValue("@Bil", textBox5.Text);
                cmd.Parameters.AddWithValue("@Alder", alder);
                cmd.Parameters.AddWithValue("@Startnummer", startnummer);

                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();

                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
                display_data();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data oppdatert.");
                }
                else
                {
                    MessageBox.Show("Ingen data funnet med navnet..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

    }
}
