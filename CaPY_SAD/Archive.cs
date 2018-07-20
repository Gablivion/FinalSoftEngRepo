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
    public partial class Archive : Form
    {
        public Form previousform { get; set; }
        MySqlConnection conn;

        public Archive()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root; Allow Zero Datetime=true");
            InitializeComponent();
        }

        private void Archive_Load(object sender, EventArgs e)
        {
            loadData();

            if (CaPY_SAD.Login.UserDisplayDetails.position == "staff")
            {
                dtgvStaff.Enabled = false;

            }


        }


        public void loadData()
        {

            String query = "SELECT * FROM customers, person WHERE customers.person_id = person.id AND archived = 'yes'";


            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dtgvCustomers.DataSource = dt;
            dtgvCustomers.Columns["id"].Visible = false;
            dtgvCustomers.Columns["id1"].Visible = false;
            dtgvCustomers.Columns["person_id"].Visible = false;
            dtgvCustomers.Columns["firstname"].HeaderText = "Firstname";
            dtgvCustomers.Columns["middlename"].HeaderText = "Middlename";
            dtgvCustomers.Columns["lastname"].HeaderText = "Lastname";
            dtgvCustomers.Columns["gender"].HeaderText = "Gender";
            dtgvCustomers.Columns["birthdate"].HeaderText = "Birthdate";
            dtgvCustomers.Columns["address"].HeaderText = "Address";
            dtgvCustomers.Columns["contact_number"].HeaderText = "Contact Number";
            dtgvCustomers.Columns["email"].HeaderText = "Email";
            dtgvCustomers.Columns["date_added"].HeaderText = "Date Added";
            dtgvCustomers.Columns["date_modified"].HeaderText = "Date Modified";
            dtgvCustomers.Columns["archived"].Visible = false;

            String query_pet = "SELECT pets.id, pets.customer_id as cust, name, color, species, breed, pets.gender as gen, pets.birthdate as bday, microchip_number, sterilized, concat(person.firstname,' ',person.middlename,' ',person.lastname) as owner, pets.date_added as p_added, pets.date_modified as p_modified FROM pets,person,customers where customers.person_id = person.id AND customers.id = pets.customer_id AND pets.archived = 'yes'";

            conn.Open();
            MySqlCommand comm_pet = new MySqlCommand(query_pet, conn);
            MySqlDataAdapter adp_pet = new MySqlDataAdapter(comm_pet);
            conn.Close();
            DataTable dt_pet = new DataTable();
            adp_pet.Fill(dt_pet);

            dtgvPets.DataSource = dt_pet;
            dtgvPets.Columns["id"].Visible = false;
            dtgvPets.Columns["cust"].Visible = false;
            dtgvPets.Columns["name"].HeaderText = "Name";
            dtgvPets.Columns["color"].HeaderText = "Color";
            dtgvPets.Columns["species"].HeaderText = "Species";
            dtgvPets.Columns["breed"].HeaderText = "Breed";
            dtgvPets.Columns["gen"].HeaderText = "Gender";
            dtgvPets.Columns["bday"].HeaderText = "Birthdate";
            dtgvPets.Columns["microchip_number"].HeaderText = "Microchip Number";
            dtgvPets.Columns["sterilized"].HeaderText = "Sterilized";
            dtgvPets.Columns["owner"].HeaderText = "Owner";
            dtgvPets.Columns["p_added"].HeaderText = "Date Added";
            dtgvPets.Columns["p_modified"].HeaderText = "Date Modified";


            String query_staff = "SELECT * FROM person,staff WHERE staff.person_id = person.id AND archived = 'yes'";


            conn.Open();
            MySqlCommand comm_staff = new MySqlCommand(query_staff, conn);
            MySqlDataAdapter adp_staff = new MySqlDataAdapter(comm_staff);
            conn.Close();
            DataTable dt_staff = new DataTable();
            adp_staff.Fill(dt_staff);

            dtgvStaff.DataSource = dt_staff;
            dtgvStaff.Columns["id"].Visible = false;
            dtgvStaff.Columns["id1"].Visible = false;
            dtgvStaff.Columns["person_id"].Visible = false;
            dtgvStaff.Columns["archived"].Visible = false;
            dtgvStaff.Columns["firstname"].HeaderText = "Firstname";
            dtgvStaff.Columns["middlename"].HeaderText = "Middlename";
            dtgvStaff.Columns["lastname"].HeaderText = "Lastname";
            dtgvStaff.Columns["gender"].HeaderText = "Gender";
            dtgvStaff.Columns["birthdate"].HeaderText = "Birthdate";
            dtgvStaff.Columns["address"].HeaderText = "Address";
            dtgvStaff.Columns["contact_number"].HeaderText = "Contact Number";
            dtgvStaff.Columns["email"].HeaderText = "Email";
          //  dtgvStaff.Columns["position"].HeaderText = "Position";
            dtgvStaff.Columns["username"].Visible = false;
            dtgvStaff.Columns["password"].Visible = false;
            dtgvStaff.Columns["date_added"].HeaderText = "Date Added";
            dtgvStaff.Columns["date_modified"].HeaderText = "Date Modified";
            dtgvStaff.Columns["status"].HeaderText = "Status";


            String query_supplier = "SELECT * FROM person,suppliers WHERE suppliers.person_id = person.id AND archived = 'yes'";

            conn.Open();
            MySqlCommand comm_suppplier = new MySqlCommand(query_supplier, conn);
            MySqlDataAdapter adp_supplier = new MySqlDataAdapter(comm_suppplier);
            conn.Close();
            DataTable dt_supplier = new DataTable();
            adp_supplier.Fill(dt_supplier);

            dtgvSuppliers.DataSource = dt_supplier;
            dtgvSuppliers.Columns["id"].Visible = false;
            dtgvSuppliers.Columns["id1"].Visible = false;
            dtgvSuppliers.Columns["archived"].Visible = false;
            dtgvSuppliers.Columns["person_id"].Visible = false;
            dtgvSuppliers.Columns["firstname"].HeaderText = "Firstname";
            dtgvSuppliers.Columns["middlename"].HeaderText = "Middlename";
            dtgvSuppliers.Columns["lastname"].HeaderText = "Lastname";
            dtgvSuppliers.Columns["gender"].HeaderText = "Gender";
            dtgvSuppliers.Columns["birthdate"].HeaderText = "Birthdate";
            dtgvSuppliers.Columns["address"].HeaderText = "Address";
            dtgvSuppliers.Columns["contact_number"].HeaderText = "Contact Number";
            dtgvSuppliers.Columns["email"].HeaderText = "Email";
            dtgvSuppliers.Columns["organization_name"].HeaderText = "Organization";
            dtgvSuppliers.Columns["date_added"].HeaderText = "Date Added";
            dtgvSuppliers.Columns["date_modified"].HeaderText = "Date Modified";

            String query_services = "SELECT * FROM services WHERE archived = 'yes'";

            conn.Open();
            MySqlCommand comm_services = new MySqlCommand(query_services, conn);
            MySqlDataAdapter adpservices = new MySqlDataAdapter(comm_services);
            conn.Close();
            DataTable dt_services = new DataTable();
            adpservices.Fill(dt_services);

            dtgvServices.DataSource = dt_services;
            dtgvServices.Columns["id"].Visible = false;
            dtgvServices.Columns["archived"].Visible = false;
            dtgvServices.Columns["name"].HeaderText = "Name";
            dtgvServices.Columns["description"].HeaderText = "Description";
            dtgvServices.Columns["price"].HeaderText = "Price";
            dtgvServices.Columns["status"].HeaderText = "Availability";
            dtgvServices.Columns["date_added"].HeaderText = "Date Added";
            dtgvServices.Columns["date_modified"].HeaderText = "Date Modified";



            String query_prod = "SELECT * FROM products WHERE archived = 'yes'";


            conn.Open();
            MySqlCommand comm_prod = new MySqlCommand(query_prod, conn);
            MySqlDataAdapter adp_prod = new MySqlDataAdapter(comm_prod);
            conn.Close();
            DataTable dt_prod = new DataTable();
            adp_prod.Fill(dt_prod);

            dtgvProducts.DataSource = dt_prod;
            dtgvProducts.Columns["id"].Visible = false;
            dtgvProducts.Columns["name"].HeaderText = "Name";
            dtgvProducts.Columns["description"].HeaderText = "Description";
            dtgvProducts.Columns["price"].HeaderText = "Price";
            dtgvProducts.Columns["expirable"].HeaderText = "Expirable";
            dtgvProducts.Columns["date_added"].HeaderText = "Date Added";
            dtgvProducts.Columns["date_modified"].HeaderText = "Date Modified";
            dtgvProducts.Columns["archived"].Visible = false;

            String query_medrec = "SELECT medical_record.id as id, name, weight, allergies, medicines_taken,remarks, date_recorded FROM medical_record,pets WHERE pets.id = pets_id AND medical_record.archived = 'yes'";

            conn.Open();
            MySqlCommand comm_medrec = new MySqlCommand(query_medrec, conn);
            MySqlDataAdapter adp_nedrec = new MySqlDataAdapter(comm_medrec);

            conn.Close();
            DataTable dt_med_rec = new DataTable();
            adp_nedrec.Fill(dt_med_rec);

            dtgvMedicalRecord.DataSource = dt_med_rec;
            dtgvMedicalRecord.Columns["id"].Visible = false;
            dtgvMedicalRecord.Columns["name"].HeaderText = "Pet Name";
            dtgvMedicalRecord.Columns["weight"].HeaderText = "Weight (kg)";
            dtgvMedicalRecord.Columns["allergies"].HeaderText = "Allergies";
            dtgvMedicalRecord.Columns["medicines_taken"].HeaderText = "Medicines Taken";
            dtgvMedicalRecord.Columns["remarks"].HeaderText = "Remarks";
            dtgvMedicalRecord.Columns["date_recorded"].HeaderText = "Record Date";

        }


        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Archive_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Archive_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Archive_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }



        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        public class selected_data
        {
            public static int customer_id;
            public static int pet_id;
            public static int prod_id;
            public static int service_id;
            public static int staff_id;
            public static int supplier_id;
            public static int med_id;
        }
           




       
 
    

       
    }

}
