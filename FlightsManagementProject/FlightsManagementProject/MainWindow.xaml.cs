using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Data;
using System.ComponentModel;
namespace FlightsManagementProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        bool flightTabSelected = false;
        private string workPlaceAirport;
        private ServicesReferences.Service1Client Service;
        private string username;
        private string password;
        private bool newFlight=false;
        private int numberofForms = 15;
        private int numberofComponents = 50;
        public bool[] Access
        {
            get;
            set;
        }
        private node[] _treeNodes;
        public node[] TreeNodes
        {
            get { return _treeNodes; }
            set { _treeNodes = value;
            NotifyPropertyChanged("TreeNodes");
            }
        }
        public class node
        {
            public node(node[] child,bool isCheck,string t)
            {
                this.text = t;
                this.check = isCheck;
                this.childs = child;
            }
            public string text
            {
                get;
                set;
            }
            public node[] childs
            {
                get;
                set;
            }
            public bool check
            {
                get;
                set;

            }

            public event PropertyChangedEventHandler PropertyChanged;
        }
        
        public MainWindow(bool[] a,ServicesReferences.Service1Client s,string user,string passwd)
        {
            
            this.Access = a;
            Service = s;
            username = user;
            password = passwd;
            InitializeComponent();
            tabControl1.DataContext = this;
            workPlaceAirport = Service.GetUserAirport(user,password);
            
            InitComponents();
           
            

        }
        private void changeToTree(DataSet ds){
            TreeNodes=new node[numberofForms];
            int row = 0;
            for (short i = 0;ds.Tables[0].Rows.Count>row; i++)
            {
                List<node> childs = new List<node>();
             while (ds.Tables[0].Rows.Count > row&&(short)ds.Tables[0].Rows[row].ItemArray[0] == i )
             {
                    childs.Add(new node(null, false, (string)ds.Tables[0].Rows[row].ItemArray[3]));
                    row++;
                }
             TreeNodes[i] = new node(childs.ToArray<node>(), false, (string)ds.Tables[0].Rows[row-1].ItemArray[1]);
            }

        }
        private void InitComponents(){
            changeToTree(Service.GetAllComponents());
            AccessControl_UserTypeCombo.ItemsSource = Service.GetComboUser_Type().Tables[0].DefaultView;
            Routes_beginingCombo.ItemsSource = Service.GetComboAirport().Tables[0].DefaultView;
            Routes_DestinationCombo.ItemsSource = Routes_beginingCombo.ItemsSource;

            Flights_AirplaneCombo.ItemsSource = Service.GetComboAirplane().Tables[0].DefaultView;
            Flights_DestORBeginCombo.ItemsSource = Routes_beginingCombo.ItemsSource;

            Admin_AirlineTypeCombo.ItemsSource = Service.GetComboAirline_types().Tables[0].DefaultView;
            Admin_AirplaneUsageCombo.ItemsSource = Service.GetComboAirplane_Usage().Tables[0].DefaultView;
            Admin_AirportTypeCombo.ItemsSource = Service.GetComboAirport_types().Tables[0].DefaultView;
            Admin_CityCombo.ItemsSource = Service.GetComboCity().Tables[0].DefaultView;
            Admin_CountryCombo.ItemsSource = Service.GetComboCountry().Tables[0].DefaultView;
            Admin_DelayTypeCombo.ItemsSource = Service.GetComboDelay_Type().Tables[0].DefaultView;

            Airports_AirportTypeCombo.ItemsSource = Admin_AirportTypeCombo.ItemsSource;
            Airports_CityCombo.ItemsSource = Admin_CityCombo.ItemsSource;

            Users_airportCombo.ItemsSource = Service.GetComboAirport().Tables[0].DefaultView;
            Users_userTypeCombo.ItemsSource= Service.GetComboUser_Type().Tables[0].DefaultView;

            Airplanes_ModelCombo.ItemsSource = Service.GetComboAirplane_Model().Tables[0].DefaultView;
            Airplanes_UsageTypeCombo.ItemsSource = Admin_AirplaneUsageCombo.ItemsSource;
            Airplanes_ownerCombo.ItemsSource = Service.GetComboAirline().Tables[0].DefaultView;

            Airlines_CountryCombo.ItemsSource = Admin_CountryCombo.ItemsSource;
            Airlines_TypeCombo.ItemsSource = Admin_AirlineTypeCombo.ItemsSource;

            Routes_beginingCombo.ItemsSource = Users_airportCombo.ItemsSource;
            Routes_DestinationCombo.ItemsSource = Users_airportCombo.ItemsSource;

        }

        protected override void OnClosed(EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                if (tabControl1.SelectedItem == FlightsTab)
                    { WindowUtilties.AnimateWindowSize(this, 1000);
                    flightTabSelected = true;
                    }
                else if(flightTabSelected){ WindowUtilties.AnimateWindowSize(this, 775);
                    flightTabSelected=false;}

              
            }
        }

       

        private void Admin_AirplaneUsageCombo_DropDownOpened(object sender, EventArgs e)
        {
            Admin_AirplaneUsageCombo.ItemsSource=Service.GetComboAirplane_Usage().Tables[0].DefaultView;
        }

        private void Admin_AirlineTypeCombo_DropDownOpened(object sender, EventArgs e)
        {
            Admin_AirlineTypeCombo.ItemsSource=Service.GetComboAirline_types().Tables[0].DefaultView;
        }

        private void Admin_AirportTypeCombo_DropDownOpened(object sender, EventArgs e)
        {
            Admin_AirportTypeCombo.ItemsSource=Service.GetComboAirport_types().Tables[0].DefaultView;
        }

        private void Admin_DelayTypeCombo_DropDownOpened(object sender, EventArgs e)
        {
            Admin_DelayTypeCombo.ItemsSource = Service.GetComboDelay_Type().Tables[0].DefaultView;
        }

        private void Admin_CityCombo_DropDownOpened(object sender, EventArgs e)
        {

            Admin_CityCombo.ItemsSource = Service.GetComboCity().Tables[0].DefaultView;
        }

        private void Admin_CountryCombo_DropDownOpened(object sender, EventArgs e)
        {
            Admin_CountryCombo.ItemsSource = Service.GetComboCountry().Tables[0].DefaultView;
        }

        private void Users_Refresh_Click(object sender, RoutedEventArgs e)
        {
            Users_Grid.ItemsSource = Service.GetGridUser(username,password).Tables[0].DefaultView;
        }

        private void Airports_Refresh_Click(object sender, RoutedEventArgs e)
        {
            Airports_Grid.ItemsSource = Service.GetGridAirport(username,password).Tables[0].DefaultView;
        }

        private void Airlines_Refresh_Click(object sender, RoutedEventArgs e)
        {
            Airlines_Grid.ItemsSource = Service.GetGridAirline(username,password).Tables[0].DefaultView;
        }

        private void Airplanes_Refresh_Click(object sender, RoutedEventArgs e)
        {
            Airplanes_Grid.ItemsSource = Service.GetGridAirplane(username,password).Tables[0].DefaultView;
        }

        private void AirplaneModel_Refresh_Click(object sender, RoutedEventArgs e)
        {
            AirplaneModel_grid.ItemsSource = Service.GetGridAirplane_Model(username,password).Tables[0].DefaultView;
        }

        private void Routes_Refresh_Click(object sender, RoutedEventArgs e)
        {
            Routes_grid.ItemsSource = Service.GetGridRoutes(username,password).Tables[0].DefaultView;
        }

        private void Admin_AirplaneUsageAdd_Click(object sender, RoutedEventArgs e)
        {
            DialogBox d = new DialogBox();
            d.ShowDialog();
            if (d.okClick == false) return;
            Service.InsertAirplane_Usage(d.result, username, password);
        }

        private void Admin_AirplaneUsageDelete_Click(object sender, RoutedEventArgs e)
        {
            ConfirmBox confirm = new ConfirmBox();
            confirm.ShowDialog();
            if (confirm.okClick == false) return;
            Service.DeleteAirplane_Usage((short)Admin_AirplaneUsageCombo.SelectedValue, username, password);
            Admin_AirplaneUsageCombo.ItemsSource = Service.GetComboAirplane_Usage().Tables[0].DefaultView;
        }

        private void Admin_DelayTypeDelete_Click(object sender, RoutedEventArgs e)
        {
            ConfirmBox confirm = new ConfirmBox();
            confirm.ShowDialog();
            if (confirm.okClick == false) return;
            Service.DeleteDelay_Type((short)Admin_DelayTypeCombo.SelectedValue, username, password);
            Admin_DelayTypeCombo.ItemsSource = Service.GetComboDelay_Type().Tables[0].DefaultView;
        }

        private void Admin_CityDelete_Click(object sender, RoutedEventArgs e)
        {
            ConfirmBox confirm = new ConfirmBox();
            confirm.ShowDialog();
            if (confirm.okClick == false) return;
            Service.DeleteCity((int)Admin_CityCombo.SelectedValue, username, password);
            Admin_CityCombo.ItemsSource = Service.GetComboCity().Tables[0].DefaultView;
        }

        private void Admin_CountryDelete_Click(object sender, RoutedEventArgs e)
        {
            ConfirmBox confirm = new ConfirmBox();
            confirm.ShowDialog();
            if (confirm.okClick == false) return;
            Service.DeleteCounty((int)Admin_CountryCombo.SelectedValue, username, password);
            Admin_CountryCombo.ItemsSource = Service.GetComboCountry().Tables[0].DefaultView;
        }

        private void Admin_AirportTypeDelete_Click(object sender, RoutedEventArgs e)
        {
            ConfirmBox confirm = new ConfirmBox();
            confirm.ShowDialog();
            if (confirm.okClick == false) return;
            Service.DeleteAirport_Types((short)Airports_AirportTypeCombo.SelectedValue, username, password);
            Admin_AirportTypeCombo.ItemsSource = Service.GetComboAirport_types().Tables[0].DefaultView;
        }

        private void Admin_AirlineTypeDelete_Click(object sender, RoutedEventArgs e)
        {
            ConfirmBox confirm = new ConfirmBox();
            confirm.ShowDialog();
            if (confirm.okClick == false) return;
            Service.DeleteAirline_types((short)Admin_AirlineTypeCombo.SelectedValue, username, password);
            Admin_AirlineTypeCombo.ItemsSource = Service.GetComboAirline_types().Tables[0].DefaultView;
        }

        private void Users_Delete_Click(object sender, RoutedEventArgs e)
        {
            ConfirmBox confirm = new ConfirmBox();
            confirm.ShowDialog();
            if (confirm.okClick == false) return;
            Service.DeleteUser((int)Users_Grid.SelectedValue, username, password);
            Users_Refresh_Click(sender, e);
        }

        private void Airports_Delete_Click(object sender, RoutedEventArgs e)
        {
            ConfirmBox confirm = new ConfirmBox();
            confirm.ShowDialog();
            if (confirm.okClick == false) return;
            Service.DeleteAirport((string)Airports_Grid.SelectedValue,username,password);
            Airports_Refresh_Click(sender, e);
        }

        private void Airlines_Delete_Click(object sender, RoutedEventArgs e)
        {
            ConfirmBox confirm = new ConfirmBox();
            confirm.ShowDialog();
            if (confirm.okClick == false) return;
            Service.DeleteAirline((string)Airlines_Grid.SelectedValue, username, password);
            Airlines_Refresh_Click(sender, e);
        }

        private void Airplanes_Delete_Click(object sender, RoutedEventArgs e)
        {
            ConfirmBox confirm = new ConfirmBox();
            confirm.ShowDialog();
            if (confirm.okClick == false) return;
            Service.DeleteAirplane((string)Airplanes_Grid.SelectedValue, username, password);
            Airplanes_Refresh_Click(sender, e);
        }

        private void AirplaneModel_delete_Click(object sender, RoutedEventArgs e)
        {
            ConfirmBox confirm = new ConfirmBox();
            confirm.ShowDialog();
            if (confirm.okClick == false) return;
            Service.DeleteAirplane_Model((int)AirplaneModel_grid.SelectedValue, username, password);
            AirplaneModel_Refresh_Click(sender, e);
        }

        private void Routes_delete_Click(object sender, RoutedEventArgs e)
        {
            ConfirmBox confirm = new ConfirmBox();
            confirm.ShowDialog();
            if (confirm.okClick == false) return;
            Service.DeleteRoutes((int)Routes_grid.SelectedValue, username, password);
            Routes_Refresh_Click(sender, e);
            
        }

        

        private void Airplanes_ModelCombo_DropDownOpened(object sender, EventArgs e)
        {
            Airplanes_ModelCombo.ItemsSource = Service.GetComboAirplane_Model().Tables[0].DefaultView;

        }

        private void Airplanes_ownerCombo_DropDownOpened(object sender, EventArgs e)
        {
            Airplanes_ownerCombo.ItemsSource = Service.GetComboAirline().Tables[0].DefaultView;
        }

        private void Users_userTypeCombo_DropDownOpened(object sender, EventArgs e)
        {
            Users_userTypeCombo.ItemsSource = Service.GetComboUser_Type().Tables[0].DefaultView;
        }

        private void Users_airportCombo_DropDownOpened(object sender, EventArgs e)
        {
            Users_airportCombo.ItemsSource = Service.GetComboAirport().Tables[0].DefaultView;
        }

        private void AccessControl_Delete_Click(object sender, RoutedEventArgs e)
        {
            ConfirmBox confirm = new ConfirmBox();
            confirm.ShowDialog();
            if (confirm.okClick == false) return;
            Service.DeleteUser_Type((short)AccessControl_UserTypeCombo.SelectedValue, username, password);
            AccessControl_UserTypeCombo.ItemsSource = Service.GetComboUser_Type().Tables[0].DefaultView;
            AccessControl_UserTypeCombo.SelectedIndex = 0;
        }

        private void Routes_Add_Click(object sender, RoutedEventArgs e)
        {
            Service.InsertRoutes(Routes_name.Text, Convert.ToInt32(Routes_distance.Text), (string)Routes_beginingCombo.SelectedValue, (string)Routes_DestinationCombo.SelectedValue, username, password);
            Routes_Refresh_Click(sender, e);
        }

        private void Routes_update_Click(object sender, RoutedEventArgs e)
        {
            Service.UpdateRoutes(Routes_name.Text, Convert.ToInt32(Routes_distance.Text), (string)Routes_beginingCombo.SelectedValue, (string)Routes_DestinationCombo.SelectedValue, Convert.ToInt32(Routes_grid.SelectedValue), username, password);
            Routes_Refresh_Click(sender, e);
        }

        private void Routes_beginingCombo_DropDownOpened(object sender, EventArgs e)
        {
            Routes_beginingCombo.ItemsSource = Service.GetComboAirport().Tables[0].DefaultView;
        }

        private void Routes_DestinationCombo_DropDownOpened(object sender, EventArgs e)
        {
            Routes_DestinationCombo.ItemsSource = Service.GetComboAirport().Tables[0].DefaultView;
        }

        private void Users_Add_Click(object sender, RoutedEventArgs e)
        {
            Service.InsertUser(Users_username.Text, Users_password.Text, Convert.ToInt32(Users_phone.Text), Users_fName.Text, Users_lname.Text, (short)(Users_userTypeCombo.SelectedValue), (string)(Users_airportCombo.SelectedValue), username, password);
            Users_Refresh_Click(sender, e);

        }

        private void Users_Update_Click(object sender, RoutedEventArgs e)
        {
            Service.UpdateUser(Users_username.Text, Users_password.Text, Convert.ToInt32(Users_phone.Text), Users_fName.Text, Users_lname.Text, (short)(Users_userTypeCombo.SelectedValue), (string)(Users_airportCombo.SelectedValue), Convert.ToInt32(Users_Grid.SelectedValue), username, password);
            Users_Refresh_Click(sender, e);
        }

        private void Airports_Add_Click(object sender, RoutedEventArgs e)
        {
            Service.InsertAirport(Airports_Code3.Text, Airports_Code4.Text, Convert.ToInt32(Airports_CityCombo.SelectedValue), Airports_Persname.Text, Airports_Engname.Text, (short)(Airports_AirportTypeCombo.SelectedValue), username, password);
            Airports_Refresh_Click(sender, e);

        }

        private void Airports_Update_Click(object sender, RoutedEventArgs e)
        {
            Service.UpdateAirport(Airports_Code3.Text, Airports_Code4.Text, Convert.ToInt32(Airports_CityCombo.SelectedValue), Airports_Persname.Text, Airports_Engname.Text, (short)(Airports_AirportTypeCombo.SelectedValue), (string)(Airports_Grid.SelectedValue), username, password);
            Airports_Refresh_Click(sender, e);
        }

        private void Airlines_Add_Click(object sender, RoutedEventArgs e)
        {
            Service.InsertAirline(Airlines_Cod3.Text, Airlines_Code4.Text, Airlines_Engname.Text, Airlines_Persname.Text, (short)(Airlines_TypeCombo.SelectedValue), Convert.ToInt32(Airlines_CountryCombo.SelectedValue), username, password);
            Airlines_Refresh_Click(sender, e);
        }

        private void Airlines_Update_Click(object sender, RoutedEventArgs e)
        {
            Service.UpdateAirline(Airlines_Cod3.Text, Airlines_Code4.Text, Airlines_Engname.Text, Airlines_Persname.Text, (short)(Airlines_TypeCombo.SelectedValue), Convert.ToInt32(Airlines_CountryCombo.SelectedValue), (string)(Airlines_Grid.SelectedValue), username, password);
            Airlines_Refresh_Click(sender, e);
        }

        private void Airplanes_Add_Click(object sender, RoutedEventArgs e)
        {
            Service.InsertAirplane(Airplanes_Register.Text, Convert.ToInt32(Airplanes_serial.Text), Convert.ToDateTime(Airplanes_madeDate.Text), Convert.ToInt32(Airplanes_ModelCombo.SelectedValue), (short)(Airplanes_UsageTypeCombo.SelectedValue), (string)(Airplanes_ownerCombo.SelectedValue), username, password);

            Airplanes_Refresh_Click(sender, e);
        
        }

        private void Airplanes_Update_Click(object sender, RoutedEventArgs e)
        {

            Service.UpdateAirplane(Airplanes_Register.Text, Convert.ToInt32(Airplanes_serial.Text), Airplanes_madeDate.Text, Convert.ToInt32(Airplanes_ModelCombo.SelectedValue), (short)(Airplanes_UsageTypeCombo.SelectedValue), (string)(Airplanes_ownerCombo.SelectedValue), (string)Airplanes_Grid.SelectedValue, username, password);
            
           
            Airplanes_Refresh_Click(sender, e);

        }

        private void AirplaneModel_add_Click(object sender, RoutedEventArgs e)
        {
            Service.InsertAirplane_Model(AirplaneModel_name.Text, Convert.ToInt16(AirplaneModel_capacity.Text), Convert.ToInt32(AirplaneModel_MTOW.Text), Convert.ToInt32(AirplaneModel_weight.Text), username, password);
            Routes_Refresh_Click(sender, e);
        
        }

        private void AirplaneModel_update_Click(object sender, RoutedEventArgs e)
        {
            Service.UpdateAirplane_Model(AirplaneModel_name.Text, Convert.ToInt16(AirplaneModel_capacity.Text), Convert.ToInt32(AirplaneModel_MTOW.Text), Convert.ToInt32(AirplaneModel_weight.Text), Convert.ToInt32(AirplaneModel_grid.SelectedValue), username, password);
            Routes_Refresh_Click(sender, e);
        }

        private void Admin_AirplaneUsageUpdate_Click(object sender, RoutedEventArgs e)
        {
            DialogBox d=new DialogBox();
            d.ShowDialog();
            if(d.okClick==false) return;
            Service.UpdateAirplane_Usage(d.result, (short)Admin_AirplaneUsageCombo.SelectedValue, username, password);
        }

        private void Admin_DelayTypeAdd_Click(object sender, RoutedEventArgs e)
        {
            DialogBox d = new DialogBox();
            d.ShowDialog();
            if (d.okClick == false) return;
            Service.InsertDelay_Type(d.result, username, password);
        }

        private void Admin_DelayTypeUpdate_Click(object sender, RoutedEventArgs e)
        {
            DialogBox d = new DialogBox();
            d.ShowDialog();
            if (d.okClick == false) return;
            Service.UpdateDelay_Type(d.result, (short)Admin_DelayTypeCombo.SelectedValue, username, password);
        }

        private void Admin_CityAdd_Click(object sender, RoutedEventArgs e)
        {
            DialogBoxCity d = new DialogBoxCity(Service,1);
            d.ShowDialog();
            if (d.okClick == false) return;
            Service.InsertCity(d.result, d.selectedCountry, username, password);
        }

        private void Admin_CountryAdd_Click(object sender, RoutedEventArgs e)
        {
            DialogBox d = new DialogBox();
            d.ShowDialog();
            if (d.okClick == false) return;
            Service.InsertCountry(d.result, username, password);
        }

        private void Admin_CountryUpdate_Click(object sender, RoutedEventArgs e)
        {
            DialogBox d = new DialogBox();
            d.ShowDialog();
            if (d.okClick == false) return;
            Service.UpdateCountry(d.result, (int)Admin_CountryCombo.SelectedValue, username, password);
        }

        private void Admin_AirportTypeAdd_Click(object sender, RoutedEventArgs e)
        {
            DialogBox d = new DialogBox();
            d.ShowDialog();
            if (d.okClick == false) return;
            Service.InsertAirport_Types(d.result, username, password);
        }

        private void Admin_AirportTypeUpdate_Click(object sender, RoutedEventArgs e)
        {
            DialogBox d = new DialogBox();
            d.ShowDialog();
            if (d.okClick == false) return;
            Service.UpdateAirport_Types(d.result, (short)Admin_AirportTypeCombo.SelectedValue,username,password);
        }

        private void Admin_AirlineTypeAdd_Click(object sender, RoutedEventArgs e)
        {
            DialogBox d = new DialogBox();
            d.ShowDialog();
            if (d.okClick == false) return;
            Service.InsertAirline_types(d.result, username, password);
        }

        private void Admin_AirlineTypeUpdate_Click(object sender, RoutedEventArgs e)
        {
            DialogBox d = new DialogBox();
            d.ShowDialog();
            if (d.okClick == false) return;
            Service.UpdateAirline_types(d.result, (short)Admin_AirlineTypeCombo.SelectedValue, username, password);
        }

        private void Airports_CityCombo_DropDownOpened(object sender, EventArgs e)
        {
            Airports_CityCombo.ItemsSource = Service.GetComboCity().Tables[0].DefaultView;
        }

        private void Airports_AirportTypeCombo_DropDownOpened(object sender, EventArgs e)
        {
            Airports_AirportTypeCombo.ItemsSource = Service.GetComboAirport_types().Tables[0].DefaultView;
        }

        private void Airlines_TypeCombo_DropDownOpened(object sender, EventArgs e)
        {
            Airlines_TypeCombo.ItemsSource = Service.GetComboAirline_types().Tables[0].DefaultView;
        }

        private void Airlines_CountryCombo_DropDownOpened(object sender, EventArgs e)
        {
            Airlines_CountryCombo.ItemsSource = Service.GetComboCountry().Tables[0].DefaultView;
        }

        private void Airplanes_UsageTypeCombo_DropDownOpened(object sender, EventArgs e)
        {
            Airplanes_UsageTypeCombo.ItemsSource = Service.GetComboAirplane_Usage().Tables[0].DefaultView;
        }

        private void Flights_AirplaneCombo_DropDownOpened(object sender, EventArgs e)
        {
            Flights_AirplaneCombo.ItemsSource = Service.GetComboAirplane().Tables[0].DefaultView;
            
        }

        private void Flights_DestORBeginCombo_DropDownOpened(object sender, EventArgs e)
        {
            Flights_DestORBeginCombo.ItemsSource = Service.GetComboAirport().Tables[0].DefaultView;
        }

        private void Flights_AirplaneCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Flights_AirplaneCombo.SelectedValue == null) 
                { Flights_BeneficiaryCombo.IsEnabled = false; return; }
            Flights_BeneficiaryCombo.ItemsSource = Service.GetComboAirline().Tables[0].DefaultView;
            Flights_BeneficiaryCombo.SelectedValue = Service.GetAirplaneOwner((string)Flights_AirplaneCombo.SelectedValue);
            
            Flights_BeneficiaryCombo.IsEnabled = true;
        }

        private void Flights_DestORBeginCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Flights_DestORBeginCombo.SelectedValue == null)
            { Flights_RouteCombo.IsEnabled = false; return; }

        if (Flights_DestinationRadio.IsChecked == true)
            Flights_RouteCombo.ItemsSource = Service.GetComboRoutes(workPlaceAirport, (string)Flights_DestORBeginCombo.SelectedValue).Tables[0].DefaultView;
         
        else if (Flights_BeginingRadio.IsChecked == true)
            Flights_RouteCombo.ItemsSource = Service.GetComboRoutes((string)Flights_DestORBeginCombo.SelectedValue, workPlaceAirport).Tables[0].DefaultView;
        Flights_RouteCombo.SelectedIndex = 0;
            Flights_RouteCombo.IsEnabled = true;
        }

        private void Flights_DestinationRadio_Checked(object sender, RoutedEventArgs e)
        {
            if ((string)Flights_DestORBeginCombo.SelectedValue == null) { Flights_RouteCombo.IsEnabled = false; return; }
            Flights_RouteCombo.ItemsSource = Service.GetComboRoutes(workPlaceAirport, (string)Flights_DestORBeginCombo.SelectedValue).Tables[0].DefaultView;
            Flights_RouteCombo.SelectedIndex = 0;
        }
        private void Flights_BeginingRadio_Checked(object sender, RoutedEventArgs e)
        {
            if ((string)Flights_DestORBeginCombo.SelectedValue == null) { Flights_RouteCombo.IsEnabled = false; return; }
            Flights_RouteCombo.ItemsSource = Service.GetComboRoutes((string)Flights_DestORBeginCombo.SelectedValue, workPlaceAirport).Tables[0].DefaultView;
            Flights_RouteCombo.SelectedIndex = 0;
        }

        private void Flights_PassengerRadio_Checked(object sender, RoutedEventArgs e)
        {
            Flights_Adults.IsEnabled = true;
            Flights_Childs.IsEnabled = true;
            Flights_Infants.IsEnabled = true;
            Flights_Load.IsEnabled = true;
            flights_telescopeCheck.IsEnabled = true;
        }

        private void Flights_CargoRadio_Checked(object sender, RoutedEventArgs e)
        {
            Flights_Adults.IsEnabled = false;
            Flights_Childs.IsEnabled = false;
            Flights_Infants.IsEnabled = false;
            Flights_Load.IsEnabled = true;
            flights_telescopeCheck.IsEnabled = false;
            flights_telescopeCheck.IsChecked = false;

        }

        private void Flights_OthersRadio_Checked(object sender, RoutedEventArgs e)
        {
            Flights_Adults.IsEnabled = false;
            Flights_Childs.IsEnabled = false;
            Flights_Infants.IsEnabled = false;
            Flights_Load.IsEnabled = false;

            flights_telescopeCheck.IsEnabled = false;
            flights_telescopeCheck.IsChecked = false;

        }
        

        private void Flights_delete_Click(object sender, RoutedEventArgs e)
        {
            Service.DeleteFlight((int)Flights_Grid.SelectedValue, username, password);
            Flights_Refresh_Click(sender, e);
        }

        private void Flights_add_Click(object sender, RoutedEventArgs e)
        {
            int FlightInfants = 0;
            int FlightAdults = 0;
            int FlightChilds = 0;
            int FlightLoad = 0;
            
            if ((bool)Flights_PassengerRadio.IsChecked)
            {
                 FlightInfants = Convert.ToInt32(Flights_Infants.Text != null ? Flights_Infants.Text : "0");
                 FlightAdults = Convert.ToInt32(Flights_Adults.Text != null ? Flights_Adults.Text : "0");
                FlightChilds = Convert.ToInt32(Flights_Childs.Text != null ? Flights_Childs.Text : "0");
                FlightLoad = Convert.ToInt32(Flights_Load.Text != null ? Flights_Load.Text : "0");
            }
            else if ((bool)Flights_CargoRadio.IsChecked) { FlightLoad = Convert.ToInt32(Flights_Load.Text != null ? Flights_Load.Text : "0"); }

            bool result = Service.InsertFlight(Convert.ToInt32(Flights_FID.Text), Convert.ToDateTime(Flights_SchDTFlight.Text), flights_DTflight.Text, FlightLoad, Convert.ToInt32(Flights_FuelVolume.Text),
                (bool)Flights_isScheduledCheck.IsChecked, (bool)Flights_isLocalCheck.IsChecked, (bool)Flights_isCharterCheck.IsChecked,
                (string)Flights_AirplaneCombo.SelectedValue, (string)Flights_BeneficiaryCombo.SelectedValue, Convert.ToInt32(Flights_RouteCombo.SelectedValue),
                username, password, (bool)flights_telescopeCheck.IsChecked, FlightInfants, FlightChilds, FlightAdults);
            Flights_Refresh_Click(sender, e);
            if (!result) { ErrorBox er = new ErrorBox("خطا"); er.Show(); }
        }

        private void Flights_DelayButton_Click(object sender, RoutedEventArgs e)
        {
            Delays d = new Delays(Service,(int)Flights_Grid.SelectedValue,username,password);
            d.ShowDialog();
        }

        private void AccessControl_UserTypeCombo_DropDownOpened(object sender, EventArgs e)
        {
            AccessControl_UserTypeCombo.ItemsSource = Service.GetComboUser_Type().Tables[0].DefaultView;
        }

        private void Flights_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Flights_Grid.SelectedValue == null)
            {
                Flights_delete.IsEnabled = false;
                Flights_Update.IsEnabled = false;
                Flights_DelayButton.IsEnabled = false;
                Flights_BeneficiaryCombo.IsEnabled = false;
                Flights_RouteCombo.IsEnabled = false;
                Flights_BeneficiaryCombo.SelectedIndex = -1;
                Flights_RouteCombo.SelectedIndex = -1;
                Flights_OthersRadio.IsChecked = true;
                return;
            }
            else {
                Flights_delete.IsEnabled = true;
                Flights_Update.IsEnabled = true;
                Flights_DelayButton.IsEnabled = true;
                Flights_DestinationRadio.IsEnabled = true;
                Flights_AirplaneCombo_SelectionChanged(sender,e);
                Flights_DestORBeginCombo_SelectionChanged(sender, e);
                if (Flights_Adults.Text != "0" || Flights_Childs.Text != "0" || Flights_Infants.Text != "0") Flights_PassengerRadio.IsChecked = true;
                else if (Flights_Load.Text != "0") Flights_CargoRadio.IsChecked = true;
                else Flights_OthersRadio.IsChecked = true;
            }
          
        }

        private void Flights_Refresh_Click(object sender, RoutedEventArgs e)
        {
            
            if ((bool)flights_AllQueryRadio.IsChecked)
            {
            Flights_Grid.Columns[11].Visibility=System.Windows.Visibility.Hidden;
            Flights_Grid.Columns[12].Visibility = System.Windows.Visibility.Hidden;
            Flights_Grid.Columns[13].Visibility = System.Windows.Visibility.Hidden;
            Flights_Grid.ItemsSource = Service.GetGridAllFlight(username,password).Tables[0].DefaultView;
            }
            else if ((bool)flights_CargoQueryRadio.IsChecked)
            {
            Flights_Grid.Columns[11].Visibility = System.Windows.Visibility.Hidden;
            Flights_Grid.Columns[12].Visibility = System.Windows.Visibility.Hidden;
            Flights_Grid.Columns[13].Visibility = System.Windows.Visibility.Visible;
            Flights_Grid.ItemsSource = Service.GetGridCargoFlight(username,password).Tables[0].DefaultView;
            }
            else
            {
                Flights_Grid.Columns[11].Visibility = System.Windows.Visibility.Visible;
                Flights_Grid.Columns[12].Visibility = System.Windows.Visibility.Visible;
                Flights_Grid.Columns[13].Visibility = System.Windows.Visibility.Visible;
                Flights_Grid.ItemsSource = Service.GetGridPassengerFlight(username,password).Tables[0].DefaultView; }
        }

        private void Flights_Update_Click(object sender, RoutedEventArgs e)
        {
            int FlightInfants = 0;
            int FlightAdults = 0;
            int FlightChilds = 0;
            int FlightLoad = 0;

            if ((bool)Flights_PassengerRadio.IsChecked)
            {
                FlightInfants = Convert.ToInt32(Flights_Infants.Text != null ? Flights_Infants.Text : "0");
                FlightAdults = Convert.ToInt32(Flights_Adults.Text != null ? Flights_Adults.Text : "0");
                FlightChilds = Convert.ToInt32(Flights_Childs.Text != null ? Flights_Childs.Text : "0");
                FlightLoad = Convert.ToInt32(Flights_Load.Text != null ? Flights_Load.Text : "0");
            }
            else if ((bool)Flights_CargoRadio.IsChecked) { FlightLoad = Convert.ToInt32(Flights_Load.Text != null ? Flights_Load.Text : "0"); }

            bool result = Service.UpdateFlight(Convert.ToInt32(Flights_FID.Text), Convert.ToDateTime(Flights_SchDTFlight.Text), flights_DTflight.Text, FlightLoad, Convert.ToInt32(Flights_FuelVolume.Text),
                (bool)Flights_isScheduledCheck.IsChecked, (bool)Flights_isLocalCheck.IsChecked, (bool)Flights_isCharterCheck.IsChecked,
                (string)Flights_AirplaneCombo.SelectedValue, (string)Flights_BeneficiaryCombo.SelectedValue, Convert.ToInt32(Flights_RouteCombo.SelectedValue),
                 (bool)flights_telescopeCheck.IsChecked, FlightInfants, FlightChilds, FlightAdults, (int)Flights_Grid.SelectedValue, username, password);
            Flights_Refresh_Click(sender, e);
            if (!result) { ErrorBox er = new ErrorBox("خطا"); er.Show(); }
        }

        private void AccessControl_UserTypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AccessControl_UserTypeCombo.SelectedValue == null) return;
            bool[] forms = Service.GetAccessForms((short)AccessControl_UserTypeCombo.SelectedValue);
            bool[] components = Service.GetAccessComponents((short)AccessControl_UserTypeCombo.SelectedValue);

            for (int i = 0; i < TreeNodes.Length; i++)
                TreeNodes[i].check = forms[i];
            int c=0;
            for (int i = 0; i < TreeNodes.Length; i++)
                for (int j = 0; j < TreeNodes[i].childs.Length; j++)
                { TreeNodes[i].childs[j].check = components[c]; c++; }
            AccessControl_tree.Items.Refresh();
            
        }

        private void AccessControl_Add_Click(object sender, RoutedEventArgs e)
        {
            DialogBox d = new DialogBox();
            d.ShowDialog();
            Service.InsertUser_Type(d.result, username, password);

            for (int i = 0; i < TreeNodes.Length; i++)
                TreeNodes[i].check = false;
            for (int i = 0; i < TreeNodes.Length; i++)
                for (int j = 0; j < TreeNodes[i].childs.Length; j++)
                { TreeNodes[i].childs[j].check = false; }

            AccessControl_tree.Items.Refresh();

        }

        private void AccessControl_Update_Click(object sender, RoutedEventArgs e)
        {
            List<int> components = new List<int>();
            List<short> forms = new List<short>();

            for (short i = 0; i < TreeNodes.Length; i++)
                if(TreeNodes[i].check)forms.Add(i);
            int c = 0;
            for (int i = 0; i < TreeNodes.Length; i++)
                for (int j = 0; j < TreeNodes[i].childs.Length; j++)
                { if (TreeNodes[i].childs[j].check) components.Add(c); c++; }

            Service.UpdateAccessComponents(components.ToArray<int>(), (short)AccessControl_UserTypeCombo.SelectedValue, username, password);
            Service.UpdateAccessForms(forms.ToArray<short>(), (short)AccessControl_UserTypeCombo.SelectedValue, username, password);

        }

             public event PropertyChangedEventHandler PropertyChanged;
             private void NotifyPropertyChanged(String propertyName)
             {
                 if (PropertyChanged != null)
                 {
                     PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                 }
             }

             private void Admin_CityUpdate_Click(object sender, RoutedEventArgs e)
             {
                 Console.WriteLine((int)((DataRowView)Admin_CityCombo.SelectedItem)[2]);
                 DialogBoxCity d = new DialogBoxCity(Service, (int)((DataRowView)Admin_CityCombo.SelectedItem)[2]);
                 d.ShowDialog();
                 if (d.okClick == false) return;
                 Service.UpdateCity(d.result, d.selectedCountry, (int)Admin_CityCombo.SelectedValue, username, password);
             }
    }
}
