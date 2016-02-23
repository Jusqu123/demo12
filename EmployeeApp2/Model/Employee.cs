using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp2.Model
{
    public class Employee : INotifyPropertyChanged
    {
        // declare the event ... "Some property has changed"
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// This method is called by the Set accessor of each property.
        /// The CallerMemberName attribute that is applied to the optional propertyName
        /// parameter causes the property name of the caller to be substituted as an argument.        
        /// </summary>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public string ID { get; set; }
        private string firstname;
        public string Firstname
        {


            get
            {
                return firstname;
            }



            set
            {
                firstname = value;
                Fullname = firstname + Lastname;
                // KERROTAAN ETTÄ ETUNIMI OMINAISUUS ON MUUTTUNUT ! ! !
                RaisePropertyChanged();
            }



        }




        public string Lastname { get; set; }


        
        public string JobTitle { get; set; }
        public EmployeeImage Image { get; set; }
        private string fullname;
        public string Fullname
        {
            get
            {
                return Lastname + " " + Firstname;
            }
            set
            {
                fullname = value;
                RaisePropertyChanged();
            }
        }
    }

    public class EmployeeViewModel
    {
        //private List<Employee> employees = new List<Employee>();
        //public List<Employee> Employees { get { return employees; } }
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> Employees { get { return employees; } }

        // konstr.
        public EmployeeViewModel()
        {
            // generate dummy data if needed
        }

        // metodi lisää uuden employeen kokoelmaan
        public void AddEmployee(string firstname, string lastname, 
            string jobTitle,EmployeeImage image)
        {
            // luodaan uusi employee
            string id = "0001"; // kaikilla on nyt sama ID... random? 
            employees.Add(new Employee {
                ID =id,
                Firstname = firstname,
                Lastname = lastname,
                JobTitle = jobTitle,
                Image = image
            });
        }
        // poistetaan employee-objekti kokoelmasta
        public void RemoveEmployee (Employee employee)
        {
            employees.Remove(employee);
        } 
    }
}
