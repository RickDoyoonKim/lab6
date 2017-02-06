using Lab05.Models.CustomValidation;
using MvcDbApp.Models.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab05.Models.NorthWind
{
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product { }

    public class ProductMetaData
    {
        [HiddenInput(DisplayValue = false)]
        public object ProductID { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [Display(Name = "Product Name")]
        [ExceedWords(3, ErrorMessage = "Product Name should not exceed 3 words.")] 
        [ExcludeChar("/.,!@#$%", ErrorMessage = "Name contains invalid character.")]
        public object ProductName { get; set; }

        [UIHint("SupplierDropDown")]
        [Display(Name = "Supplier")]
        public object SupplierID { get; set; }

        [UIHint("CategoryDropDown")]
        [Display(Name = "Category")]
        public object CategoryID { get; set; }

        [Required(ErrorMessage = "Unit price is required.")]
        [DataType(DataType.Currency)]
        public object UnitPrice { get; set; }

        [ScaffoldColumn(false)]
        public string QuantityPerUnit { get; set; }

        [ScaffoldColumn(false)]
        public Nullable<short> UnitsInStock { get; set; }

        [ScaffoldColumn(false)]
        public Nullable<short> UnitsOnOrder { get; set; }

        [ScaffoldColumn(false)]
        public Nullable<short> ReorderLevel { get; set; }

        [ScaffoldColumn(false)]
        public bool Discontinued { get; set; }
    }
}