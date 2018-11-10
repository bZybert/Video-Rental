using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRental.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFree { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }

        //pola dodane aby w naszej customowej validacji kod był czytelniejszy
        public readonly static byte Unknown = 0;
        public readonly static byte PayAsYouGo = 1;
    }
}
