using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CaPY_SAD
{
    public partial class Edit_pet : Form
    {
        public Form previousform { get; set; }

        MySqlConnection conn;
        public Edit_pet()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");

            InitializeComponent();
        }


        public void ownercmbData()
        {
            String query = "SELECT concat(firstname,' ',middlename,' ',lastname) as owner FROM person,customers WHERE customers.person_id = person.id";
            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.CommandText = query;
            conn.Open();
            MySqlDataReader drd = comm.ExecuteReader();

            
            while (drd.Read())
            {
                ownerCmb.Items.Add(drd["owner"].ToString());
            }
            conn.Close();
        }

        /*
        public void loadPetTransactions()
        {

            String query_transactions = "SELECT ";

            conn.Open();
            MySqlCommand comm_transactions = new MySqlCommand(query_transactions, conn);
            MySqlDataAdapter adp_transactions = new MySqlDataAdapter(comm_transactions);

            conn.Close();
            DataTable dt_transactions = new DataTable();
            adp_transactions.Fill(dt_transactions);

            dtgvTrans.DataSource = query_transactions;
            dtgvTrans.Columns["Customer"].HeaderText = "Customer";
            dtgvTrans.Columns["Staff"].HeaderText = "Staff";
            dtgvTrans.Columns["total"].HeaderText = "Total";
            dtgvTrans.Columns["transaction_date"].HeaderText = "Date";
        }
        */

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.ShowDialog();
        }


        public int pet_id = CaPY_SAD.Pet.selected_data.pet_id;

        private void Edit_pet_Load(object sender, EventArgs e)
        {
            ownercmbData();
            loadPetDetails();
            loadMedRec();
            loadAllergies();
            load_medicine_given();
        }

        public void loadAllergies()
        {
            String query_allergies = "SELECT pet_allergy,recorded_on from allergies WHERE pets_id = " + pet_id + "";

            conn.Open();
            MySqlCommand comm_allergies = new MySqlCommand(query_allergies, conn);
            MySqlDataAdapter adp_allergies = new MySqlDataAdapter(comm_allergies);
            conn.Close();
            DataTable dt_allergies = new DataTable();
            adp_allergies.Fill(dt_allergies);


            dtgvAllergies.DataSource = dt_allergies;
            dtgvAllergies.Columns["pet_allergy"].HeaderText = "Allergies";
            dtgvAllergies.Columns["recorded_on"].HeaderText = "Date Recorded";
        }

        public void loadMedRec()
        {
            String query_medrec = "SELECT * FROM medical_record WHERE archived = 'no' AND pets_id = "+pet_id+"";

            conn.Open();
            MySqlCommand comm_medrec = new MySqlCommand(query_medrec, conn);
            MySqlDataAdapter adp_nedrec = new MySqlDataAdapter(comm_medrec);

            conn.Close();
            DataTable dt_med_rec = new DataTable();
            adp_nedrec.Fill(dt_med_rec);

            dtgvMedical.DataSource = dt_med_rec;
            dtgvMedical.Columns["id"].Visible = false;
            dtgvMedical.Columns["pets_id"].Visible = false;
            dtgvMedical.Columns["archived"].Visible = false;
            dtgvMedical.Columns["weight"].HeaderText = "Weight (kg)";
            dtgvMedical.Columns["allergies"].HeaderText = "Allergies";
            dtgvMedical.Columns["medicines_taken"].HeaderText = "Medicines Taken";
            dtgvMedical.Columns["remarks"].HeaderText = "Remarks";
            dtgvMedical.Columns["date_recorded"].HeaderText = "Record Date";

        }

        public void loadPetDetails()
        {
            String query = "SELECT pets.id, name, color, species, breed, pets.gender as gen, pets.birthdate as bday, microchip_number, sterilized, concat(firstname,' ',middlename,' ',lastname) as owner FROM pets,person,customers where customers.person_id = person.id AND customers.id = pets.customer_id AND pets.id = '" + pet_id + "' ";

            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.CommandText = query;
            conn.Open();
            MySqlDataReader drd = comm.ExecuteReader();

            while (drd.Read())
            {
                ownerCmb.Text = (drd["owner"].ToString());
                nameTxt.Text = (drd["name"].ToString());
                colorTxt.Text = (drd["color"].ToString());
                speciesTxt.Text = (drd["species"].ToString());

                if ((drd["gen"].ToString()) == "male")
                {
                    maleRadio.Checked = true;

                }
                else if ((drd["gen"].ToString()) == "female")
                {
                    femaleRadio.Checked = true;
                }


                if ((drd["sterilized"].ToString()) == "yes")
                {
                    sterilizedbox.Checked = true;

                }
                else
                {
                    femaleRadio.Checked = false;
                }


                bdayTxt.Text = (drd["bday"].ToString());
                breedTxt.Text = (drd["breed"].ToString());
                micronumTxt.Text = (drd["microchip_number"].ToString());


            }
            conn.Close();

        }



        private void editBtn_Click(object sender, EventArgs e)
        {
            ownerCmb.Enabled = true;
            nameTxt.Enabled = true;
            micronumTxt.Enabled = true;
            breedTxt.Enabled = true;
            speciesTxt.Enabled = true;
            bdayTxt.Enabled = true;
            maleRadio.Enabled = true;
            femaleRadio.Enabled = true;
            colorTxt.Enabled = true;
            sterilizedbox.Enabled = true;
            saveBtn.Enabled = true;
            cancelBtn.Enabled = true;

            editBtn.Enabled = false;
        }

        private void maleRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void femaleRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text == "" || speciesTxt.Text == "" || maleRadio.Checked == false && femaleRadio.Checked == false || breedTxt.Text == "" || bdayTxt.Text == "" || colorTxt.Text == "" || ownerCmb.Text == "")
            {
                MessageBox.Show("Please fill up all fields!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                String gen = "";
                String sterilized = "no";
                String chipno = "";

                if (maleRadio.Checked == true)
                {
                    gen = "male";
                }
                else if (femaleRadio.Checked == true)
                {
                    gen = "female";
                }

                if (sterilizedbox.Checked == true)
                {
                    sterilized = "yes";
                }
                else
                {
                    sterilized = "no";
                }

                if (micronumTxt.Text == "")
                {
                    chipno = "N/A";

                }
                else
                {
                    chipno = micronumTxt.Text;

                }

                string query = "UPDATE pets SET customer_id = (select customers.id from customers, person where customers.person_id = person.id AND concat(firstname,' ',middlename,' ',lastname) Like '%" + ownerCmb.Text + "%'), name = '" + nameTxt.Text + "' , color = '" + colorTxt.Text + "' , species = '" + speciesTxt.Text + "', breed = '" + breedTxt.Text + "', gender = '" + gen + "', birthdate = '" + bdayTxt.Text + "' , microchip_number = '" + chipno + "' , sterilized = '" + sterilized + "', date_modified = current_timestamp()  where id =  '" + pet_id + "'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Success", "Edit success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ownerCmb.Enabled = false;
                nameTxt.Enabled = false;
                micronumTxt.Enabled = false;
                breedTxt.Enabled = false;
                speciesTxt.Enabled = false;
                bdayTxt.Enabled = false;
                maleRadio.Enabled = false;
                femaleRadio.Enabled = false;
                colorTxt.Enabled = false;
                sterilizedbox.Enabled = false;
                saveBtn.Enabled = false;
                cancelBtn.Enabled = false;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            ownerCmb.Enabled = false;
            nameTxt.Enabled = false;
            micronumTxt.Enabled = false;
            breedTxt.Enabled = false;
            speciesTxt.Enabled = false;
            bdayTxt.Enabled = false;
            maleRadio.Enabled = false;
            femaleRadio.Enabled = false;
            colorTxt.Enabled = false;
            sterilizedbox.Enabled = false;
            saveBtn.Enabled = false;
            cancelBtn.Enabled = false;
        }

        // indicates if add or edit
        String type;
        private void editMedRecBtn_Click(object sender, EventArgs e)
        {
            type = "Edit";
            medRecPanel.Visible = true;
            medRecPanel.Enabled = true;
            medRecPanel.Size = new Size(995, 345);
            medRecPanel.Location = new Point(43, 25);
            addLabel.Text = "EDIT MEDICAL RECORD";

            String query_edit_med = "SELECT weight,allergies,medicines_taken,remarks FROM medical_record";

            MySqlCommand comm_edit_med = new MySqlCommand(query_edit_med, conn);
            comm_edit_med.CommandText = query_edit_med;
            conn.Open();
            MySqlDataReader drd = comm_edit_med.ExecuteReader();


            while (drd.Read())
            {
                weighTxt.Text = drd["weight"].ToString();
                allergyTxt.Text = drd["allergies"].ToString();
                medsTxt.Text = drd["medicines_taken"].ToString();
                remarksTxt.Text = drd["remarks"].ToString();

            }
            conn.Close();
        }

        private void cancelRecordBtn_Click(object sender, EventArgs e)
        {
            clear();
            medRecPanel.Visible = false;
            medRecPanel.Enabled = false;
        }
        public static int med_id;

        private void med_Rec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (med_Rec.SelectedIndex == 0)
            {
                addMedRecBtn.Visible = true;
                editMedRecBtn.Visible = true;
                archiveMedRecBtn.Visible = true;
            }
            else
            {
                addMedRecBtn.Visible = false;
                editMedRecBtn.Visible = false;
                archiveMedRecBtn.Visible = false;
            }
        }

        private void addMedRecBtn_Click(object sender, EventArgs e)
        {
            type = "Add";
            medRecPanel.Visible = true;
            medRecPanel.Enabled = true;
            medRecPanel.Size = new Size(839, 343);
            medRecPanel.Location = new Point(23, 31);

        }

        public void clear()
        {
            allergyTxt.Text = "";
            medsTxt.Text = "";
            remarksTxt.Text = "";
            weighTxt.Value = 1;

        }

        private void saveMedRecBtn_Click(object sender, EventArgs e)
        {
        
            if (type == "Add")
            {
                if (weighTxt.Text == "" || allergyTxt.Text == "" || medsTxt.Text == "" || remarksTxt.Text == "")
                {
                    MessageBox.Show("Please fill up all fields!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string query_medrec = "INSERT INTO medical_record(pets_id,weight,allergies,medicines_taken,remarks,date_recorded,archived)" +
                      "VALUES(" + pet_id + ",'" + weighTxt.Text + "','" + allergyTxt.Text + "','" + medsTxt.Text + "','" + remarksTxt.Text + "',current_timestamp(), 'no')";
                    conn.Open();
                    MySqlCommand comm_medrec = new MySqlCommand(query_medrec, conn);
                    comm_medrec.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Record added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    loadMedRec();
                }

            }

            else if (type == "Edit")
            {
                if (weighTxt.Text == "" || allergyTxt.Text == "" || medsTxt.Text == "" || remarksTxt.Text == "")
                {
                    MessageBox.Show("Please fill up all fields!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string query_medrec_u = " UPDATE medical_record SET weight = '" + weighTxt.Text + "', allergies = '" + allergyTxt.Text + "', medicines_taken = '" + medsTxt.Text + "', remarks = '" + remarksTxt.Text + "' where id = " + med_id + "";

                    conn.Open();
                    MySqlCommand comm_medrec_u = new MySqlCommand(query_medrec_u, conn);
                    comm_medrec_u.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Record edited!", "Edit success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    loadMedRec();
                }


            }
       
            medRecPanel.Visible = false;
            medRecPanel.Enabled = false;

        }

        private void archiveMedRecBtn_Click(object sender, EventArgs e)
        {
            DialogResult archive;

            archive = MessageBox.Show("Do really you want to add this record to archive?", "Archive Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (archive == DialogResult.Yes)
            {

                string query_acrhive = "Update medical_record SET archived = 'yes' where id = '" + med_id + "'";

                conn.Open();
                MySqlCommand comm_archive = new MySqlCommand(query_acrhive, conn);
                comm_archive.ExecuteNonQuery();
                conn.Close();
                loadMedRec();

            }

        }

        private void dtgvMedical_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            editMedRecBtn.Enabled = true;
            archiveMedRecBtn.Enabled = true;
            addMedRecBtn.Enabled = true;

            if (e.RowIndex > -1)
            {
                med_id = int.Parse(dtgvMedical.Rows[e.RowIndex].Cells["id"].Value.ToString());
            }
        }

        private void Edit_pet_Click(object sender, EventArgs e)
        {
            editMedRecBtn.Enabled = false;
            archiveMedRecBtn.Enabled = false;
            addMedRecBtn.Enabled = false;
        }

        public void load_medicine_given()
        {
            String medicine_load = "SELECT * FROM medicines_given WHERE pets_id = " + pet_id + "";

            conn.Open();
            MySqlCommand comm_loadmeds = new MySqlCommand(medicine_load, conn);
            MySqlDataAdapter adp_loadmeds = new MySqlDataAdapter(comm_loadmeds);
            conn.Close();
            DataTable dt_meds = new DataTable();
            adp_loadmeds.Fill(dt_meds);

            dtgvMed.DataSource = dt_meds;
            dtgvMed.Columns["id"].Visible = false;
            dtgvMed.Columns["pets_id"].Visible = false;
            dtgvMed.Columns["hosp_id"].Visible = false;
            dtgvMed.Columns["medicine_name"].HeaderText = "Medicine Name";
            dtgvMed.Columns["endorsed"].HeaderText = "Medicine Source";
            dtgvMed.Columns["given_on"].HeaderText = "Date Given";

        }
    }
}
