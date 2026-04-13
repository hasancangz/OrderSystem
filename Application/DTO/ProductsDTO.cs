using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Application.DTO
{
   public record ProductsDTO(int ıd,string name,decimal price,int unreservedstock);

    public record struct DecAndInc(int ıd,string name,int stock,int? reservedstock);
    
}
