//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SA_Hire_Disk
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public int Id_User { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Nullable<int> Role { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    
        public virtual Positions Positions { get; set; }
    }
}
