﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tb_CHUCVU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_CHUCVU()
        {
            this.tb_NHANVIEN = new HashSet<tb_NHANVIEN>();
        }
    
        public int IDCHUCVU { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string TENCHUCVU { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        public int IDNGUOIDUNG { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string QUYEN { get; set; }
    
        public virtual tb_NGUOIDUNG tb_NGUOIDUNG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_NHANVIEN> tb_NHANVIEN { get; set; }
    }
}