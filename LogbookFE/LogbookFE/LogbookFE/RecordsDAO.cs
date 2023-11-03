using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LogbookFE
{
    internal class RecordsDAO
    {
        string connectionString = "Data Source=127.0.0.1,1433;" +
                                  "Initial Catalog=LogbookDB;" +
                                  "User Id=user;password=login;";

        public List<Record> GetPastRecords()
        {
            List<Record> listRecords = new List<Record>();

            // Testing connection to database
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            SqlCommand command = new SqlCommand("SELECT r.PK_RecordID, p.PeopleNric, p.PeopleName, " +
                                                "r.Reason, si.SignInDate, si.SignInTime, so.SignOutDate, so.SignOutTime " +
                                                "FROM RECORDS as r INNER JOIN PEOPLE as p on r.FK_PeopleID = p.PK_PeopleID " +
                                                "INNER JOIN SignIn as si on r.FK_SignInID = si.PK_SignInID " +
                                                "LEFT JOIN SignOut as so on r.FK_SignOutID = so.PK_SignOutID " +
                                                "WHERE so.SignOutDate IS NOT NULL; ", myConnection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                // Fill list of records
                while (reader.Read())
                {
                    // Initialize Record
                    Record r = new Record
                    {
                        i_Id = reader.GetInt32(reader.GetOrdinal("PK_RecordID")),
                        s_Nric = reader.GetString(reader.GetOrdinal("PeopleNric")),
                        s_Name = reader.GetString(reader.GetOrdinal("PeopleName")),
                        s_Reason = reader.GetString(reader.GetOrdinal("Reason")),
                        dt_DateTimeIn = GetDateTime(reader.GetString(reader.GetOrdinal("SignInDate")), reader.GetString(reader.GetOrdinal("SignInTime"))),
                        dt_DateTimeOut = new DateTime()
                    };

                    if (!(reader.IsDBNull(reader.GetOrdinal("SignOutDate")) || reader.IsDBNull(reader.GetOrdinal("SignOutTime"))))
                        r.dt_DateTimeOut = GetDateTime(reader.GetString(6), reader.GetString(7));

                    listRecords.Add(r);
                }
            }

            myConnection.Close();

            return listRecords;
        }

        public List<Record> GetCurrentLoggedInPersonnel()
        {
            List<Record> currentLog = new List<Record>();

            // Testing connection to database
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            SqlCommand command = new SqlCommand("SELECT r.PK_RecordID, p.PeopleNric, p.PeopleName, " +
                                                "r.Reason, si.SignInDate, si.SignInTime, so.SignOutDate, so.SignOutTime " +
                                                "FROM RECORDS as r INNER JOIN PEOPLE as p on r.FK_PeopleID = p.PK_PeopleID " +
                                                "INNER JOIN SignIn as si on r.FK_SignInID = si.PK_SignInID " +
                                                "LEFT JOIN SignOut as so on r.FK_SignOutID = so.PK_SignOutID " +
                                                "WHERE so.SignOutDate IS NULL;", myConnection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                // Fill list of records
                while (reader.Read())
                {
                    // Initialize Record
                    Record r = new Record
                    {
                        i_Id = reader.GetInt32(reader.GetOrdinal("PK_RecordID")),
                        s_Nric = reader.GetString(reader.GetOrdinal("PeopleNric")),
                        s_Name = reader.GetString(reader.GetOrdinal("PeopleName")),
                        s_Reason = reader.GetString(reader.GetOrdinal("Reason")),
                        dt_DateTimeIn = GetDateTime(reader.GetString(reader.GetOrdinal("SignInDate")), reader.GetString(reader.GetOrdinal("SignInTime"))),
                        dt_DateTimeOut = new DateTime()
                    };

                    //if (!(reader.IsDBNull(reader.GetOrdinal("SignOutDate")) || reader.IsDBNull(reader.GetOrdinal("SignOutTime"))))
                    //    r.dt_DateTimeOut = GetDateTime(reader.GetString(6), reader.GetString(7));

                    currentLog.Add(r);
                }
            }

            myConnection.Close();

            return currentLog;
        }

        DateTime GetDateTime(string date, string time)
        {
            DateTime dt = new DateTime();

            // Check for null in date and time
            if (!(String.IsNullOrEmpty(date) || String.IsNullOrEmpty(time)))
            {
                string[] dateSplit = date.Split('/');
                int day = int.Parse(dateSplit[0]);
                int month = int.Parse(dateSplit[1]);
                int year = int.Parse(dateSplit[2]);

                string[] timeSplit = time.Split(':');
                int hour = int.Parse(timeSplit[0]);
                int minute = int.Parse(timeSplit[1]);
                int second = int.Parse(timeSplit[2]);

                dt = new DateTime(year, month, day, hour, minute, second);
                Console.WriteLine(dt.ToString("dd/MM/yyyy HH:mm:ss"));
            }

            return dt;
        }
    }
}
