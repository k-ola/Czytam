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
    
    public partial class exercises_setup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public exercises_setup()
        {
            this.syllables = new HashSet<syllable>();
            this.words = new HashSet<word>();
        }
    
        public int id { get; set; }
        public int exercise_number { get; set; }
        public string exercise_description { get; set; }
        public int lesson_id { get; set; }
    
        public virtual lessons_setup lessons_setup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<syllable> syllables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<word> words { get; set; }
    }
}