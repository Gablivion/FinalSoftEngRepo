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
    public partial class Hosp : Form
    {
        public Form previousform { get; set; }
        MySqlConnection conn;

        public Hosp()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root; Allow Zero Datetime=True ");
            InitializeComponent();
        }

    
        public class selected_data
        {
            public static int cage_id;
            public static int hosp_id;
            public static Boolean checkout;
            public static int custid;
            public static string custname;
            public static decimal prodtotal;
            public static decimal servtotal;
            public static decimal roomtotal;

            public static decimal total;

        }
        private void Hosp_Load(object sender, EventArgs e)
        {
            detailPanel.Size = new Size(1168, 365);
            detailPanel.Location = new Point(21, 604);
            detailPanel.Visible = true;
            dischargeBtn.Enabled = false;
            loadCageData();
            loadpets();
            addHospBtn.Visible = false;
            service();
            
        }

        public void loadCageData()
        {

            String query_cage = "SELECT * FROM cage";

            conn.Open();
            MySqlCommand comm_cage = new MySqlCommand(query_cage, conn);
            MySqlDataAdapter adp_cage = new MySqlDataAdapter(comm_cage);
            conn.Close();
            DataTable dt_cage = new DataTable();
            adp_cage.Fill(dt_cage);

            dtgvCage.DataSource = dt_cage;
            dtgvCage.Columns["id"].Visible = false;
            dtgvCage.Columns["name"].HeaderText = "Cage Name";
            dtgvCage.Columns["description"].HeaderText = "Cage Descrption";
            dtgvCage.Columns["status"].HeaderText = "Status";
            dtgvCage.Columns["price"].HeaderText = "Price";

        }
        public void loadHospData()
        {

            String query_hosp = "SELECT id,pets_id,(SELECT name FROM pets WHERE id = pets_id ) as pet,(SELECT name FROM cage WHERE id = cage_id ) as cage,DATE_FORMAT(date_in, '%Y-%m-%d %H:%i %p') as date_in,DATE_FORMAT(date_in, '%Y-%m-%d %H:%i:%s') as d_in, IF(date_out='','Pending',DATE_FORMAT(date_out, '%Y/%m/%d %H:%i %p'))  as date_out,subtotal,status FROM hospitalization WHERE archived = 'no' AND pets_id = " + pets_id + " ";

            conn.Open();
            MySqlCommand comm_hosp = new MySqlCommand(query_hosp, conn);
            MySqlDataAdapter adp_hosp = new MySqlDataAdapter(comm_hosp);
            conn.Close();
            DataTable dt_hosp = new DataTable();
            adp_hosp.Fill(dt_hosp);

            dtgvHospitalization.DataSource = dt_hosp;
            dtgvHospitalization.Columns["id"].Visible = false;
            dtgvHospitalization.Columns["pets_id"].Visible = false;
            dtgvHospitalization.Columns["cage"].HeaderText = "Cage";
            dtgvHospitalization.Columns["pet"].Visible = false;
            dtgvHospitalization.Columns["d_in"].Visible = false;
            dtgvHospitalization.Columns["date_in"].HeaderText = "Admission Date";
            dtgvHospitalization.Columns["date_out"].HeaderText = "Discharge Date";
            dtgvHospitalization.Columns["subtotal"].Visible = false;
            dtgvHospitalization.Columns["status"].HeaderText = "Status";


            for (int i = 0; i <= dtgvHospitalization.Rows.Count - 1; i++)
            {
                if (dtgvHospitalization.Rows[i].Cells["status"].Value.ToString() == "discharged")
                {
                    addHospBtn.Visible = true;
                }
                else
                {
                    addHospBtn.Visible = false;
                }
            }
        }

        private void addcageBtn_Click(object sender, EventArgs e)
        {
            cagePanel.Visible = false;
            addCagePanel.Visible = true;
            addCagePanel.Size = new Size(1131, 229);
            addCagePanel.Location = new Point(33, 388);
        }

        private void addHospBtn_Click(object sender, EventArgs e)
        {
            cagePanel.Visible = true;
            cagePanel.Size = new Size(1135, 229);
            cagePanel.Location = new Point(33, 388);

        }


        private void addVitalsBtn_Click(object sender, EventArgs e)
        {
            Add_vitals addVitals = new Add_vitals();
            addVitals.Show();
            addVitals.previousform = this;
            this.Hide();
        }

        /*
        private void addTempInvBtn_Click(object sender, EventArgs e)
        {
            Add_tempInventory addInv = new Add_tempInventory();
            addInv.previousform = this;
            addInv.Show();
            this.Hide();
        }
        */

        private void checkoutBtn_Click(object sender, EventArgs e)
        {
            checkoutPanel.Size = new Size(1134, 336);
            checkoutPanel.Location = new Point(21, 604);
            checkoutPanel.Visible = true;
            addfee();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            previousform.Show();
        }

        private void addvitalBtn_Click(object sender, EventArgs e)
        {
            Add_vitals vitals = new Add_vitals();
            vitals.previousform = this;
            this.Hide();
            vitals.Show();
        }

        private void editVitalsBtn_Click(object sender, EventArgs e)
        {

        }


        // Makes Form Movable
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Hosp_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Hosp_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Hosp_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

      
        private void dtgvCage_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex > -1)
            {
                if (dtgvCage.Rows[e.RowIndex].Cells["status"].Value.ToString() == "unavailable")
                {
                    MessageBox.Show("Cage not available!", "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {


                    int selected_id = int.Parse(dtgvCage.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    selected_data.cage_id = selected_id;
                    cagePanel.Visible = false;

                    String query_cage = "SELECT * FROM cage where id = " + selected_id + "";

                    MySqlCommand comm_cage = new MySqlCommand(query_cage, conn);
                    comm_cage.CommandText = query_cage;
                    conn.Open();
                    MySqlDataReader drd_cage = comm_cage.ExecuteReader();


                    while (drd_cage.Read())
                    {

                        cageTxt.Text = drd_cage["name"].ToString();
                    }
                    conn.Close();

                    addHospPanel.Visible = true;
                    addHospPanel.Size = new Size(1143, 233);
                    addHospPanel.Location = new Point(21, 388);

                }
            }

        }

        public void loadVitals()
        {

            String query_vitals = "SELECT * from daily_vitals WHERE hospitalization_id = " + selected_data.hosp_id + "";

            conn.Open();
            MySqlCommand comm_vitals = new MySqlCommand(query_vitals, conn);
            MySqlDataAdapter adp_vitals = new MySqlDataAdapter(comm_vitals);
            conn.Close();
            DataTable dt_vitals = new DataTable();
            adp_vitals.Fill(dt_vitals);

            dtgvVitals.DataSource = dt_vitals;
            dtgvVitals.Columns["id"].Visible = false;
            dtgvVitals.Columns["hospitalization_id"].Visible = false;
            dtgvVitals.Columns["date"].HeaderText = "Date Recorded";
            dtgvVitals.Columns["weight"].HeaderText = "Weight";
            dtgvVitals.Columns["temperature"].HeaderText = "Temperature";
            dtgvVitals.Columns["heart_rate"].HeaderText = "Heart Rate";
            dtgvVitals.Columns["respiratory_rate"].HeaderText = "Respiratory";
            dtgvVitals.Columns["appetite_status"].HeaderText = "Appetite";
            dtgvVitals.Columns["attitude_status"].HeaderText = "Attitude";
            dtgvVitals.Columns["bowel_status"].HeaderText = "Bowel";
            dtgvVitals.Columns["coughing_status"].HeaderText = "Coughing";
            dtgvVitals.Columns["drinking_status"].HeaderText = "Drinking";
            dtgvVitals.Columns["urination_status"].HeaderText = "Urination";
            dtgvVitals.Columns["vomiting_status"].HeaderText = "Vomiting";

        }

        private void backCagebtn_Click(object sender, EventArgs e)
        {
            cagePanel.Visible = false;
        }
        public static string admission_date;
        public static decimal cage_price;
        private void dtgvHospitalization_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            detailPanel.Visible = false;
            // addHospBtn.Enabled = false;


            if (e.RowIndex > -1)
            {
                btnAddAllergies.Visible = true;
                int selected_id = int.Parse(dtgvHospitalization.Rows[e.RowIndex].Cells["id"].Value.ToString());
                
                admission_date = dtgvHospitalization.Rows[e.RowIndex].Cells["d_in"].Value.ToString();
                selected_data.hosp_id = selected_id;

                String get_priceofcage = "select price from cage,hospitalization WHERE hospitalization.cage_id = cage.id AND hospitalization.id = "+ selected_id + "";


                MySqlCommand comm_priceofcage = new MySqlCommand(get_priceofcage, conn);
                comm_priceofcage.CommandText = get_priceofcage;


                conn.Open();
                MySqlDataReader drd_priceofcage = comm_priceofcage.ExecuteReader();

                while (drd_priceofcage.Read())
                {
                    cage_price = decimal.Parse(drd_priceofcage["price"].ToString());
                }
                conn.Close();


                loadVitals();
                HospProds();
                EndorsedProds();
                load_medicine_given();
                load_acc_services();
                prodtotal();
                servTotal();
                if (dtgvHospitalization.Rows[e.RowIndex].Cells["status"].Value.ToString() == "discharged")
                {
                    dischargeBtn.Enabled = false;
                    addProdBtn.Enabled = false;
                    addEndorsedBtn.Enabled = false;
                    servAdd.Enabled = false;
                    addvitalBtn.Enabled = false;

                }
                else
                {
                    dischargeBtn.Enabled = true;
                    addProdBtn.Enabled = true;
                    addEndorsedBtn.Enabled = true;
                    servAdd.Enabled = true;
                    addvitalBtn.Enabled = true;
                }

            }

        }

        private void Hosp_Click(object sender, EventArgs e)
        {

            addHospBtn.Enabled = true;

        }

        private void Hosp_VisibleChanged(object sender, EventArgs e)
        {

            loadCageData();
            loadHospData();

        }

        private void cageCancelBtn_Click(object sender, EventArgs e)
        {
            addCagePanel.Visible = false;
            cagePanel.Visible = true;
        }

        private void cageSaveBtn_Click(object sender, EventArgs e)
        {

            string query = "SELECT * from cage WHERE name = '" + cageNameTxt.Text + "'";
            conn.Open();
            MySqlCommand comm_select = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm_select);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Cage name already taken!", "Name taken", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (cageNameTxt.Text == "" || cagedescTxt.Text == "" || priceTxt.Text == "")
                {
                    MessageBox.Show("Please fill up all fields!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    string query_cage = "INSERT INTO cage(name,description,price,status) VALUES ('" + cageNameTxt.Text + "','" + cagedescTxt.Text + "','" + priceTxt.Text + "','available')";

                    conn.Open();
                    MySqlCommand comm_cage = new MySqlCommand(query_cage, conn);
                    comm_cage.ExecuteNonQuery();
                    conn.Close();
                    addCagePanel.Visible = false;
                    cagePanel.Visible = true;
                    loadCageData();
                }

            }
        }

        public void EndorsedProds()
        {
            String query_endorsed = "SELECT * from endorsed_prods WHERE hospitalization_id = " + selected_data.hosp_id + "";

            conn.Open();
            MySqlCommand comm_endorsed = new MySqlCommand(query_endorsed, conn);
            MySqlDataAdapter adp_endorsed = new MySqlDataAdapter(comm_endorsed);
            conn.Close();
            DataTable dt_endorsed = new DataTable();
            adp_endorsed.Fill(dt_endorsed);


            dtgvEndorsed.DataSource = dt_endorsed;
            dtgvEndorsed.Columns["id"].Visible = false;
            dtgvEndorsed.Columns["hospitalization_id"].Visible = false;
            dtgvEndorsed.Columns["name"].HeaderText = "Product";
            dtgvEndorsed.Columns["quantity"].HeaderText = "Quantity";
            dtgvEndorsed.Columns["expiration_date"].HeaderText = "Subtotal";

        }
        public static int inv_id;
        private void dtgvAddProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addCancelBtn_Click(object sender, EventArgs e)
        {
            addprodname.Text = "";
            addprodprice.Text = "";
            addprodquan.Maximum = 1000;
            addprodsPanel.Visible = false;

        }

        private void addprodsBtn_Click(object sender, EventArgs e)
        {



        }

        private void addprodquan_ValueChanged(object sender, EventArgs e)
        {
            string price = addprodprice.Text;
            decimal parsed_price = decimal.Parse(price);

            string quantity = addprodquan.Value.ToString();
            int parsed_quantity = int.Parse(quantity);


            decimal subtotal = parsed_price * parsed_quantity;
            subtotalTxt.Text = subtotal.ToString();

        }

        private void endorsedSaveBtn_Click(object sender, EventArgs e)
        {

            if (addEndorsedname.Text == "" || endorsedQuanNum.Text == "")
            {
                MessageBox.Show("Please fill up all fields!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                int med;

                if (MedCbox.Checked == true)
                {
                    med = 1;

                    string medicine_insert = "INSERT INTO medicines_given (hosp_id,pets_id,medicine_name,endorsed,given_on) VALUES(" + selected_data.hosp_id + "," + pets_id + ", '" + addEndorsedname.Text + "', 'Endorsed', current_timestamp())";
                    conn.Open();
                    MySqlCommand comm_medinsert = new MySqlCommand(medicine_insert, conn);
                    comm_medinsert.ExecuteNonQuery();
                    conn.Close();
                    load_medicine_given();
                }
                else
                {
                    med = 0;


                }

                string query_hospprods = "INSERT INTO endorsed_prods (hospitalization_id,name,quantity,expiration_date,medicine) VALUES(" + selected_data.hosp_id + ", '" + addEndorsedname.Text + "',  '" + endorsedQuanNum.Text + "',  '" + expirationDtp.Text + "'," + med + ")";
                conn.Open();
                MySqlCommand comm_hospprods = new MySqlCommand(query_hospprods, conn);
                comm_hospprods.ExecuteNonQuery();
                conn.Close();
                EndorsedProds();
                addEndorsedPanel.Visible = false;
                addEndorsedPanel.Enabled = false;
            }
        }





      

        private void btnAddAllergies_Click(object sender, EventArgs e)
        {
            allergyPanel.Size = new Size(408, 222);
            allergyPanel.Location = new Point(747, 134);
            allergyPanel.Visible = true;

        }

        private void btnCancelAllergy_Click(object sender, EventArgs e)
        {
            allergyPanel.Visible = false;
        }

        private void btnSaveAllergy_Click(object sender, EventArgs e)
        {

            if (allergyTxt.Text == "")
            {
                MessageBox.Show("Please fill up all fields!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                string query_hospprods = "INSERT INTO allergies (pets_id,pet_allergy,recorded_on) VALUES(" + pets_id + ",'" + allergyTxt.Text + "',current_timestamp())";
                conn.Open();
                MySqlCommand comm_hospprods = new MySqlCommand(query_hospprods, conn);
                comm_hospprods.ExecuteNonQuery();
                conn.Close();
                EndorsedProds();
                addEndorsedPanel.Visible = false;
                addEndorsedPanel.Enabled = false;
                MessageBox.Show("Added Allegy");
                allergyTxt.Text = "";
                allergyPanel.Visible = false;
                loadAllergies();
            }
        }
        public static string owner;
        public void petdata()
        {
            String query_petdetails = "SELECT customer_id,name,color,breed,species,gender,DATEDIFF(now(), birthdate) as age from pets WHERE id = " + pets_id + "";


            MySqlCommand comm_petdetails = new MySqlCommand(query_petdetails, conn);
            comm_petdetails.CommandText = query_petdetails;

            conn.Open();
            MySqlDataReader drd_petdetails = comm_petdetails.ExecuteReader();

            while (drd_petdetails.Read())
            {
                owner = drd_petdetails["customer_id"].ToString();
                
                petTxt.Text = drd_petdetails["name"].ToString();
                colorTxt.Text = drd_petdetails["color"].ToString();
                breedTxt.Text = drd_petdetails["breed"].ToString();
                speciesTxt.Text = drd_petdetails["species"].ToString();
                genderTxt.Text = drd_petdetails["gender"].ToString();
                ageTxt.Text = drd_petdetails["age"].ToString() + " days old";

            }
            conn.Close();

        }
        public void loadAllergies()
        {
            String query_allergies = "SELECT pet_allergy from allergies WHERE pets_id = " + pets_id + "";

            conn.Open();
            MySqlCommand comm_allergies = new MySqlCommand(query_allergies, conn);
            MySqlDataAdapter adp_allergies = new MySqlDataAdapter(comm_allergies);
            conn.Close();
            DataTable dt_allergies = new DataTable();
            adp_allergies.Fill(dt_allergies);


            dtgvAllergies.DataSource = dt_allergies;
            dtgvAllergies.Columns["pet_allergy"].HeaderText = "Allergies";

        }

        private void petTxt_MouseClick(object sender, MouseEventArgs e)
        {
            petPanel.Visible = true;
            petPanel.Size = new Size(696, 208);
            petPanel.Location = new Point(20, 8);
            detailPanel.Visible = true;
        }

        private void petBackBtn_Click(object sender, EventArgs e)
        {
            petPanel.Visible = false;
        }

        public void loadpets()
        {
            String query = "SELECT pets.id, pets.customer_id as cust, name,  concat(person.firstname,' ',person.middlename,' ',person.lastname) as owner, color, species, breed, pets.gender as gen, pets.birthdate as bday, microchip_number, sterilized, pets.date_added as p_added, pets.date_modified as p_modified FROM pets,person,customers where customers.person_id = person.id AND customers.id = pets.customer_id AND pets.archived = 'no'";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dtgvPet.DataSource = dt;
            dtgvPet.Columns["id"].Visible = false;
            dtgvPet.Columns["cust"].Visible = false;
            dtgvPet.Columns["cust"].Visible = false;
            dtgvPet.Columns["color"].Visible = false;
            dtgvPet.Columns["species"].HeaderText = "Species";
            dtgvPet.Columns["breed"].HeaderText = "Breed";
            dtgvPet.Columns["gen"].HeaderText = "Gender";
            dtgvPet.Columns["bday"].Visible = false;
            dtgvPet.Columns["microchip_number"].Visible = false;
            dtgvPet.Columns["sterilized"].Visible = false;
            dtgvPet.Columns["owner"].HeaderText = "Owner";
            dtgvPet.Columns["p_added"].Visible = false;
            dtgvPet.Columns["p_modified"].Visible = false;

        }

        public static int pets_id;
        private void dtgvPet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            checkoutPanel.Visible = false;
            detailPanel.Visible = true;
            petPanel.Visible = false;
            addHospBtn.Visible = true;
            btnAddAllergies.Visible = false;
            if (e.RowIndex > -1)
            {
                dischargeBtn.Enabled = false;
               
                petTxt.Text = dtgvPet.Rows[e.RowIndex].Cells["name"].Value.ToString();
                selected_data.custid = int.Parse(dtgvPet.Rows[e.RowIndex].Cells["cust"].Value.ToString());
                selected_data.custname = dtgvPet.Rows[e.RowIndex].Cells["owner"].Value.ToString();
                addHospPetTxt.Text = petTxt.Text;
                pets_id = int.Parse(dtgvPet.Rows[e.RowIndex].Cells["id"].Value.ToString());
                loadHospData();
                petdata();
                loadAllergies();
            }

        }

        private void hospcancelBtn_Click(object sender, EventArgs e)
        {
            addHospPanel.Visible = false;

        }

        private void hospaddBtn_Click(object sender, EventArgs e)
        {
            addHospPanel.Visible = false;


            string query_insert_hosp = "INSERT INTO hospitalization(pets_id,cage_id,date_in,subtotal,status,archived) VALUES ((SELECT id from pets WHERE name = '" + petTxt.Text + "' AND customer_id = " + owner + "),(SELECT id from cage WHERE name = '" + cageTxt.Text + "'), current_timestamp(),0,'active','no')";
            conn.Open();
            MySqlCommand comm_insert_hosp = new MySqlCommand(query_insert_hosp, conn);
            comm_insert_hosp.ExecuteNonQuery();
            conn.Close();

            string query_update_cage = "UPDATE cage SET status = 'unavailable' WHERE cage.id = " + selected_data.cage_id + "";

            conn.Open();
            MySqlCommand comm_update_cage = new MySqlCommand(query_update_cage, conn);
            comm_update_cage.ExecuteNonQuery();
            conn.Close();
            loadHospData();

        }

        private void backserviceBtn_Click(object sender, EventArgs e)
        {
            servPanel.Visible = false;
        }

        private void servAdd_Click(object sender, EventArgs e)
        {
            servPanel.Visible = true;
            servPanel.Size = new Size(1093, 260);
            servPanel.Location = new Point(17, 12);
        }
        public void service()
        {
            String query_serv = "SELECT id, name, description, price FROM services";

            conn.Open();
            MySqlCommand comm_serve = new MySqlCommand(query_serv, conn);
            MySqlDataAdapter adp_serve = new MySqlDataAdapter(comm_serve);
            conn.Close();
            DataTable dt_serve = new DataTable();
            adp_serve.Fill(dt_serve);


            dtgvServices.DataSource = dt_serve;
            dtgvServices.Columns["id"].Visible = false;
            dtgvServices.Columns["name"].HeaderText = "Name";
            dtgvServices.Columns["description"].HeaderText = "Description";
            dtgvServices.Columns["price"].HeaderText = "Price";

        }

        public static int selected_serv;
        public static decimal selected_serv_price;
        // public static
        private void dtgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Boolean serv_available = true;
            if (e.RowIndex > -1)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to add this service?", "Add Service", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dtgvServices.Enabled = true;

                    selected_serv = int.Parse(dtgvServices.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    selected_serv_price = decimal.Parse(dtgvServices.Rows[e.RowIndex].Cells["price"].Value.ToString());
                    servTotal();
                    prodtotal();

                    String query_serviceprods = "SELECT id,products_id as pid,quantity from service_products WHERE services_id = " + selected_serv + "";

                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query_serviceprods, conn);
                    MySqlDataAdapter adp_serviceprods = new MySqlDataAdapter(comm);
                    conn.Close();
                    DataTable dt_serviceprods = new DataTable();
                    adp_serviceprods.Fill(dt_serviceprods);


                    dtgvServProd.DataSource = dt_serviceprods;
                    dtgvServProd.Columns["id"].Visible = true;
                    dtgvServProd.Columns["pid"].Visible = true;
                    dtgvServProd.Columns["quantity"].Visible = true;

                    if (dtgvServProd.Rows.Count > 0)
                    {

                        // Check Inventory
                        for (int i = 0; i <= dtgvServProd.Rows.Count - 1; i++)
                        {

                            string prod_id = dtgvServProd.Rows[i].Cells["pid"].Value.ToString();

                            string query_prods = "SELECT * from product_inventory WHERE products_id = '" + prod_id + "'";
                            conn.Open();
                            MySqlCommand comm_prods = new MySqlCommand(query_prods, conn);
                            MySqlDataAdapter adp_prods = new MySqlDataAdapter(comm_prods);
                            conn.Close();
                            DataTable dt_prods = new DataTable();
                            adp_prods.Fill(dt_prods);

                            if (dt_prods.Rows.Count > 0)
                            {
                                string pid = dt_prods.Rows[0]["products_id"].ToString();
                                int avail_prod_quan = int.Parse(dt_prods.Rows[0]["quantity"].ToString());
                                int quantity = int.Parse(dtgvServProd.Rows[i].Cells["quantity"].Value.ToString());

                                if (quantity > avail_prod_quan)
                                {
                                    serv_available = false;
                                }

                            }
                            else
                            {
                                serv_available = false;
                            }
                        }


                        if (serv_available == true)
                        {

                            for (int i = 0; i <= dtgvServProd.Rows.Count - 1; i++)
                            {

                                string prod_id = dtgvServProd.Rows[i].Cells["pid"].Value.ToString();

                                int quantity = int.Parse(dtgvServProd.Rows[i].Cells["quantity"].Value.ToString());
                                string query_prods = "SELECT product_inventory.id as id, products_id,name from product_inventory,products WHERE products_id = products.id AND products_id = '" + prod_id + "'";
                                conn.Open();
                                MySqlCommand comm_prods = new MySqlCommand(query_prods, conn);
                                MySqlDataAdapter adp_prods = new MySqlDataAdapter(comm_prods);
                                conn.Close();
                                DataTable dt_prods = new DataTable();
                                adp_prods.Fill(dt_prods);

                                string pid = dt_prods.Rows[0]["products_id"].ToString();
                                string prod_name = dt_prods.Rows[0]["name"].ToString();

                                string inv_id = dt_prods.Rows[0]["id"].ToString();

                                string query_add_quantity = "UPDATE product_inventory SET quantity = quantity - " + quantity + " WHERE id = " + int.Parse(inv_id) + " ";
                                conn.Open();
                                MySqlCommand comm_add_quantity = new MySqlCommand(query_add_quantity, conn);
                                comm_add_quantity.ExecuteNonQuery();
                                conn.Close();

                                string query_log = "INSERT INTO inventory_log (process_type,date,product,quantity,remarks,staff_id) VALUES('Stock Out (Service Usage)' , current_timestamp(),'" + prod_name + "','" + quantity + "', 'Stocked out to usage by " + Login.UserDisplayDetails.name + "', (SELECT staff.id FROM person,staff WHERE person.id = staff.person_id AND concat(firstname,' ', middlename,' ',lastname) = '" + Login.UserDisplayDetails.name + "'))";
                                conn.Open();
                                MySqlCommand comm_log = new MySqlCommand(query_log, conn);
                                comm_log.ExecuteNonQuery();
                                conn.Close();

                                string query_updateavail = "UPDATE product_inventory SET status = 'unavailable' WHERE quantity <= 0";
                                conn.Open();
                                MySqlCommand comm_updateavail = new MySqlCommand(query_updateavail, conn);
                                comm_updateavail.ExecuteNonQuery();
                                conn.Close();

                                load_service_acquired();
                                load_acc_services();
                                servTotal();

                            }
                        }
                        else
                        {
                            MessageBox.Show("Not Enough in Inventory");
                        }

                        //Reload and Hide Panel

                        servPanel.Visible = false;
                    }
                    else
                    {
                        // Do nothing
                        servPanel.Visible = false;
                    }


                }
                else
                {
                    MessageBox.Show("Please select a service!");
                }

            }
        }

        public void load_service_acquired()
        {
            string insert_service = "INSERT INTO service_transaction (pets_id,hospitalization_id,services_id,service_price) VALUES(" + pets_id + "," + selected_data.hosp_id + "," + selected_serv + ",'" + selected_serv_price + "')";
            conn.Open();
            MySqlCommand comm_servinsert = new MySqlCommand(insert_service, conn);
            comm_servinsert.ExecuteNonQuery();
            conn.Close();

        }

        public void load_acc_services()
        {
            String query_accserv = "SELECT service_transaction.id as id, services.name as name, service_price as price FROM service_transaction, services WHERE services_id = services.id AND hospitalization_id = " + selected_data.hosp_id + "";

            conn.Open();
            MySqlCommand comm_accserve = new MySqlCommand(query_accserv, conn);
            MySqlDataAdapter adp_accserve = new MySqlDataAdapter(comm_accserve);
            conn.Close();
            DataTable dt_accserve = new DataTable();
            adp_accserve.Fill(dt_accserve);


            dtgvAccServices.DataSource = dt_accserve;
            dtgvAccServices.Columns["id"].Visible = false;
            dtgvAccServices.Columns["name"].HeaderText = "Name";
            dtgvAccServices.Columns["price"].HeaderText = "Price";

        }

        public void servTotal()
        {
            decimal total = 0;

            for (int i = 0; i <= dtgvAccServices.Rows.Count - 1; i++)
            {

                string subs = dtgvAccServices.Rows[i].Cells["Price"].Value.ToString();

                decimal decimal_sub = decimal.Parse(subs);

                total += decimal_sub;

            }
            ServTotalTxt.Text = total.ToString();
         
        }
        public void prodtotal()
        {
            decimal total = 0;

            for (int i = 0; i <= dtgvAddProd.Rows.Count - 1; i++)
            {

                string subs = dtgvAddProd.Rows[i].Cells["Subtotal"].Value.ToString();

                decimal decimal_sub = decimal.Parse(subs);

                total = total + decimal_sub;


            }
            prodTotalTxt.Text = total.ToString();
          
        }


        private void ServTotalTxt_TextChanged(object sender, EventArgs e)
        {
            TOTAL();
        }

        private void prodTotalTxt_TextChanged(object sender, EventArgs e)
        {
            TOTAL();
        }

        public void TOTAL()
        {

            decimal total;

            total = decimal.Parse(prodTotalTxt.Text) + decimal.Parse(ServTotalTxt.Text);

            totalTxt.Text = total.ToString();

            

            string query_subtotal = "UPDATE hospitalization SET subtotal = " + total + " WHERE  id =  " + Hosp.selected_data.hosp_id + "";
            conn.Open();
            MySqlCommand comm_subtotal = new MySqlCommand(query_subtotal, conn);
            comm_subtotal.ExecuteNonQuery();
            conn.Close();

        }



        public static int selected_prod;
        private void dtgvAvailProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                addProdPaneldtgv.Visible = true;
                inv_id = int.Parse(dtgvAvailProd.Rows[e.RowIndex].Cells["id"].Value.ToString());
                selected_prod = int.Parse(dtgvAvailProd.Rows[e.RowIndex].Cells["prod_id"].Value.ToString());
                hosp_prod_quan.Maximum = int.Parse(dtgvAvailProd.Rows[e.RowIndex].Cells["quantity"].Value.ToString());
                load_prod_details();
                addProdPaneldtgv.Visible = false;
            }
            else
            {
                MessageBox.Show("Please select a service!");
            }

        }


        private void addProdBtn_Click(object sender, EventArgs e)
        {
            addProdPaneldtgv.Visible = true;
            addProdPaneldtgv.Enabled = true;
            addProdPaneldtgv.Size = new Size(540, 279);
            addProdPaneldtgv.Location = new Point(20, 4);

            Addproducts();
        }


        private void BtnExitProd_Click(object sender, EventArgs e)
        {
            addProdPaneldtgv.Visible = false;
        }

        public void Addproducts()
        {

            String query_inventory = "SELECT product_inventory.id as id, products.id as prod_id, products.name as product, quantity,  DATE_FORMAT(expiration_date, '%Y/%m/%d') as expiration_date FROM products, product_inventory WHERE (expiration_date = '0000/00/00' OR expiration_date > CURDATE()) AND product_inventory.products_id = products.id AND status = 'available'";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query_inventory, conn);
            MySqlDataAdapter adp_inventory = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt_inventory = new DataTable();
            adp_inventory.Fill(dt_inventory);


            dtgvAvailProd.DataSource = dt_inventory;
            dtgvAvailProd.Columns["id"].Visible = false;
            dtgvAvailProd.Columns["prod_id"].Visible = false;
            dtgvAvailProd.Columns["product"].HeaderText = "Product";
            dtgvAvailProd.Columns["quantity"].HeaderText = "Quantity";
            dtgvAvailProd.Columns["expiration_date"].HeaderText = "Expiration Date";


        }


        public void HospProds()
        {
            String query_inventory = "SELECT products.name as pname,hospitalization_id,hosp_prods.id,products_id,quantity,subtotal from products,hosp_prods WHERE products.id = products_id AND hospitalization_id = " + selected_data.hosp_id + "";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query_inventory, conn);
            MySqlDataAdapter adp_inventory = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt_inventory = new DataTable();
            adp_inventory.Fill(dt_inventory);


            dtgvAddProd.DataSource = dt_inventory;
            dtgvAddProd.Columns["hospitalization_id"].Visible = false;
            dtgvAddProd.Columns["id"].Visible = false;
            dtgvAddProd.Columns["products_id"].Visible = false;
            dtgvAddProd.Columns["pname"].HeaderText = "Product";
            dtgvAddProd.Columns["quantity"].HeaderText = "Quantity";
            dtgvAddProd.Columns["subtotal"].HeaderText = "Subtotal";

        }


        public static int medic_val;
        public void load_prod_details()
        {

            String query_get_prod_det = "SELECT name,price,medicine from products WHERE id = " + selected_prod + "";
            MySqlCommand comm_get_prod_det = new MySqlCommand(query_get_prod_det, conn);
            comm_get_prod_det.CommandText = query_get_prod_det;



            conn.Open();
            MySqlDataReader drd_get_prod_det = comm_get_prod_det.ExecuteReader();

            while (drd_get_prod_det.Read())
            {
                hosp_prod_name.Text = drd_get_prod_det["name"].ToString();
                hosp_prod_price.Text = drd_get_prod_det["price"].ToString();
                hosp_prod_subtotal.Text = hosp_prod_price.Text;
                medic_val = int.Parse(drd_get_prod_det["medicine"].ToString());

                if (medic_val == 1)
                {
                    medCbxHospProd.Checked = true;
                }
                else
                {
                    medCbxHospProd.Checked = false;
                }

            }


            conn.Close();

            hospprodPanel.Visible = true;
            hospprodPanel.Enabled = true;
            hospprodPanel.Size = new Size(540, 279);
            hospprodPanel.Location = new Point(20, 4);

            /* guide lang
            hosp_prods.Columns.Add("hosp_id", typeof(string));
            hosp_prods.Columns.Add("prod_id", typeof(string));
            hosp_prods.Columns.Add("product", typeof(string));
            hosp_prods.Columns.Add("Price", typeof(string));
            hosp_prods.Columns.Add("Quantity", typeof(string));
            hosp_prods.Columns.Add("Subtotal", typeof(string));
            */

        }


        private void CancelHospProds_Click(object sender, EventArgs e)
        {
            hospprodPanel.Visible = false;
        }

        private void SaveHospProds_Click(object sender, EventArgs e)
        {

            if (medic_val == 1)
            {
                string medicine_insert = "INSERT INTO medicines_given (pets_id,hosp_id,medicine_name,endorsed,given_on) VALUES(" + pets_id + "," + selected_data.hosp_id + ", '" + hosp_prod_name.Text + "', 'Inventory', current_timestamp())";
                conn.Open();
                MySqlCommand comm_medinsert = new MySqlCommand(medicine_insert, conn);
                comm_medinsert.ExecuteNonQuery();
                conn.Close();
                load_medicine_given();
            }
            string query_hospprods = "INSERT INTO hosp_prods (hospitalization_id,products_id,quantity,subtotal) VALUES(" + selected_data.hosp_id + ", '" + selected_prod + "',  " + hosp_prod_quan.Value + ", '" + hosp_prod_subtotal.Text + "')";
            conn.Open();
            MySqlCommand comm_hospprods = new MySqlCommand(query_hospprods, conn);
            comm_hospprods.ExecuteNonQuery();
            conn.Close();

            string query_add_quantity = "UPDATE product_inventory SET quantity = quantity - " + hosp_prod_quan.Value + " WHERE id = " + inv_id + " ";
            conn.Open();
            MySqlCommand comm_add_quantity = new MySqlCommand(query_add_quantity, conn);
            comm_add_quantity.ExecuteNonQuery();
            conn.Close();

            string query_log = "INSERT INTO inventory_log (process_type,date,product,quantity,remarks,staff_id) VALUES('Stock Out (Hospitalization Product)' , current_timestamp(),'" + hosp_prod_name.Text + "','" + hosp_prod_quan.Text + "', 'Used in hospitalization', (SELECT staff.id FROM person,staff WHERE person.id = staff.person_id AND concat(firstname,' ', middlename,' ',lastname) = '" + CaPY_SAD.Login.UserDisplayDetails.name + "'))";
            conn.Open();
            MySqlCommand comm_log = new MySqlCommand(query_log, conn);
            comm_log.ExecuteNonQuery();
            conn.Close();

            string query_updateavail = "UPDATE product_inventory SET status = 'unavailable' WHERE quantity <= 0";
            conn.Open();
            MySqlCommand comm_updateavail = new MySqlCommand(query_updateavail, conn);
            comm_updateavail.ExecuteNonQuery();
            conn.Close();


            HospProds();
            loadHospData();
            servTotal();
            prodtotal();
            hospprodPanel.Visible = false;

        }

        private void hosp_prod_quan_ValueChanged(object sender, EventArgs e)
        {
            decimal price = decimal.Parse(hosp_prod_price.Text);
            decimal subtotal = price * hosp_prod_quan.Value;
            hosp_prod_subtotal.Text = subtotal.ToString();
        }

        public void load_medicine_given()
        {
            String medicine_load = "SELECT * FROM medicines_given WHERE hosp_id = " + selected_data.hosp_id + "";

            conn.Open();
            MySqlCommand comm_loadmeds = new MySqlCommand(medicine_load, conn);
            MySqlDataAdapter adp_loadmeds = new MySqlDataAdapter(comm_loadmeds);
            conn.Close();
            DataTable dt_meds = new DataTable();
            adp_loadmeds.Fill(dt_meds);

            dtgvMeds.DataSource = dt_meds;
            dtgvMeds.Columns["id"].Visible = false;
            dtgvMeds.Columns["pets_id"].Visible = false;
            dtgvMeds.Columns["hosp_id"].Visible = false;
            dtgvMeds.Columns["medicine_name"].HeaderText = "Medicine Name";
            dtgvMeds.Columns["endorsed"].HeaderText = "Medicine Source";
            dtgvMeds.Columns["given_on"].HeaderText = "Date Given";

        }
      //  public static Boolean endorse_action_add;
        private void addEndorsedBtn_Click(object sender, EventArgs e)
        {
           // endorse_action_add = true;
            addEndorsedPanel.Visible = true;
            addEndorsedPanel.Enabled = true;
            addEndorsedPanel.Size = new Size(572, 290);
            addEndorsedPanel.Location = new Point(548, 4);
        }

        private void endorsedBackBtn_Click(object sender, EventArgs e)
        {
            addEndorsedPanel.Visible = false;
            addEndorsedPanel.Enabled = false;
        }

        private void endorsedCancelBtn_Click(object sender, EventArgs e)
        {
            addEndorsedPanel.Visible = false;
            addEndorsedPanel.Enabled = false;
        }

        private void cancelCheckout_Click(object sender, EventArgs e)
        {
            checkoutPanel.Visible = false;
        }

        private void coutBtn_Click(object sender, EventArgs e)
        {
            loadCageData();
            loadHospData();


            POS pos = new POS();
            selected_data.checkout = true;
            this.Hide();
            pos.Show();
            pos.previousform = this;

            checkoutPanel.Visible = false;
        }

        public static string days;
        public void addfee()
        {
            decimal rmtotal;

            String get_date = "SELECT DATEDIFF(now(), '" + admission_date + "') as days;";


            MySqlCommand comm_getdate = new MySqlCommand(get_date, conn);
            comm_getdate.CommandText = get_date;


            conn.Open();
            MySqlDataReader drd_getdate = comm_getdate.ExecuteReader();

            while (drd_getdate.Read())
            {
                days = drd_getdate["days"].ToString();
            }
            conn.Close();
            roomfee.Text = cage_price.ToString();
            dayTxt.Text = days;
            rmtotal = decimal.Parse(days) * cage_price;
            roomTotal.Text = rmtotal.ToString();
            selected_data.roomtotal = rmtotal;
            prodctot.Text = prodTotalTxt.Text;
            servctot.Text = ServTotalTxt.Text;
            selected_data.prodtotal = decimal.Parse(prodTotalTxt.Text);
            selected_data.servtotal = decimal.Parse(ServTotalTxt.Text);
            decimal total;

            total = decimal.Parse(prodTotalTxt.Text) + decimal.Parse(ServTotalTxt.Text) + decimal.Parse(roomTotal.Text);
            selected_data.total = total;
            totalTxt.Text = total.ToString();

            string query_subtotal = "UPDATE hospitalization SET subtotal = " + totalTxt.Text + " WHERE  id =  " + Hosp.selected_data.hosp_id + "";
            conn.Open();
            MySqlCommand comm_subtotal = new MySqlCommand(query_subtotal, conn);
            comm_subtotal.ExecuteNonQuery();
            conn.Close();
        }

        private void viewHospReports_Click(object sender, EventArgs e)
        {
            View_Service_Reports service_reps = new View_Service_Reports();
            service_reps.previousform = this;
            this.Hide();
            service_reps.Show();
        }


        //private void editEndorsedBtn_Click(object sender, EventArgs e)
        //{
        //    //endorse_action_add = false;
        //    //addEndorsedPanel.Visible = true;
        //    //addEndorsedPanel.Enabled = true;
        //    //addEndorsedPanel.Size = new Size(572, 290);
        //    //addEndorsedPanel.Location = new Point(548, 4);

        //    //string query_updatevalue = "UPDATE product_inventory SET status = 'unavailable' WHERE quantity <= 0";
        //    //conn.Open();
        //    //MySqlCommand comm_updatevalue = new MySqlCommand(query_updatevalue, conn);
        //    //comm_updatevalue.ExecuteNonQuery();
        //    //conn.Close();

        //}

    }
}
