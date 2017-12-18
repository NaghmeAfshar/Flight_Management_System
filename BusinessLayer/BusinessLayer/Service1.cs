using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using BusinessLayer.Flights_ManagementDataSetTableAdapters;

namespace BusinessLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

       const int numberOfComponents = 50;
       const int numberOfForms = 15;

        public bool DeleteAirport(string Original_Code3,string usr, string pass)
        {
            if(authenticate(usr,pass,34)==false)return false;
            try
            {
                AirportTableAdapter u = new AirportTableAdapter();
                u.DeleteQuery(Original_Code3);
            }
            catch (Exception e) { return false; }
            return true;

        }


        public DataSet GetComboAirport()
        {

            GetComboAirportsTableAdapter a = new GetComboAirportsTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetData());
            return ds;

        }
        public DataSet GetGridAirport(string usr,string pass)
        {
            if (authenticate(usr, pass, 37) == false) return null;
            GetGridAirportTableAdapter a = new GetGridAirportTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetData());
            return ds;

        }
        public bool UpdateAirport(string Code3, string Code4, int CiryID, string Pers_Name, string Eng_Name, short TypeID, string Original_Code3, string usr, string pass)
        {
            if (authenticate(usr, pass, 36) == false) return false;
            try
            {
                AirportTableAdapter u = new AirportTableAdapter();
                u.UpdateQuery(Code3, Code4, CiryID, Pers_Name, Eng_Name, TypeID, Original_Code3);
            }
            catch (Exception e) { return false; }
            return true;

        }
        public bool InsertAirport(string Code3, string Code4, int CiryID, string Pers_Name, string Eng_Name, short TypeID,string usr,string pass)
        {
            if (authenticate(usr, pass, 35) == false) return false;
            try
            {
                AirportTableAdapter u = new AirportTableAdapter();
                u.Insert(Code3, Code4, CiryID, Pers_Name, Eng_Name, TypeID);
            }
            catch (Exception e) { return false; }
            return true;

        }
        public bool DeleteAirport_Types(short Original_ID,string usr, string pass)
        {
            if (authenticate(usr, pass, 15) == false) return false;
            try
            {
                Airport_TypesTableAdapter u = new Airport_TypesTableAdapter();
                u.DeleteQuery(Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public DataSet GetComboAirport_types()
        {

            Airport_TypesTableAdapter a = new Airport_TypesTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetCombo());
            return ds;

        }
        public bool UpdateAirport_Types(string Name, short Original_ID, string usr, string pass)
        {
            if (authenticate(usr, pass, 17) == false) return false;
            try
            {
                Airport_TypesTableAdapter u = new Airport_TypesTableAdapter();
                u.UpdateQuery(Name, Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public bool InsertAirport_Types(string Name, string usr, string pass)
        {
            if (authenticate(usr, pass, 16) == false) return false;
            try
            {
                Airport_TypesTableAdapter u = new Airport_TypesTableAdapter();
                u.Insert(Name);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public bool DeleteCity(int Original_ID, string usr, string pass)
        {
            if (authenticate(usr, pass, 21) == false) return false;
            try
            {
                CityTableAdapter u = new CityTableAdapter();
                u.DeleteQuery(Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public DataSet GetComboCity()
        {

            CityTableAdapter a = new CityTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetData());
            return ds;

        }
        public bool UpdateCity(string Name, int CountryID, int Original_ID, string usr, string pass)
        {
            if (authenticate(usr, pass, 23) == false) return false;
            try
            {
                CityTableAdapter u = new CityTableAdapter();
                u.UpdateQuery(Name, CountryID, Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public bool InsertCity(string Name, int CountryID, string usr, string pass)
        {
            if (authenticate(usr, pass, 22) == false) return false;
            try
            {
                CityTableAdapter u = new CityTableAdapter();
                u.Insert(Name, CountryID);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public bool DeleteCounty(int Original_ID, string usr, string pass)
        {
            if (authenticate(usr, pass, 24) == false) return false;
            try
            {
                CountryTableAdapter u = new CountryTableAdapter();
                u.DeleteQuery(Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public DataSet GetComboCountry()
        {

            CountryTableAdapter a = new CountryTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetCombo());
            return ds;

        }
        public bool UpdateCountry(string Name, int Original_ID, string usr, string pass)
        {
            if (authenticate(usr, pass, 26) == false) return false;
            try
            {
                CountryTableAdapter u = new CountryTableAdapter();
                u.UpdateQuery(Name, Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public bool InsertCountry(string Name,string usr, string pass)
        {
            if (authenticate(usr, pass, 25) == false) return false;
            try
            {
                CountryTableAdapter u = new CountryTableAdapter();
                u.Insert(Name);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public bool DeleteAirline(string Original_code3,string usr, string pass)
        {
            if (authenticate(usr, pass, 38) == false) return false;
            try
            {
                AirlineTableAdapter u = new AirlineTableAdapter();
                u.DeleteQuery(Original_code3);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public DataSet GetComboAirline()
        {

            GetComboAirlinesTableAdapter a = new GetComboAirlinesTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetData());
            return ds;

        }
        public DataSet GetGridAirline(string usr, string pass)
        {
            if (authenticate(usr, pass, 41) == false) return null;

            GetGridAirlineTableAdapter a = new GetGridAirlineTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetData());
            return ds;

        }
        public bool UpdateAirline(string code3, string Code4, string Eng_Name, string Pers_Name, short Type, int Country, string Original_code3, string usr, string pass)
        {
            if (authenticate(usr, pass, 40) == false) return false;
            try
            {
                AirlineTableAdapter u = new AirlineTableAdapter();
                u.UpdateQuery(code3, Code4, Eng_Name, Pers_Name, Type, Country, Original_code3);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public bool InsertAirline(string code3, string Code4, string Eng_Name, string Pers_Name, short Type, int Country, string usr, string pass)
        {
            if (authenticate(usr, pass, 39) == false) return false;
            try
            {
                AirlineTableAdapter u = new AirlineTableAdapter();
                u.Insert(code3, Code4, Eng_Name, Pers_Name, Type, Country);
            }
            catch (Exception e) { return false; }
            return true;
        }

        public bool DeleteAirline_types(short Original_ID, string usr, string pass)
        {
            if (authenticate(usr, pass, 12) == false) return false;
            try
            {
                Airline_typesTableAdapter u = new Airline_typesTableAdapter();
                u.DeleteQuery(Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public DataSet GetComboAirline_types()
        {

            Airline_typesTableAdapter a = new Airline_typesTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetCombo());
            return ds;

        }
        public bool UpdateAirline_types(string Name, short Original_ID, string usr, string pass)
        {
            if (authenticate(usr, pass, 14) == false) return false;
            try
            {
                Airline_typesTableAdapter u = new Airline_typesTableAdapter();
                u.UpdateQuery(Name, Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public bool InsertAirline_types(string Name, string usr, string pass)
        {
            if (authenticate(usr, pass, 13) == false) return false;
            try
            {
                Airline_typesTableAdapter u = new Airline_typesTableAdapter();
                u.Insert(Name);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public bool DeleteRoutes(int Original_ID, string usr, string pass)
        {
            if (authenticate(usr, pass, 46) == false) return false;
            try
            {
                RoutesTableAdapter u = new RoutesTableAdapter();
                u.DeleteQuery(Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public DataSet GetComboRoutes(string begining,string destination)
        {

            GetComboRoutesTableAdapter a = new GetComboRoutesTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetData(begining,destination));
            return ds;

        }
        public DataSet GetGridRoutes(string usr, string pass)
        {
            if (authenticate(usr, pass, 49) == false) return null;

            GetGridRouteTableAdapter a = new GetGridRouteTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetData());
            return ds;

        }
        public bool UpdateRoutes(string name,int Distance, string Beginning_Airport, string Destination_Airport, int Original_ID,string usr, string pass)
        {
            if (authenticate(usr, pass, 48) == false) return false;
            try
            {
                RoutesTableAdapter u = new RoutesTableAdapter();
                u.UpdateQuery(Distance, Beginning_Airport, Destination_Airport,name, Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public bool InsertRoutes(string name, int Distance,string Beginning_Airport, string Destination_Airport,string usr, string pass)
        {
            if (authenticate(usr, pass, 47) == false) return false;
            try
            {
                RoutesTableAdapter u = new RoutesTableAdapter();
                u.Insert(Distance, Beginning_Airport, Destination_Airport, name);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public bool DeleteAirplane(string Original_Register,string usr, string pass)
        {
            if (authenticate(usr, pass, 4) == false) return false;
            try
            {
                AirplaneTableAdapter u = new AirplaneTableAdapter();
                u.DeleteQuery(Original_Register);
            }
            catch (Exception e) { return false; }
            return true;
        }

        public DataSet GetComboAirplane()
        {

            GetComboAirplaneTableAdapter a = new GetComboAirplaneTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetData());
            return ds;

        }
        public DataSet GetGridAirplane(string usr, string pass)
        {
            if (authenticate(usr, pass, 7) == false) return null;

            GetGridAirplaneTableAdapter a = new GetGridAirplaneTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetData());
            return ds;

        }
        public bool UpdateAirplane(string Register, int Serial,string Made_Date, int Model, short Usage_Type, string Owner, string Original_Register,string usr, string pass)
        {
            if (authenticate(usr, pass, 6) == false) return false;
            try
            {
                AirplaneTableAdapter u = new AirplaneTableAdapter();
                u.UpdateQuery(Register, Serial, Made_Date, Model, Usage_Type, Owner, Original_Register);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public bool InsertAirplane(string Register, int Serial, System.DateTime Made_Date, int Model, short Usage_Type, string Owner,string usr, string pass)
        {
            if (authenticate(usr, pass, 5) == false) return false;
            try
            {
                AirplaneTableAdapter u = new AirplaneTableAdapter();
                u.Insert(Register, Serial, Made_Date, Model, Usage_Type, Owner);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public bool DeleteAirplane_Model(int Original_ID,string usr, string pass)
        {
            if (authenticate(usr, pass, 42) == false) return false;
            try
            {
                Airplane_ModelTableAdapter u = new Airplane_ModelTableAdapter();
                u.DeleteQuery(Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }

        public DataSet GetComboAirplane_Model()
        {

            GetComboAirplaneModelTableAdapter a = new GetComboAirplaneModelTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetData());
            return ds;

        }

        public DataSet GetGridAirplane_Model(string usr, string pass)
        {
            if (authenticate(usr, pass, 45) == false) return null;

            GetGridAirplane_ModelTableAdapter a = new GetGridAirplane_ModelTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetData());
            return ds;

        }

        public bool UpdateAirplane_Model(string Name, short Capacity, int MTOW, int Weight, int Original_ID,string usr, string pass)
        {
            if (authenticate(usr, pass, 44) == false) return false;
            try
            {
                Airplane_ModelTableAdapter u = new Airplane_ModelTableAdapter();
                u.UpdateQuery(Name, Capacity, MTOW, Weight, Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public bool InsertAirplane_Model(string Name, short Capacity, int MTOW, int Weight,string usr, string pass)
        {
            if (authenticate(usr, pass, 43) == false) return false;
            try
            {
                Airplane_ModelTableAdapter u = new Airplane_ModelTableAdapter();
                u.Insert(Name, Capacity, MTOW, Weight);
            }
            catch (Exception e) { return false; }
            return true;
        }

        public bool DeleteAirplane_Usage(short Original_ID,string usr, string pass)
        {
            if (authenticate(usr, pass, 9) == false) return false;
            try
            {
                Airplane_UsageTableAdapter u = new Airplane_UsageTableAdapter();
                u.DeleteQuery(Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public DataSet GetComboAirplane_Usage()
        {

            Airplane_UsageTableAdapter a = new Airplane_UsageTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetCombo());
            return ds;

        }
        public bool UpdateAirplane_Usage(string Name, short Original_ID,string usr, string pass)
        {
            if (authenticate(usr, pass, 11) == false) return false;
            try
            {
                Airplane_UsageTableAdapter u = new Airplane_UsageTableAdapter();
                u.UpdateQuery(Name, Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }
        public bool InsertAirplane_Usage(string Name,string usr, string pass)
        {
            if (authenticate(usr, pass, 10) == false) return false;
            try
            {
                Airplane_UsageTableAdapter u = new Airplane_UsageTableAdapter();
                u.Insert(Name);
            }
            catch (Exception e) { return false; }
            return true;
        }


        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="Original_ID"></param>
        /// <returns></returns>
        public bool DeleteDelay_Type(short Original_ID,string usr, string pass)
        {
            if (authenticate(usr, pass, 18) == false) return false;
            try
            {
                Delay_TypesTableAdapter u = new Delay_TypesTableAdapter();
                u.DeleteQuery(Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }

        public DataSet GetComboDelay_Type()
        {
            Delay_TypesTableAdapter a = new Delay_TypesTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetCombo());
            return ds;
        }

        public bool UpdateDelay_Type(string Name, short Original_ID,string usr, string pass)
        {
            if (authenticate(usr, pass, 20) == false) return false;
            try
            {
                Delay_TypesTableAdapter u = new Delay_TypesTableAdapter();
                u.UpdateQuery(Name, Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }

        public bool InsertDelay_Type(string Name,string usr, string pass)
        {
            if (authenticate(usr, pass, 19) == false) return false;
            try
            {
                Delay_TypesTableAdapter u = new Delay_TypesTableAdapter();
                u.Insert(Name);
            }
            catch (Exception e) { return false; }
            return true;
        }

      /*  public bool DeleteDelay_Cause(short Original_ID)
        {
            try
            {
                Delay_CauseTableAdapter u = new Delay_CauseTableAdapter();
                u.DeleteQuery(Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }*/

        public DataSet GetGridDelay_Cause(int flightID)
        {
            GetGridDelay_CauseTableAdapter a = new GetGridDelay_CauseTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetData(flightID));
            return ds;
        }

        public bool UpdateDelay_Cause(short type, string Description, int Original_ID,string usr, string pass)
        {
            if (authenticate(usr, pass, 34) == false) return false;
            try
            {
                Delay_CauseTableAdapter u = new Delay_CauseTableAdapter();
                u.UpdateQuery(Description,type,Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }

        public bool InsertDelay_Cause(short type,int FlightID, string Description,string usr, string pass)
        {
            if (authenticate(usr, pass, 34) == false) return false;
            try
            {
                Delay_CauseTableAdapter u = new Delay_CauseTableAdapter();
                u.Insert(Description,FlightID,type);
            }
            catch (Exception e) { return false; }
            return true;
        }

        public bool DeleteUser(int Original_ID,string usr, string pass)
        {
            if (authenticate(usr, pass, 27) == false) return false;
            try
            {
                UsersTableAdapter u = new UsersTableAdapter();
                u.DeleteQuery(Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }

        public DataSet GetGridUser(string usr, string pass)
        {
            if (authenticate(usr, pass, 30) == false) return null;
            ShowUsersTableAdapter a = new ShowUsersTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetData());
            return ds;
        }

        public bool UpdateUser(string username, string password, int phone, string fname, string lname, short type, string airport, int Original_ID,string usr, string pass)
        {
            if (authenticate(usr, pass, 29) == false) return false;
            try
            {
                UsersTableAdapter u = new UsersTableAdapter();
                u.UpdateQuery(username,password,phone,fname,lname,type,airport,Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }

        public bool InsertUser(string username, string password, int phone, string fname, string lname, short type, string airport,string usr, string pass)
        {
            if (authenticate(usr, pass, 28) == false) return false;
            try
            {
                UsersTableAdapter u = new UsersTableAdapter();
                u.Insert(username, password, phone, fname, lname, type, airport);
            }
            catch (Exception e) { return false; }
            return true;
        }

        public bool DeleteUser_Type(short Original_ID,string usr, string pass)
        {
            if (authenticate(usr, pass, 31) == false) return false;
            try
            {
                User_TypesTableAdapter u = new User_TypesTableAdapter();
                u.DeleteQuery(Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }

        public DataSet GetComboUser_Type()
        {
            User_TypesTableAdapter a = new User_TypesTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetCombo());
            return ds;
        }

        public bool UpdateUser_Type(string name, short Original_ID,string usr, string pass)
        {
            if (authenticate(usr, pass, 33) == false) return false;
            try
            {
                User_TypesTableAdapter u = new User_TypesTableAdapter();
                u.UpdateQuery(name, Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }

        public bool InsertUser_Type(string name,string usr, string pass)
        {
            if (authenticate(usr, pass, 32) == false) return false;
            try
            {
                User_TypesTableAdapter u = new User_TypesTableAdapter();
                u.Insert(name);

            }
            catch (Exception e) { return false; }
            return true;
        }

        public bool DeleteFlight(int Original_ID,string usr, string pass)
        {
            if (authenticate(usr, pass, 1) == false) return false;
            try
            {
                FlightTableAdapter u = new FlightTableAdapter();
                u.DeleteQuery(Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }

        public DataSet GetGridAllFlight(string usr, string pass)
        {
            if (authenticate(usr, pass, 3) == false) return null;
            GetAllFlightsTableAdapter a = new GetAllFlightsTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetData());
            return ds;
        }

        public DataSet GetGridPassengerFlight(string usr, string pass)
        {
            if (authenticate(usr, pass, 3) == false) return null;
            GetPassengerFlightsTableAdapter a = new GetPassengerFlightsTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetData());
            return ds;
        }

        public DataSet GetGridCargoFlight(string usr, string pass)
        {
            if (authenticate(usr, pass, 3) == false) return null;
            GetCargoFlightsTableAdapter a = new GetCargoFlightsTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(a.GetData());
            return ds;
        }

        public bool UpdateFlight(int FID, DateTime schDTFlight, string DTFlight, int Load, int FuelVolume, bool isScheduled, bool isLocal, bool isCharter, string Airplane, string Beneficiary, int Route, bool Telescope, int infants, int childs, int adults, int Original_ID,string usr, string pass)
        {
            if (authenticate(usr, pass, 2) == false) return false;
            try
            {
                FlightTableAdapter u = new FlightTableAdapter();
                if (DTFlight == null || DTFlight.Length == 0)
                u.UpdateQuery(Load, FuelVolume, FID, schDTFlight,null, isScheduled, isCharter, isLocal, Airplane, Beneficiary, Route, infants, childs, adults, Telescope, Original_ID);
            else
                    u.UpdateQuery(Load, FuelVolume, FID, schDTFlight, Convert.ToDateTime( DTFlight), isScheduled, isCharter, isLocal, Airplane, Beneficiary, Route, infants, childs, adults, Telescope, Original_ID);
            }
            catch (Exception e) { return false; }
            return true;
        }

        public bool InsertFlight(int FID, DateTime schDTFlight, string DTFlight, int Load, int FuelVolume, bool isScheduled, bool isLocal, bool isCharter, string Airplane, string Beneficiary, int Route, string username, string password, bool Telescope, int infants, int childs, int adults)
        {
            if (authenticate(username, password, 0) == false) return false;
            
               DateTime dtflight;
               
                GetIDTableAdapter u = new GetIDTableAdapter();
                
               int userID=(int) u.GetData(username,password).Rows[0].ItemArray[0];
              
                FlightTableAdapter f = new FlightTableAdapter();
                if (DTFlight == null || DTFlight.Length == 0)
                f.InsertQuery(Load, FuelVolume, FID, schDTFlight,null, isScheduled, isCharter, isLocal, Airplane, Beneficiary, Route,userID, Telescope, infants, childs, adults);
                else
                f.InsertQuery(Load, FuelVolume, FID, schDTFlight,Convert.ToDateTime( DTFlight), isScheduled, isCharter, isLocal, Airplane, Beneficiary, Route, userID, Telescope, infants, childs, adults);
            return true;
        }

        public bool[] Login(string username, string password)
        {
            
            bool[] result = new bool[numberOfComponents+numberOfForms+1]; //+1 for مدیریت سیستم
            UserLoginFormTableAdapter u = new UserLoginFormTableAdapter();
            DataTable forms=u.GetData(username,password);
            if (forms.Rows.Count == 0) return null;
            UserLoginComponentTableAdapter u2 = new UserLoginComponentTableAdapter();
            DataTable components = u2.GetData(username, password);
            
            
            for (int i = 0; i < components.Rows.Count;i++ )
            {
                result[(int)components.Rows[i].ItemArray[0]] = true;

            }
            for (int i = 0; i < forms.Rows.Count; i++)
            {
                result[numberOfComponents+(short)forms.Rows[i].ItemArray[0]] = true;

            }
            result[65] = result[53] || result[54] || result[55] || result[56] || result[57] || result[58];
                return result;
        }


        public string GetAirplaneOwner(string Register)
        {
            GetAirplaneOwnerTableAdapter u = new GetAirplaneOwnerTableAdapter();
            return (string)u.GetData(Register).Rows[0].ItemArray[0];
        }


        public string GetUserAirport(string username, string password)
        {
            GetAirportWorkPlaceTableAdapter u = new GetAirportWorkPlaceTableAdapter();
            return (string)u.GetData(username,password).Rows[0].ItemArray[0];
        }





        public DataSet GetAllComponents()
        {
            
            AllUIComponentsTableAdapter u = new AllUIComponentsTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(u.GetData());
            return ds;
        }


        public bool[] GetAccessForms(short type)
        {
            GetAccessFormTableAdapter u = new GetAccessFormTableAdapter();
            DataTable forms = u.GetData(type);
            bool[] result = new bool[numberOfForms];
            try{
                for (int i = 0; i < forms.Rows.Count; i++)
            {
                result[(short)forms.Rows[i].ItemArray[0]] = true;

            }}catch(IndexOutOfRangeException e){}
            return result;
        }

        public bool[] GetAccessComponents(short type)
        {
            GetAccessComponentsTableAdapter u = new GetAccessComponentsTableAdapter();
            DataTable components = u.GetData(type);
            bool[] result = new bool[numberOfComponents];
            try
            {
                for (int i = 0; i < components.Rows.Count; i++)
                {
                    result[(int)components.Rows[i].ItemArray[0]] = true;

                }
            }
            catch (IndexOutOfRangeException e) { }
            return result;
        }


        public bool UpdateAccessForms(short[] forms, short type,string usr, string pass)
        {
            if (authenticate(usr, pass, 33) == false) return false;
            try
            {
                AccessFormTableAdapter u = new AccessFormTableAdapter();
                u.DeleteQuery(type);
                for (int i = 0; i < forms.Length; i++)
                    u.Insert(forms[i],type);
            }
            catch (Exception e) { return false; }
            
            return true;
        }

        public bool UpdateAccessComponents(int[] components, short type,string usr, string pass)
        {
            if (authenticate(usr, pass, 33) == false) return false;
            try
            {
                AccessComponentTableAdapter u = new AccessComponentTableAdapter();
                u.DeleteQuery(type);
                for (int i = 0; i < components.Length; i++)
                    u.Insert(type, components[i]);
            }
            catch (Exception e) { return false; }
            return true;
        }
        private bool authenticate(string usr,string pass, int id)
        {
            AuthenticateTableAdapter u = new AuthenticateTableAdapter();
           int k=(int) u.GetData(id, usr, pass).Rows[0].ItemArray[0];
           return (k == 1);
        }


    }
}
