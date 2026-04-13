using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Application.DTO
{
    public record UpdateProductDTO(string name,int newstock,int previousstock);
}
