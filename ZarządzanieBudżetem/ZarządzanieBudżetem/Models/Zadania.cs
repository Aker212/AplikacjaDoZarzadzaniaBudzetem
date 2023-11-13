//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZarządzanieBudżetem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zadania
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zadania()
        {
            this.Faktury = new HashSet<Faktury>();
            this.Wnioski = new HashSet<Wnioski>();
        }
    
        public int IdZadania { get; set; }
        public Nullable<int> Lp { get; set; }
        public string Nazwa_Kosztu { get; set; }
        public Nullable<decimal> Wartość_Ogółem { get; set; }
        public Nullable<decimal> Wydatki_Kwalifikowane { get; set; }
        public Nullable<decimal> Dofinansowanie { get; set; }
        public string Kategoria_Kosztów { get; set; }
        public Nullable<int> Ilość_Personelu { get; set; }
        public Nullable<bool> Zakończone { get; set; }
        public Nullable<decimal> SumaWydatków { get; set; }
        public Nullable<int> IdProjektu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Faktury> Faktury { get; set; }
        public virtual Projekty Projekty { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wnioski> Wnioski { get; set; }
    }
}
