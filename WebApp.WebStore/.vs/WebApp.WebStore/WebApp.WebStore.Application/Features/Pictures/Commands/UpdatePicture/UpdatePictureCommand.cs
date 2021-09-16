using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.WebStore.Application.Features.Pictures.Commands.UpdatePicture
{
    public class UpdatePictureCommand : IRequest
    {
        public int PictureID { get; set; }
        public string Name { get; set; }

        public string PictureDisplay { get; set; }
        public Guid ProductID { get; set; }


    }
}
