using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.Models
{
    public class Shopping
    {
        public ShoesID ShoesID { get; }
        public string Username { get; }


        public Shopping(ShoesID roomID, string username)
        {
            ShoesID = roomID;
            Username = username;
        }
    }
}
