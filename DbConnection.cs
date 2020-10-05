using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;

namespace cmpg223_final_project.classes
{
    public class DbConnection
    {
        /*  TO-DO List
         *  Exception handling is needed.
         *  Certain CRUD functions need writing.
         *  InsertIntoStock decimal problem needs fixing.
         *  Update Employees does nothing yet. Just a function with strings??
         */

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


        /*A function for if you need a connection to another database.
         * This effectively means you can open several connections.
         * Not tested with several connections, if using multiple be wary.
         */
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
        public void UpdateEmployees(int id, string col, string value)
        {
            string qu = "UPDATE `paris_pub`.`employee` SET `"+ col + "` = '" + value + "' WHERE (`employee_id` = '" + id + "');";
            ExecuteQuery(qu);
        }
        public string[] ReadFromEmployees(int id)
        {
            string qu = "SELECT * FROM `paris_pub`.employee WHERE `employee_id` = '" + id + "';";
            string[] ret = new string[7];
            Connection.Open();
            MySqlCommand cmd = new MySqlCommand(qu, Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ret[0] = reader[0].ToString();
                ret[1] = reader[1].ToString();
                ret[2] = reader[2].ToString();
                ret[3] = reader[3].ToString();
                ret[4] = reader[4].ToString();
                ret[5] = reader[5].ToString();
                ret[6] = reader[6].ToString();
            }
            Connection.Close();
            return ret;
        }

        /*-----Stock-----*/
        //Needs fixing, the decimal converts the '.' in a float to a ',' e.g. 4.5 = '4,5'. This fucks the sql code and we need it fixed
        /*public void InsertIntoStock(string prod_type, string prod_name, int in_stock, decimal price_unit)
        {
            try
            {
                string qu = "INSERT INTO `paris_pub`.`stock` (`prod_type`, `prod_name`, `in_stock`, `price_unit`) VALUES ('" +
                    prod_type  +"', '" +
                    prod_name + "', '" +
                    in_stock + "', '" +
                    price_unit + "');";
                ExecuteQuery(qu);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                throw;
            }
        }*/

        public void InsertIntoStock(string prod_type, string prod_name, int in_stock, string price_unit)
        {
            try
            {
                string qu = "INSERT INTO `paris_pub`.`stock` (`prod_type`, `prod_name`, `in_stock`, `price_unit`) VALUES ('" +
                    prod_type + "', '" +
                    prod_name + "', '" +
                    in_stock + "', '" +
                    price_unit + "');";
                ExecuteQuery(qu);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                throw;
            }
        }

        public void ChangeStock(int id, string prod_type, string prod_name, string in_stock, decimal price)
        {
            string qu = "UPDATE `paris_pub`.`stock` SET " +
                "`prod_type` = '" + prod_type + "', " +
                "`prod_name` = '" + prod_name + "', " +
                "`in_stock` = '"+ in_stock + "', " +
                "`price_unit` = '" + price + "' " +
                "WHERE (`stock_id` = '" + id + "');";
        }

        public string[] ReadFromStock(int id)
        {
            string qu = ReadString("stock", id);
            string[] ret = new string[5];
            Connection.Open();
            MySqlCommand cmd = new MySqlCommand(qu, Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ret[0] = reader[0].ToString();
                ret[1] = reader[1].ToString();
                ret[2] = reader[2].ToString();
                ret[3] = reader[3].ToString();
                ret[4] = reader[4].ToString();
            }

            return ret;
        }

        public void DeleteFromStock(int id)
        {
            string qu = "DELETE FROM `paris_pub`.`stock` WHERE (`stock_id` = '" + id + "');";
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
        public string[] ReadFromOrders(int id)
        {
            string[] ret = new string[7];
            string qu = "SELECT * FROM `paris_pub`.`order` WHERE `order_id` = '" + id + "';";
            Connection.Open();
            MySqlCommand cmd = new MySqlCommand(qu, Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ret[0] = reader[0].ToString();
                ret[1] = reader[1].ToString();
                ret[2] = reader[2].ToString();
                ret[3] = reader[3].ToString();
                ret[4] = reader[4].ToString();
                ret[5] = reader[5].ToString();
                ret[6] = reader[6].ToString();
            }

            return ret;
        }
        public void UpdateOrder(int id, string col, string value)
        {
            string qu = "UPDATE `paris_pub`.`order` SET `" + col + "` = '" + value +"' WHERE (`order_id` = '" + id + "');";
            ExecuteQuery(qu);
        }
        public void RemoveFromOrders(int id)
        {
            string qu = "DELETE FROM `paris_pub`.`order` WHERE (`order_id` = '" + id + "');";
            ExecuteQuery(qu);
        }

        /*----Rights----*/
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

        public void RemoveFromRights(int id)
        {
            string qu = "DELETE FROM `paris_pub`.`rights` WHERE (`employee_id` = '" + id + "');";
        }

        public string[] ReadFromRights(int id)
        {
            string[] ret = new string[6];
            string qu = "SELECT * FROM `paris_pub`.`rights` WHERE (`employee_id` = '" + id + "');";
            Connection.Open();
            MySqlCommand cmd = new MySqlCommand(qu, Connection);
            var reader = cmd.ExecuteReader();
            reader.Read();
            ret[0] = reader[0].ToString();
            ret[1] = reader[1].ToString();
            ret[2] = reader[2].ToString();
            ret[3] = reader[3].ToString();
            ret[4] = reader[4].ToString();
            ret[5] = reader[5].ToString();

            return ret;
        }

        /*----Transaction-----*/
        public void InsertIntoTransaction(int employee_id, decimal total_price, string date)
        {
            string qu = "INSERT INTO `paris_pub`.`transaction` (`employee_id`, `total_price`, `date_of_transac`) VALUES ('"
                + employee_id + "', '"
                + total_price + "', '"
                + date + "');";
            ExecuteQuery(qu);
        }

        public string[] ReadFromTransaction(int TransacId)
        {
            string SQLALL = "SELECT * FROM `paris_pub`.transaction WHERE `transac_id` = '" + TransacId + "';";
            string[] transac = new string[4];
            Connection.Open();
            MySqlCommand cmd = new MySqlCommand(SQLALL, Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                transac[0] = reader[0].ToString();
                transac[1] = reader[1].ToString();
                transac[2] = reader[2].ToString();
                transac[3] = reader[3].ToString();
            }
            Connection.Close();
            return transac;
        }

        public void DeleteFromTransaction(int id)
        {
            string qu = "DELETE FROM `paris_pub`.`transaction` WHERE (`transac_id` = '" + id + "');";
            ExecuteQuery(qu);
        }

        public void UpdateTransaction(int id, string col, string value)
        {
            string qu = "UPDATE `paris_pub`.`transaction` SET `" + col + "` = '" + value + "' WHERE (`transac_id` = '" + id + "');";
        }

        /*----Transaction Details----*/
        public void InsertTransactionDetails(string trans_id, string stock_id, string amount_sold, string price)
        {
            string qu = "INSERT INTO `paris_pub`.`trans_details` (`transac_id`, `stock_id`, `amount_sold`, `price_at_date` ) VALUES ("
                + trans_id + ", "
                + stock_id + ", "
                + amount_sold + ", +"
                + price +") ;";
            ExecuteQuery(qu);
        }

        public string[] ReadFromTransactionDetails(int TransacId)
        {
            string SQLALL = "SELECT * FROM `paris_pub`.trans_details WHERE `transac_id` = '" + TransacId + "';";
            string[] transD = new string[4];
            Connection.Open();
            MySqlCommand cmd = new MySqlCommand(SQLALL, Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                transD[0] = reader[0].ToString();
                transD[1] = reader[1].ToString();
                transD[2] = reader[2].ToString();
                transD[3] = reader[3].ToString();
            }
            Connection.Close();
            return transD;
        }

        public void DeleteFromTransactionDetails(int id)
        {
            string qu = "DELETE FROM `paris_pub`.`trans_details` WHERE (`trans_id` = '" + id + "');";
            ExecuteQuery(qu);
        }

        public void ChangeTransactionDetails(int id, string col, string value)
        {
            string qu = "UPDATE `paris_pub`.`trans_details` SET `"+ col + "` = '" + value + "' WHERE (`transac_id` = '" + id + "');";
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
            while (reader.Read())
            {

            }
            Connection.Close();
        }

        //Function made for paris_pub to return a string to read a record from a table.
        //Will need expanding to handling seperate use cases      
        public string GetAdminId()
        {
            string qu = "SELECT * FROM `paris_pub`.`rights` WHERE (`admin` = '1');";
            Connection.Open();
            MySqlCommand cmd = new MySqlCommand(qu, Connection);
            var reader = cmd.ExecuteReader();
            reader.Read();
            string ret = reader[0].ToString();
            Connection.Close();
            return ret.ToString();
        }

        public string ReadString(string table, int id)
        {
            return "SELECT * FROM `paris_pub`.`" + table + "` WHERE `" + table + "_id` = '" + id + "';";
        }
    }
}