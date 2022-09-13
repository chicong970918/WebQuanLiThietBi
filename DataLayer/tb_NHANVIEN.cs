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

    public partial class tb_NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_NHANVIEN()
        {
            this.tb_NGUOIDUNG = new HashSet<tb_NGUOIDUNG>();
            this.TB_NHANTHIETBI = new HashSet<TB_NHANTHIETBI>();
            this.tb_TRATHIETBI = new HashSet<tb_TRATHIETBI>();
            this.tb_YEUCAUTHIETBI = new HashSet<tb_YEUCAUTHIETBI>();
        }
    
        public int IDNHANVIEN { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        public int IDNGUOIDUNG { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string HOVATEN { get; set; }
        [Display(Name = "Giới tính")]
        public bool GIOITINH { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string SDT { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string EMAIL { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string DIACHI { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        public int IDCHUCVU { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        public int IDPHONGBAN { get; set; }
        [Display(Name ="Tình trạng hoạt động")]
        public bool TINHTRANGHOATDONG { get; set; }
        public string GHICHU { get; set; }
    
        public virtual tb_CHUCVU tb_CHUCVU { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_NGUOIDUNG> tb_NGUOIDUNG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_NHANTHIETBI> TB_NHANTHIETBI { get; set; }
        public virtual tb_PHONGBAN tb_PHONGBAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_TRATHIETBI> tb_TRATHIETBI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_YEUCAUTHIETBI> tb_YEUCAUTHIETBI { get; set; }
    }
}
