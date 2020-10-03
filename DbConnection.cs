using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;

namespace mock_test.classes
{
    public class DbConnection
    {
        public MySqlConnection Connection;

        /*Amend server address, database name, uid, password and port 
         * to local machine or wherever database is located
         * Extra not: this is for a MySql Database, preferably v8.0.
         * But should be compatible with 5.7/8 */
        public DbConnection()
        {
            string server = "127.0.0.7";
            string database = "paris_pub";
            string uid = "root";
            string password = "special";
            string port = "8080";
            string conStr;
            conStr = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";PASSWORD=" + password + "; PORT=" + port + ";";
            MySqlConnection con = new MySqlConnection(conStr);

            Connection = con;
        }

        public DbConnection(string server, string database, string uid, string port, string password = "")
        {
            string conStr = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";PASSWORD=" + password + "; PORT=" + port + ";";
            MySqlConnection con = new MySqlConnection(conStr);
            Connection = con;
        }

        public MySqlConnection ReturnConnection()
        {

            return Connection;
        }

        public void AddtoTable(string qu)
        {
            Connection.Open();
            MySqlCommand cmd = new MySqlCommand(qu, ReturnConnection());
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        /*-----Employees-----*/
        public void InsertIntoEmployees(string name, string surname, int gender, string date, string password)
        {
            DateTime dDate;
            string sDatum;
            if (DateTime.TryParse(date, out dDate))
            {
                sDatum = String.Format("{0:yyyy/MM/d}", dDate);
                if (gender == 0 || gender == 1)
                {
                    string qu = "INSERT INTO `paris_pub`.`employee` (`first_name`, `surname`, `gender`, `date_of_birth`, `password`) VALUES ('" + name
                    + "', '" + surname
                    + "', b'" + gender
                    + "', '" + date
                    + "', '" + password + "');";
                    ExecuteQuery(qu);
                }
                else
                {
                    Console.WriteLine("Gender does not exist.");
                }
            }
            else
            {
                Console.WriteLine("DateTime is wrong");
            }
            
        }
        public void DeleteFromEmployees(string id)
        {
            string qu = "DELETE FROM `paris_pub`.`employee` WHERE (`employee_id` = '" + id + "');";
            ExecuteQuery(qu);
        }
        public void DeleteFromEmployees(int id)
        {
            string qu = "DELETE FROM `paris_pub`.`employee` WHERE (`employee_id` = '" + id + "');";
            ExecuteQuery(qu);
        }
        public void UpdateEmployees()
        {
            string qu = "UPDATE `paris_pub`.`employee` SET `password` = 'passie' WHERE (`employee_id` = '1');";
            string equ = "UPDATE `paris_pub`.`employee` SET `surname` = 'Strobel', `gender` = '0', `date_of_birth` = '1999-03-06', `password` = '123' WHERE(`employee_id` = '2')";
        }
        /*-----Stock-----*/
        public void InsertIntoStock(string prod_type, string prod_name, int in_stock, string date, decimal price_unit)
        {
            string qu = "INSERT INTO `paris_pub`.`stock` (`prod_type`, `prod_name`, `in_stock`, `date`, `price_unit`) VALUES ('"
                + prod_type + "', '" 
                + prod_name + "', '" 
                + in_stock + "', '" 
                + date + "', '" 
                + price_unit + "');";
            ExecuteQuery(qu);
        }

        /*----Transaction-----*/
        public void InsertIntoTransaction(int employee_id, decimal total_price, string date)
        {
            string qu = "INSERT INTO `paris_pub`.`transaction` (`employee_id`, `total_price`, `date_of_transac`) VALUES ('"
                + employee_id + "', '"
                + total_price+ "', '"
                + date+ "');";
            ExecuteQuery(qu);
        }

        /*----Order-----*/
        public void InsertIntoOrders(string supplier, int amount, string ord_date, string arr_date, int stock_id, decimal cost)
        {
            string qu = "INSERT INTO `paris_pub`.`order` (`supplier`, `amount`, `order_date`, `arrival_date`, `stock_id`, `cost`) VALUES('"
                + supplier + "', '"
                + amount + "', '" 
                + ord_date + "', '"
                + arr_date + "', '"
                + stock_id + "', '"
                + cost + "');";
            ExecuteQuery(qu);
        }

        /*-----Rights-----*/
        public void InsertIntoRights(int employee_id, short employees, short stocks, short orders, short trans, short admin)
        {
            string qu = "SELECT * FROM paris_pub.employee where `employee_id` = '" + employee_id + "';";

            try
            {
                Connection.Open();
                MySqlCommand cmd = new MySqlCommand(qu, Connection);
                var reader = cmd.ExecuteReader();
                var user = reader.Read();
                Connection.Close();
                Console.WriteLine(user);
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine("Employee does not exist");
                Console.Write("Show complete error?(Y/N): ");
                string answer = "";
                do
                {
                    answer = Console.ReadLine().ToLower();
                    if (answer == "y")
                    {
                        Console.WriteLine(e);
                    }
                    else if(answer != "n")
                    {
                        Console.Write("Please Enter 'Y' or 'N': ");
                    }

                } while (answer != "y" && answer != "n");

                throw;
            }



            qu = "INSERT INTO `paris_pub`.`rights` (`employee_id`, `employees`, `stocks`, `orders`, `transactions`, `admin`) VALUES ('"
                + employee_id + "', b'" 
                + employees + "', b'"
                + stocks + "', b'"
                + orders + "', b'"
                + trans + "', b'"
                + admin + "');";
            ExecuteQuery(qu);
        }

        public void ChangeRights(string column, short right, string user)
        {
            string qu = "UPDATE `paris_pub`.`rights` SET `" + column + "` = '" + right + "' WHERE (`employee_id` = '" + user + "');";
            ExecuteQuery(qu);
        }

        /*-----Non table specifics-----*/
      /*Executes sql queries, any CUD commands. Read commands should
         *   must be written in full code. The function for reading from
         *   the database is still WIP. See TO-DO List, or the 
         *   ExecuteRead(string qu) function*/
        public void ExecuteQuery(string qu)
        {
            Connection.Open();
            MySqlCommand cmd = new MySqlCommand(qu, ReturnConnection());
            cmd.ExecuteNonQuery();
            Connection.Close();
        }


        //Function WIP. Do not use.
        public void ExecuteRead(string qu)
        {
            Connection.Open();
            MySqlCommand cmd = new MySqlCommand(qu, Connection);
            var reader = cmd.ExecuteReader();
            var user = reader.Read();
            Connection.Close();
        }
    }
}
