//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Czytam
{
    using System;
    using System.Collections.Generic;
    
    public partial class syllable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public syllable()
        {
            this.words = new HashSet<word>();
        }
    
        public int id { get; set; }
        public string syllable_text { get; set; }
        public int exercises_setup_id { get; set; }
    
        public virtual exercises_setup exercises_setup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<word> words { get; set; }
    }
}
