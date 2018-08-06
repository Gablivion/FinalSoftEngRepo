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
        DataTable services = new DataTable();
        public Hosp()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root; Allow Zero Datetime=True ");
            InitializeComponent();
        }

        private void Hosp_Load(object sender, EventArgs e)
        {
            detailPanel.Size = new Size(1134, 336);
            detailPanel.Location = new Point(21, 604);
            detailPanel.Visible = true;
            checkoutBtn.Enabled = false;
            loadCageData();
            loadpets();
            service();

            services.Columns.Add("serv_id", typeof(string));
            services.Columns.Add("pet_id", typeof(string));
            services.Columns.Add("Service", typeof(string));
            services.Columns.Add("Pet", typeof(string));
            services.Columns.Add("Price", typeof(string));
            
            
           
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
            dtgvHospitalization.Columns["subtotal"].HeaderText = "Subtotal";
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
            addCagePanel.Size = new Size(486, 233);
            addCagePanel.Location = new Point(367, 380);


        }

        private void addHospBtn_Click(object sender, EventArgs e)
        {
            cagePanel.Visible = true;
            cagePanel.Size = new Size(486, 233);
            cagePanel.Location = new Point(367, 380);

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
            addfee();

            string query_checkout = "UPDATE hospitalization SET status = 'discharged' WHERE  id =  " + selected_data.hosp_id + "";

            conn.Open();
            MySqlCommand comm_checkout = new MySqlCommand(query_checkout, conn);
            comm_checkout.ExecuteNonQuery();
            conn.Close();

            string query_update_cage = "UPDATE cage SET status = 'available' WHERE  id = (SELECT cage_id FROM hospitalization WHERE id  = " + selected_data.hosp_id + ")";

            conn.Open();
            MySqlCommand comm_update_cage = new MySqlCommand(query_update_cage, conn);
            comm_update_cage.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Updated", "Cage updated!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            loadCageData();
            loadHospData();
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

        public class selected_data
        {
            public static int cage_id;
            public static int hosp_id;
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
                    addHospPanel.Size = new Size(486, 233);
                    addHospPanel.Location = new Point(367, 380);

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
    
        private void dtgvHospitalization_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            detailPanel.Visible = false;
           // addHospBtn.Enabled = false;
        

            if (e.RowIndex > -1)
            {
                int selected_id = int.Parse(dtgvHospitalization.Rows[e.RowIndex].Cells["id"].Value.ToString());
                admission_date = dtgvHospitalization.Rows[e.RowIndex].Cells["d_in"].Value.ToString();
             
                addfee();
                selected_data.hosp_id = selected_id;
                loadVitals();
                HospProds();
                EndorsedProds();
              
                getTotal();
            
                if (dtgvHospitalization.Rows[e.RowIndex].Cells["status"].Value.ToString() == "discharged")
                {
                    checkoutBtn.Enabled = false;
                }
                else
                {
                    checkoutBtn.Enabled = true;
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
                if (cageNameTxt.Text == "" || cagedescTxt.Text == "")
                {
                    MessageBox.Show("Please fill up all fields!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    string query_cage = "INSERT INTO cage(name,description, status) VALUES ('" + cageNameTxt.Text + "','" + cagedescTxt.Text + "','available')";

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

        private void addEndorsedBtn_Click(object sender, EventArgs e)
        {
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
            if (e.RowIndex > -1)
            {
                int selected_id = int.Parse(dtgvAddProd.Rows[e.RowIndex].Cells["id"].Value.ToString());
                inv_id = selected_id;

                String query_prods = "SELECT product_inventory.id as id, products.name as product, products.price as price, quantity FROM products, product_inventory WHERE product_inventory.products_id = products.id AND  product_inventory.id  = " + inv_id + " ";

                MySqlCommand comm_prods = new MySqlCommand(query_prods, conn);
                comm_prods.CommandText = query_prods;

                conn.Open();
                MySqlDataReader drd_addprod = comm_prods.ExecuteReader();


                while (drd_addprod.Read())
                {
                    addprodname.Text = drd_addprod["product"].ToString();                   
                    addprodquan.Maximum = int.Parse(drd_addprod["quantity"].ToString());
                    addprodprice.Text = drd_addprod["price"].ToString();
                }
                conn.Close();
                addProdPaneldtgv.Visible = false;
                addprodsPanel.Visible = true;
                addprodsPanel.Size = new Size(454, 269);
                addprodsPanel.Location = new Point(45, 756);

            }
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
            string query_hospprods = "INSERT INTO hosp_prods (hospitalization_id,name,quantity,price,subtotal) VALUES("+selected_data.hosp_id+", '"+addprodname.Text+ "',  '" + addprodquan.Text + "',  '" + addprodprice.Text + "', '" + subtotalTxt.Text + "')";
            conn.Open();
            MySqlCommand comm_hospprods = new MySqlCommand(query_hospprods, conn);
            comm_hospprods.ExecuteNonQuery();
            conn.Close();

            string query_add_quantity = "UPDATE product_inventory SET quantity = quantity - " + addprodquan.Value + " WHERE id = " + inv_id + " ";
            conn.Open();
            MySqlCommand comm_add_quantity = new MySqlCommand(query_add_quantity, conn);
            comm_add_quantity.ExecuteNonQuery();
            conn.Close();

            string query_log = "INSERT INTO inventory_log (process_type,date,product,quantity,remarks,staff_id) VALUES('Stock Out (Hospitalization Product)' , current_timestamp(),'" + addprodname.Text + "','" + addprodquan.Text + "', 'Used in hospitalization', (SELECT staff.id FROM person,staff WHERE person.id = staff.person_id AND concat(firstname,' ', middlename,' ',lastname) = '" + CaPY_SAD.Login.UserDisplayDetails.name + "'))";
            conn.Open();
            MySqlCommand comm_log = new MySqlCommand(query_log, conn);
            comm_log.ExecuteNonQuery();
            conn.Close();

            string query_updateavail = "UPDATE product_inventory SET status = 'unavailable' WHERE quantity <= 0";
            conn.Open();
            MySqlCommand comm_updateavail = new MySqlCommand(query_updateavail, conn);
            comm_updateavail.ExecuteNonQuery();
            conn.Close();

            getTotal();
            HospProds();

            string query_total = "UPDATE hospitalization SET subtotal = subtotal + "+decimal.Parse(totalTxt.Text)+" WHERE  id =  " + selected_data.hosp_id + "";

            conn.Open();
            MySqlCommand comm_total = new MySqlCommand(query_total, conn);
            comm_total.ExecuteNonQuery();
            conn.Close();

            loadHospData();

            addprodname.Text = "";
            addprodprice.Text = "";
            addprodquan.Maximum = 1000;
            addprodsPanel.Visible = false;

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
                }
                else
                {
                    med = 0;
                }


                string query_hospprods = "INSERT INTO endorsed_prods (hospitalization_id,name,quantity,expiration_date,medicine) VALUES(" + selected_data.hosp_id + ", '" + addEndorsedname.Text + "',  '" + endorsedQuanNum.Text + "',  '" + expirationDtp.Text+ "',"+med+")";
                conn.Open();
                MySqlCommand comm_hospprods = new MySqlCommand(query_hospprods, conn);
                comm_hospprods.ExecuteNonQuery();
                conn.Close();
                EndorsedProds();
                addEndorsedPanel.Visible = false;
                addEndorsedPanel.Enabled = false;
            }
        }

        public void getTotal()
        {
            decimal total = 0;

            for (int i = 0; i <= dtgvAddProd.Rows.Count - 1; i++)
            {

                string subs = dtgvAddProd.Rows[i].Cells["Subtotal"].Value.ToString();

                decimal decimal_sub = decimal.Parse(subs);

                total = total + decimal_sub;
      

            }
            string total_string = total.ToString();
            totalTxt.Text = total_string;
        }


        public static string days;
        public void addfee()
        {
            //int addfee;
         
            //int date;

            String get_date = "SELECT DATEDIFF(now(), '"+ admission_date +"') as days;";


            MySqlCommand comm_getdate = new MySqlCommand(get_date, conn);
            comm_getdate.CommandText = get_date;


            conn.Open();
            MySqlDataReader drd_getdate = comm_getdate.ExecuteReader();

            while (drd_getdate.Read())
            {
                 days = drd_getdate["days"].ToString();
            }
            conn.Close();
            dayTxt.Text = days;

            //month = (DateTime.Now.Month - admission_date.Month);
            //days = (DateTime.Now.Day - admission_date.Day);
            //dayTxt.Text = days.ToString();

            //MessageBox.Show(DateTime.Now.Day.ToString());
            //MessageBox.Show(admission_date.Day.ToString());

            //addfee = int.Parse(addfeeTxt.Text);

            //total = days * addfee;
            //totalTxt.Text = total.ToString();



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

            if (allergtTxt.Text == "")
            {
                MessageBox.Show("Please fill up all fields!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                string query_hospprods = "INSERT INTO allergies (pets_id,pet_allergy,recorded_on) VALUES("+ pets_id + ",'" + allergtTxt.Text + "',current_timestamp())";
                conn.Open();
                MySqlCommand comm_hospprods = new MySqlCommand(query_hospprods, conn);
                comm_hospprods.ExecuteNonQuery();
                conn.Close();
                EndorsedProds();
                addEndorsedPanel.Visible = false;
                addEndorsedPanel.Enabled = false;
                MessageBox.Show("Added Allegy");
                allergtTxt.Text = "";
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
                ageTxt.Text = drd_petdetails["age"].ToString() + " days old" ;

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
            dtgvPet.Columns["name"].HeaderText = "Name";
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
            detailPanel.Visible = true;
            petPanel.Visible = false;
            addHospBtn.Visible = true;

            if (e.RowIndex > -1)
            {
                petTxt.Text = dtgvPet.Rows[e.RowIndex].Cells["name"].Value.ToString();
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

            string query_update_cage = "UPDATE cage SET status = 'unavailable' WHERE cage.id = "+ selected_data.cage_id +"";

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
        private void dtgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                dtgvServices.Enabled = true;

                selected_serv = int.Parse(dtgvServices.Rows[e.RowIndex].Cells["id"].Value.ToString());
                load_service_acquired();
                //getTotal();
                servTotal();
                servPanel.Visible = false;
            }
            else
            {
                MessageBox.Show("Please select a service!");
            }

        }

        public void load_service_acquired()
        {
            int id;
            string serv_name;
            decimal serv_price;

            String query_get_service_details = "SELECT id,name,price FROM services WHERE id = " + selected_serv + "";
            MySqlCommand comm_get_service_details = new MySqlCommand(query_get_service_details, conn);
            comm_get_service_details.CommandText = query_get_service_details;

            conn.Open();
            MySqlDataReader drd_get_service_details = comm_get_service_details.ExecuteReader();

            while (drd_get_service_details.Read())
            {
                id = int.Parse(drd_get_service_details["id"].ToString());
                serv_name = drd_get_service_details["name"].ToString();
                serv_price = decimal.Parse(drd_get_service_details["price"].ToString());

                services.Rows.Add(id, pets_id, serv_name, petTxt.Text, serv_price);
                dtgvAccServices.DataSource = services;
                dtgvAccServices.Columns["serv_id"].Visible = false;
                dtgvAccServices.Columns["pet_id"].Visible = false;

            }

            conn.Close();
        }

        public void servTotal()
        {
            decimal total = decimal.Parse(ServTotalTxt.Text);

            for (int i = 0; i <= dtgvAccServices.Rows.Count - 1; i++)
            {

                string subs = dtgvAccServices.Rows[i].Cells["Price"].Value.ToString();

                decimal decimal_sub = decimal.Parse(subs);

                total = total + decimal_sub;

            }
            ServTotalTxt.Text = total.ToString();
        }

        private void ServTotalTxt_TextChanged(object sender, EventArgs e)
        {
            decimal total;

            totalTxt.Text = "0.00";

            total = decimal.Parse(ServTotalTxt.Text) + decimal.Parse(totalTxt.Text);

            totalTxt.Text = total.ToString();

        }



        public static int selected_prod;
        private void dtgvAvailProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                addProdPaneldtgv.Visible = true;
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
            String query_inventory = "SELECT * from hosp_prods WHERE hospitalization_id = " + selected_data.hosp_id + "";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query_inventory, conn);
            MySqlDataAdapter adp_inventory = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt_inventory = new DataTable();
            adp_inventory.Fill(dt_inventory);


            dtgvAddProd.DataSource = dt_inventory;
            dtgvAddProd.Columns["hospitalization_id"].Visible = false;
            dtgvAddProd.Columns["id"].Visible = false;
            dtgvAddProd.Columns["products_id"].HeaderText = "Product";
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
                medic_val = int.Parse(drd_get_prod_det["medicine"].ToString());

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
            hospprodPanel.Visible = true;
        }

        private void hosp_prod_quan_ValueChanged(object sender, EventArgs e)
        {
            decimal price = decimal.Parse(hosp_prod_price.Text);
            decimal subtotal = price * hosp_prod_quan.Value;

            hosp_prod_subtotal.Text = subtotal.ToString();
        }
    }

}
