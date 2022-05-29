using System.Configuration;
using System.Windows.Forms;
using jpddoocp.helpers;
namespace jpddoocp.models
{
    class DbSetupModel:AbstractDbModel
    {
        public void SetupTables()
        {
            DropTables();
            SetupTableUserTypes();
            SetupTableUsers();
            SetupTableAdmins();
            SetupTableCustomers();
            SetupTableCategory();
            SetupTableProducts();
            SetupTableDeliveryModes();
            SetupTableOrders();
            SetupTableOrderProducts();
            SetupTablePaymentModes();
            SetupTableInvoices();
            SetupViewCustomerDetails();
            SetupViewAdminDetails();
            SetupViewInvoiceDetails();
            SetupViewProductView();

            MessageBox.Show("Database Setup Successfully!", ConfigurationManager.AppSettings["appName"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void SetupTableCategory()
        {
            //Table: Category ={id, category}
            string sqlQuery = 
                  "CREATE TABLE categories(" +
                  "id int auto_increment, " +
                  "category varchar(50) NOT NULL, " +
                  "PRIMARY KEY(id)," +
                  "CONSTRAINT UC_Category UNIQUE(category)" +
                  ");" +
                  "INSERT INTO categories (category) " +
                  "VALUES " +
                  "('snacks')," +
                  "('soup')," +
                  "('main course');";
            CUquery(sqlQuery);
        }
        private void SetupTableProducts()
        {
            //Table: Products ={id, product, price, category_id}
            string sqlQuery = 
                  "CREATE TABLE products(" +
                  "id int auto_increment, " +
                  "product varchar(100) NOT NULL, " +
                  "price float NOT NULL, "+
                  "category_id int NOT NULL, " +
                  "PRIMARY KEY(id)," +
                  "FOREIGN KEY (category_id) REFERENCES categories(id), " +
                  "CONSTRAINT UC_Product UNIQUE(product)" +
                  ");" +
                  "INSERT INTO products (product, price, category_id) " +
                  "VALUES " +
                  "('Fried Chips',60,1)," +
                  "('Fried Chicken',110,1)," +
                  "('Chinese Soup',80,2)," +
                  "('Marocain Soup',90,2)," +
                  "('Fried Rice',150,3)," +
                  "('Fried Noddles',170,3);";
            CUquery(sqlQuery);
        }
        private void SetupTableUserTypes()
        {
            //Table: Users ={id,usertype}
            string sqlQuery =  
                  "CREATE TABLE usertypes(" +
                  "id int auto_increment, " +
                  "usertype varchar(50) NOT NULL, " +
                  "PRIMARY KEY(id)," +
                  "CONSTRAINT UC_UserTypes UNIQUE(usertype)" +
                  ");" +
                  "INSERT INTO usertypes (usertype) " +
                  "VALUES " +
                  "('admin')," +
                  "('customer');";
            CUquery(sqlQuery);
        }
        private void SetupTableUsers()
        {
            //Table: users ={id,username, pwd, usertype_id}
            string encryptedPassword = HasherHelper.Hash("123456");
            string sqlQuery =
                  "CREATE TABLE users(" +
                  "id int auto_increment, " +
                  "username varchar(50) NOT NULL, " +
                  "pwd varchar(200) NOT NULL, " +
                  "usertype_id int NOT NULL, " +
                  "PRIMARY KEY(id)," +
                   "FOREIGN KEY (usertype_id) REFERENCES usertypes(id)" +
                  ");" +
                  "INSERT INTO users (username, pwd,usertype_id) " +
                  "VALUES " +
                  "('jpphanjoo','"+encryptedPassword+"',1)," +
                   "('tomhanks','" + encryptedPassword + "',2)," +
                    "('mjordan','" + encryptedPassword + "',2)," +
                  "('jtalbot','" + encryptedPassword + "',1);";
            CUquery(sqlQuery);
        }
        private void SetupTableAdmins()
        {
            //Table: admins ={id,firstname, surname, user_id}
            string sqlQuery =
                  "CREATE TABLE admins(" +
                  "id int auto_increment, " +
                  "firstname varchar(50) NOT NULL, " +
                  "surname varchar(50) NOT NULL, " +
                  "user_id int NOT NULL, " +
                  "PRIMARY KEY(id)," +
                  "FOREIGN KEY (user_id) REFERENCES users(id)" +
                  ");" +
                  "INSERT INTO admins (firstname, surname, user_id) " +
                  "VALUES " +
                  "('jean philippe conchiano','phanjoo',1)," +
                  "('jonathan','talbot',2);";
            CUquery(sqlQuery);
        }
        private void SetupTableCustomers()
        {
            //Table: customers ={id,firstname, surname,address, email, user_id}
            string sqlQuery =
                  "CREATE TABLE customers(" +
                  "id int auto_increment, " +
                  "firstname varchar(50) NOT NULL, " +
                  "surname varchar(50) NOT NULL, " +
                  "address varchar(200)  DEFAULT 'N/A', " +
                  "email varchar(50) NOT NULL, " +
                  "user_id int NOT NULL, " +
                  "PRIMARY KEY(id)," +
                  "FOREIGN KEY (user_id) REFERENCES users(id)" +
                  ");" +
                  "INSERT INTO customers (firstname, surname, email, user_id) " +
                  "VALUES " +
                  "('tom','hanks','tomhank@gmail.com',2)," +
                  "('michael','jordan','michaeljordan@yahoo.com',3);";
            CUquery(sqlQuery);
        }
        private void SetupTableDeliveryModes()
        {
            //Table: delivery_modes ={id,mode}
            string sqlQuery =
                  "CREATE TABLE delivery_modes(" +
                  "id int auto_increment, " +
                  "mode varchar(50) NOT NULL UNIQUE, " +
                  "PRIMARY KEY(id)" +
                  ");" +
                  "INSERT INTO delivery_modes (mode) " +
                  "VALUES " +
                  "('hand picking')," +
                  "('online');";
            CUquery(sqlQuery);
        }
        private void SetupTableOrders()
        {
            //Table: orders ={id,order_date, status, delivery_mode_id, customer_id}
            string sqlQuery =
                  "CREATE TABLE orders(" +
                  "id int auto_increment, " +
                  "order_date DATETIME NOT NULL DEFAULT NOW(), " +
                  "status varchar(20) NOT NULL DEFAULT 'Pending', " +
                  "delivery_mode_id int NOT NULL, " +
                  "customer_id int NOT NULL, " +
                  "PRIMARY KEY(id), " +
                  "FOREIGN KEY (delivery_mode_id) REFERENCES delivery_modes(id), " +
                  "FOREIGN KEY (customer_id) REFERENCES customers(id)" +
                  ");" +
                  "INSERT INTO orders (delivery_mode_id, customer_id) " +
                  "VALUES " +
                  "(1,1)," +
                  "(2,2)";
            CUquery(sqlQuery);
        }
        private void SetupTableOrderProducts()
        {
            //Table: product_orders ={order_id,product_id, qty}
            string sqlQuery =
                  "CREATE TABLE order_products(" +
                  "order_id int NOT NULL, " +
                  "product_id int NOT NULL, " +
                  "qty int NOT NULL, "+
                  "PRIMARY KEY(order_id, product_id), " +
                  "FOREIGN KEY (order_id) REFERENCES orders(id), " +
                  "FOREIGN KEY (product_id) REFERENCES products(id)" +
                  ");" +
                  "INSERT INTO order_products " +
                  "VALUES " +
                  "(1, 1, 2)," +
                  "(1, 2, 3)," +
                  "(1, 5, 2)," +
                  "(2, 3, 4)," +
                  "(2, 4, 1)";
            CUquery(sqlQuery);
        }
        private void SetupTablePaymentModes()
        {
            //Table: payment_modes ={id,mode}
            string sqlQuery =
                  "CREATE TABLE payment_modes(" +
                  "id int auto_increment, " +
                  "mode varchar(50) NOT NULL UNIQUE, " +
                  "PRIMARY KEY(id)" +
                  ");" +
                  "INSERT INTO payment_modes (mode) " +
                  "VALUES " +
                  "('Cash'), " +
                  "('Debit Card'), " +
                  "('Credit Card');";
            CUquery(sqlQuery);
        }
        private void SetupTableInvoices()
        {
            //Table: invoices ={id,order_id, payment_date,payment_mode_id,admin_id}
            string sqlQuery =
                  "CREATE TABLE invoices(" +
                  "id int auto_increment NOT NULL, " +
                  "order_id int NOT NULL, " +
                  "payment_date DATETIME NOT NULL DEFAULT NOW(), " +
                  "payment_mode_id int NOT NULL, " +
                  "admin_id int NOT NULL, "+
                  "PRIMARY KEY(id), " +
                  "FOREIGN KEY (order_id) REFERENCES orders(id), " +
                  "FOREIGN KEY (payment_mode_id) REFERENCES payment_modes(id), " +
                  "FOREIGN KEY (admin_id) REFERENCES admins(id)" +
                  ");" +
                  "INSERT INTO invoices (order_id, payment_mode_id, admin_id) " +
                  "VALUES  "+
                  "(1, 1, 1)," +
                  "(2, 3, 2)";
            CUquery(sqlQuery);
        }

        private void SetupViewCustomerDetails()
        {
            
            string sqlQuery = $"CREATE VIEW customerDetailsView AS SELECT CONCAT(c.firstname, \" \",c.surname) " +
             "AS name, c.address, c.email, u.username FROM customers c " +
             "INNER JOIN users u ON c.user_id=u.id;";
            CUquery(sqlQuery);
        }
        private void SetupViewAdminDetails()
        {

            string sqlQuery = $"CREATE VIEW adminDetailsView AS SELECT CONCAT(a.firstname, \" \",a.surname) " +
             "AS name, u.username FROM admins a " +
             "INNER JOIN users u ON a.user_id=u.id;";
            CUquery(sqlQuery);
        }
        private void SetupViewInvoiceDetails()
        {
            string sqlQuery =
                "CREATE VIEW invoice_view  AS SELECT inv.order_id AS  `Order ID`, inv.payment_date, pm.mode, " +
                "CONCAT(ad.firstname, \" \", ad.surname) AS `Received By`, CONCAT (cs.firstname, \" \", cs.surname) AS `Customer` from invoices inv "+
                "INNER JOIN orders ord on inv.order_id = ord.id "+
                "INNER JOIN admins ad on inv.admin_id = ad.id "+
                "INNER JOIN users u "+
                "INNER JOIN customers cs on cs.user_id = u.id "+
                "INNER JOIN payment_modes pm on pm.id = inv.payment_mode_id "+
                "INNER JOIN delivery_modes dm on dm.id = ord.delivery_mode_id "+
                "ORDER BY ord.id ASC; ";
            CUquery(sqlQuery);
        }
        private void SetupViewProductView()
        {
            string sqlQuery = "CREATE VIEW product_view AS SELECT c.category AS `Category`, p.product AS Item, p.price AS `Price (Rs)` FROM products p "+
                                "INNER JOIN categories c ON c.id = p.category_id;";

            CUquery(sqlQuery);
        }
        private void DropTables()
        {
            string sqlQuery =
                              "DROP VIEW IF EXISTS product_view; " +
                              "DROP VIEW IF EXISTS invoice_view; " +
                              "DROP VIEW IF EXISTS customerDetailsView; " +
                              "DROP VIEW IF EXISTS adminDetailsView; " +
                              "DROP TABLE IF EXISTS invoices; " +
                              "DROP TABLE IF EXISTS payment_modes;"  +
                              "DROP TABLE IF EXISTS order_products; " +
                              "DROP TABLE IF EXISTS orders; " +
                              "DROP TABLE IF EXISTS delivery_modes; " +
                              "DROP TABLE IF EXISTS products; " +
                              "DROP TABLE IF EXISTS categories; " +
                              "DROP TABLE IF EXISTS admins; " +
                              "DROP TABLE IF EXISTS customers; " +
                              "DROP TABLE IF EXISTS users; " +
                              "DROP TABLE IF EXISTS usertypes; ";

            CUquery(sqlQuery);
        }
    }

}
