﻿using System;
using System.Threading.Tasks;
using PNN.web.Data;
using PNN.Web.Data.Entities;
using PNN.Web.Models;

namespace PNN.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(
            DataContext dataContext,
            ICombosHelper combosHelper)
        {
            _dataContext = dataContext;
            _combosHelper = combosHelper;
        }
        //convierte un objeto de la clase ContentViewModel en la clase Content
        public async Task<Content> ToContentAsync(ContentViewModel model, string path, bool isNew)
        {
            var content = new Content
            {
                Comments = model.Comments,
                Id = isNew ? 0 : model.Id,
                Description = model.Description,
                Date = DateTime.Now,
                ImageUrl = path,
                Like = model.Like,
                DisLike = model.DisLike,
                User = await _dataContext.Users.FindAsync(model.UserId),
                Park = await _dataContext.Parks.FindAsync(model.ParkId),
                ContentType = await _dataContext.ContentTypes.FindAsync(model.ContentTypeId)
                //Location = await _dataContext.Locations.FindAsync(model.LocationId)
            };
            return content;
        }
              
        //editar publicaciones
        public ContentViewModel ToContentViewModel(Content content)
        {
            return new ContentViewModel
            {
                Description = content.Description,
                Date = content.Date,
                ImageUrl = content.ImageUrl,
                Like = content.Like,
                DisLike = content.DisLike,
                Comments = content.Comments,
                User = content.User,
                ContentType = content.ContentType,
                Park = content.Park,
                //Location = content.Location,
                Id = content.Id,
                UserId = content.User.Id,
                ContentTypeId = content.ContentType.Id,
                ContentTypes = _combosHelper.GetComboContentTypes(),
                ParkId = content.Park.Id,
                Parks = _combosHelper.GetComboParks()
                //LocationId = content.Location.Id               
            };
        }
        //metodo para agregar comentario desde contenido o publicación de CommentViewModel a Comment
        public async Task<Comment> ToCommentToContentAsync(CommentViewModel model, bool isNew)
        {

            return new Comment
            {
                Date = DateTime.Now,
                Description = model.Description,
                Id = isNew ? 0 : model.Id,
                Content = await _dataContext.Contents.FindAsync(model.ContentId),
                User = await _dataContext.Users.FindAsync(model.UserId)
            };
        }

        //metodo para agregar comentario desde contenido o publicación de Comment a CommentViewModel
        public CommentViewModel ToCommentToContentViewModel(Comment comment)
        {

            return new CommentViewModel
            {
                Date = comment.Date,
                Description = comment.Description,
                Id = comment.Id,
                ContentId = comment.Content.Id,
                UserId = comment.User.Id
            };
        }

        //metodo para agregar comentario desde contenido o publicación de CommentViewModel a Comment
        public async Task<Comment> CommentToContentAsync(Comment comment, bool isNew)
        {

            return new Comment
            {
                Date = DateTime.Now,
                Description = comment.Description,
                Id = isNew ? 0 : comment.Id,
                Content = await _dataContext.Contents.FindAsync(comment.Content),
                User = await _dataContext.Users.FindAsync(comment.User)
            };
        }

        //convierte un objeto de la clase ContentViewModel en la clase Content
        public async Task<Park> ToParkAsync(ParkViewModel model, string path, bool isNew)
        {
            var park = new Park
            {
                Name = model.Name,
                Id = isNew ? 0 : model.Id,
                Description = model.Description,
                Creation = model.Creation,
                ImageUrl = path,
                Been = model.Been,
                Extension = model.Extension,
                Height = model.Height,
                Temperature = model.Temperature,
                Flora = model.Flora,
                Wildlife = model.Wildlife,
                Communities = model.Communities,
                Like = 0,
                DisLike = 0,
                Manager = await _dataContext.Managers.FindAsync(model.ManagerId)
                //Location = await _dataContext.Locations.FindAsync(model.LocationId)
            };
            return park;
        }

        //eiditar park
        public ParkViewModel ToParkViewModel(Park park)
        {
            return new ParkViewModel
            {
                Name = park.Name,
                Id = park.Id,
                Description = park.Description,
                Creation = park.Creation,
                ImageUrl = park.ImageUrl,
                Been = park.Been,
                Extension = park.Extension,
                Height = park.Height,
                Temperature = park.Temperature,
                Flora = park.Flora,
                Wildlife = park.Wildlife,
                Communities = park.Communities,
                ManagerId = park.Manager.Id
                //LocationId = content.Location.Id               
            };
        }
    }
}
