using App1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.ViewModels
{
    class ListViewModel
    {
        public List<MyList> Lists { get; set;} 



        public ListViewModel()
        {
            Lists = new MyList().GetLists();

            foreach (var item in Lists)
            {
                item.CalcItemCount();
            }
        }
    }
}
