using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entities.ErrorModel
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; } //
        public String? Message { get; set; } //

        public override string ToString()
        {
            //class'ın tamamını ilgilendirdiği için this kullandık
            return JsonSerializer.Serialize(this);
        }
        /* bu nesneyi serialize edersek
         { message :"...", statusCode:200 } şeklinde görünüyor
         */
    }
}
