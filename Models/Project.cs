//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagerAssistant
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Project
    {
        public System.Guid Id { get; set; }

        [Display(Name = "Name project")]
        [DataType(DataType.Text)]
        public string NameProject { get; set; }


        [Display(Name = "Status")]
        [DataType(DataType.Text)]
        public string Status { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Day on development")]
        public Nullable<Int32> DayOnDev { get; set; }

        [Display(Name = "Insurance")]
        public Nullable<Int32> Insurance { get; set; }

        private Int32? TDead { get; set; }
        [Display(Name = "DeadLine")]
        public Nullable<Int32> TotalDeadline
        {
            get
            {
                TDead = null;
                if (TDead == null)
                {

                    TDead = calculateDeadLine();
                }
                else
                    TDead = null;
                return TDead;
            }
            set
            {
                if (value != null)
                    TDead = value;
            }
        }

        [Display(Name = "Quantity developers")]
        public Nullable<int> QuantityPerson { get; set; }

        [Display(Name = "Rent")]
        [DataType(DataType.Currency)]
        public Nullable<double> Rent { get; set; }

        [Display(Name = "PaymentForServers")]
        [DataType(DataType.Currency)]
        public Nullable<double> PaymentForServers { get; set; }

        private double? TCost;
        [Display(Name = "Cost")]
        [DataType(DataType.Currency)]
        public Nullable<double> Cost
        {
            get
            {
                TCost = null;
                if (TCost == null)
                {

                    TCost = calculateCost();
                }
                else
                    TCost = null;
                return TCost;
            }
            set
            {
                if (value != null)
                    TCost = value;
            }
        }

        [Display(Name = "Average income")]
        [DataType(DataType.Currency)]
        public Nullable<double> AverageIncome { get; set; }

        private double? TIncome;
        [Display(Name = "Total income")]
        [DataType(DataType.Currency)]
        public Nullable<double> TotalIncome
        {
            get
            {
                TIncome = null;
                if (TIncome == null)
                {

                    TIncome = calculateIncome();
                }
                else
                    TIncome = null;
                return TIncome;
            }
            set
            {
                if (value != null)
                    TIncome = value;
            }
        }

        private double? TProfit;
        [Display(Name = "Profit")]
        [DataType(DataType.Currency)]
        public Nullable<double> Profit
        {
            get
            {
                TProfit = null;
                if (TProfit == null)
                {

                    TProfit = calculateProfit();
                }
                else
                    TProfit = null;
                return TProfit;
            }
            set
            {
                if (value != null)
                    TProfit = value;
            }
        }

        private double? TTax;
        [Display(Name = "Tax")]
        [DataType(DataType.Currency)]
        public Nullable<double> Tax
        {
            get
            {
                TTax = null;
                if (TTax == null)
                {

                    TTax = calculateTax();
                }
                else
                    TTax = null;
                return TTax;
            }
            set
            {
                if (value != null)
                    TTax = value;
            }
        }

        private double? TCostProject;
        [Display(Name = "Cost project")]
        [DataType(DataType.Currency)]
        public Nullable<double> CostProject
        {
            get
            {
                TCostProject = null;
                if (TCostProject == null)
                {

                    TCostProject = calculateTotalCost();
                }
                else
                    TCostProject = null;
                return TCostProject;
            }
            set
            {
                if (value != null)
                    TTax = value;
            }
        }


        [Display(Name = "Id заказа")]
        public Nullable<System.Guid> IdOrder { get; set; }

        [Display(Name = "Id работника")]
        public Nullable<System.Guid> IdEmployee { get; set; }

        [Display(Name = "Id клиента")]
        public Nullable<System.Guid> IdClient { get; set; }

        [Display(Name = "Id лида")]
        public Nullable<System.Guid> IdLead { get; set; }
    





        public virtual Employee Eployee { get; set; }
        public virtual Order Order { get; set; }
        public virtual Client Client { get; set; }
        public virtual TableForEmployee TableForEmployee { get; set; }





        private double? calculateTotalCost()
        {
            return Cost + Profit + Tax + TotalIncome;
        }
        private double? calculateTax()
        {
            return ((Cost + Profit) * 20) / 100;
        }
        private double? calculateProfit()
        {
            return (Cost * 20) / 100;
        }
        private double? calculateIncome()
        {
            return (AverageIncome / 23) * TotalDeadline;
        }

        private double? calculateCost()
        {
            return Rent + PaymentForServers;
        }

        private Int32? calculateDeadLine()
        {
            return DayOnDev + Insurance;
        }
    }
}