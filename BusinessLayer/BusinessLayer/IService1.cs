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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        bool DeleteAirport(string Original_Code3, string usr, string pass);
        [OperationContract]
        DataSet GetComboAirport();
        [OperationContract]
        DataSet GetGridAirport(string usr, string pass);
        [OperationContract]
        bool UpdateAirport(string Code3, string Code4, int CiryID, string Pers_Name, string Eng_Name, short TypeID, string Original_Code3, string usr, string pass);
        [OperationContract]
        bool InsertAirport(string Code3, string Code4, int CiryID, string Pers_Name, string Eng_Name, short TypeID, string usr, string pass);
        
        [OperationContract]
        bool DeleteAirport_Types(short Original_ID, string usr, string pass);
        [OperationContract]
        DataSet GetComboAirport_types();
        [OperationContract]
        bool UpdateAirport_Types(string Name, short Original_ID, string usr, string pass);
        [OperationContract]
        bool InsertAirport_Types(string Name, string usr, string pass);
        [OperationContract]
        bool DeleteCity(int Original_ID, string usr, string pass);
        [OperationContract]
        DataSet GetComboCity();
        [OperationContract]
        bool UpdateCity(string Name, int CountryID, int Original_ID, string usr, string pass);
        [OperationContract]
        bool InsertCity(string Name, int CountryID, string usr, string pass);
        [OperationContract]
        bool DeleteCounty(int Original_ID, string usr, string pass);
        [OperationContract]
        DataSet GetComboCountry();
        [OperationContract]
        bool UpdateCountry(string Name, int Original_ID, string usr, string pass);
        [OperationContract]
        bool InsertCountry(string Name, string usr, string pass);
        [OperationContract]
        bool DeleteAirline(string Original_code3, string usr, string pass);
        [OperationContract]
        DataSet GetComboAirline();
        [OperationContract]
        DataSet GetGridAirline( string usr, string pass);
        [OperationContract]
        bool UpdateAirline(string code3, string Code4, string Eng_Name, string Pers_Name, short Type, int Country, string Original_code3, string usr, string pass);
        [OperationContract]
        bool InsertAirline(string code3, string Code4, string Eng_Name, string Pers_Name, short Type, int Country, string usr, string pass);
        [OperationContract]
        bool DeleteAirline_types(short Original_ID, string usr, string pass);
        [OperationContract]
        DataSet GetComboAirline_types();
        [OperationContract]
        bool UpdateAirline_types(string Name, short Original_ID, string usr, string pass);
        [OperationContract]
        bool InsertAirline_types(string Name, string usr, string pass);
        [OperationContract]
        bool DeleteRoutes(int Original_ID, string usr, string pass);
        [OperationContract]
        DataSet GetComboRoutes(string begining, string destination);
        [OperationContract]
        DataSet GetGridRoutes( string usr, string pass);
        [OperationContract]
        bool UpdateRoutes(string name, int Distance, string Beginning_Airport, string Destination_Airport, int Original_ID, string usr, string pass);
        [OperationContract]
        bool InsertRoutes(string name, int Distance, string Beginning_Airport, string Destination_Airport, string usr, string pass);
        [OperationContract]
        bool DeleteAirplane(string Original_Register, string usr, string pass);
        [OperationContract]
        DataSet GetComboAirplane();
        [OperationContract]
        DataSet GetGridAirplane( string usr, string pass);
        [OperationContract]
        string GetAirplaneOwner(string Register);
        [OperationContract]
        bool UpdateAirplane(string Register, int Serial, string Made_Date, int Model, short Usage_Type, string Owner, string Original_Register, string usr, string pass);
        [OperationContract]
        bool InsertAirplane(string Register, int Serial, System.DateTime Made_Date, int Model, short Usage_Type, string Owner, string usr, string pass);
        [OperationContract]
        bool DeleteAirplane_Model(int Original_ID, string usr, string pass);
        [OperationContract]
        DataSet GetComboAirplane_Model();
        [OperationContract]
        DataSet GetGridAirplane_Model( string usr, string pass);
        [OperationContract]
        bool UpdateAirplane_Model(string Name, short Capacity, int MTOW, int Weight, int Original_ID, string usr, string pass);
        [OperationContract]
        bool InsertAirplane_Model(string Name, short Capacity, int MTOW, int Weight, string usr, string pass);
        [OperationContract]
        bool DeleteAirplane_Usage(short Original_ID, string usr, string pass);
        [OperationContract]
        DataSet GetComboAirplane_Usage();
        [OperationContract]
        bool UpdateAirplane_Usage(string Name, short Original_ID, string usr, string pass);
        [OperationContract]
        bool InsertAirplane_Usage(string Name, string usr, string pass);

        [OperationContract]
        bool DeleteDelay_Type(short Original_ID, string usr, string pass);
        [OperationContract]
        DataSet GetComboDelay_Type();
        [OperationContract]
        bool UpdateDelay_Type(string Name, short Original_ID, string usr, string pass);
        [OperationContract]
        bool InsertDelay_Type(string Name, string usr, string pass);

       /* [OperationContract]
        bool DeleteDelay_Cause(int Original_ID);*/
        [OperationContract]
        DataSet GetGridDelay_Cause(int flightID);
        [OperationContract]
        bool UpdateDelay_Cause(short type, string Description, int Original_ID, string usr, string pass);
        [OperationContract]
        bool InsertDelay_Cause(short type, int FlightID, string Description, string usr, string pass);

        [OperationContract]
        bool DeleteUser(int Original_ID, string usr, string pass);
        [OperationContract]
        DataSet GetGridUser(string usr, string pass);
        [OperationContract]
        string GetUserAirport(string username, string password);
        [OperationContract]
        bool UpdateUser(string username, string password, int phone, string fname, string lname, short type, string airport, int Original_ID, string usr, string pass);
        [OperationContract]
        bool InsertUser(string username, string password, int phone, string fname, string lname, short type, string airport, string usr, string pass);

        [OperationContract]
        bool DeleteUser_Type(short Original_ID, string usr, string pass);
        [OperationContract]
        DataSet GetComboUser_Type();
        [OperationContract]
        bool UpdateUser_Type(string name, short Original_ID, string usr, string pass);
        [OperationContract]
        bool InsertUser_Type(string name, string usr, string pass);

        [OperationContract]
        bool DeleteFlight(int Original_ID, string usr, string pass);
        [OperationContract]
        DataSet GetGridAllFlight( string usr, string pass);
        [OperationContract]
        DataSet GetGridPassengerFlight( string usr, string pass);
        [OperationContract]
        DataSet GetGridCargoFlight(string usr, string pass);
        [OperationContract]
        bool UpdateFlight(int FID, DateTime schDTFlight, string DTFlight, int Load, int FuelVolume, bool isScheduled, bool isLocal, bool isCharter
            , string Airplane, string Beneficiary, int Route, bool Telescope, int infants, int childs, int adults, int Original_ID, string usr, string pass);
        [OperationContract]
        bool InsertFlight(int FID, DateTime schDTFlight,string DTFlight, int Load, int FuelVolume, bool isScheduled, bool isLocal, bool isCharter
            , string Airplane, string Beneficiary, int Route, string username, string password, bool Telescope, int infants, int childs, int adults);

        [OperationContract]
        bool[] Login(string username, string password);

        [OperationContract]
        DataSet GetAllComponents();
        [OperationContract]
        bool[] GetAccessForms(short type);
        [OperationContract]
        bool[] GetAccessComponents(short type);
        [OperationContract]
        bool UpdateAccessForms(short[] forms, short type, string usr, string pass);
        [OperationContract]
        bool UpdateAccessComponents(int[] components, short type, string usr, string pass);
        
    }
}
