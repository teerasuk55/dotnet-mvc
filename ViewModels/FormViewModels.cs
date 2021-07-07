using System.Collections.Generic;
using sample.Entities;

namespace dotnet_mvc_master.ViewModels
{
    public class FormViewModels
    { 
        public List<Provinces> Provinces { get; set; }  
        public List<Districts> Districts { get; set; }  
        public List<Subdistricts> Subdistricts { get; set; }  
        public string msg { get; set; }
        
    }
}