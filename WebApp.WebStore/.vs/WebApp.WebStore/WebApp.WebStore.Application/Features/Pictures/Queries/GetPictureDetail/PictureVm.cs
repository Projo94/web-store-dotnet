using System;

namespace WebApp.WebStore.Application.Features.Pictures.Queries.GetPictureDetail
{
    public class PictureVm
    {

        public int PictureID { get; set; }

        public string Name { get; set; }

        public string PictureDisplay { get; set; }


        public Guid ProductID { get; set; }


    }
}
